using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Bookstore.Areas.Identity;
using Bookstore.Entities.Logger;

namespace Bookstore.Controllers
{    
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly ILogger<UserController> _logger;

        public UserController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IPasswordHasher<IdentityUser> passwordHasher,
            ILogger<UserController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        // GET: UserController
        public ActionResult Index()
        {
            var users = _userManager.Users;
            _logger.LogInformation(LoggerMessageDisplay.UsersListed);

            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            var roles = _roleManager.Roles;
            var userModel = new UserModel();
            userModel.Roles = GetSelectListRoles(roles, null);

            return View(userModel);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser appUser = new IdentityUser
                {
                    UserName = user.Name,
                    Email = user.Email,
                    EmailConfirmed = true
                };

                // istoto sto i gore
                //IdentityUser appUser = new IdentityUser();
                //appUser.UserName = user.Name;
                //appUser.Email = user.Email;
                //appUser.EmailConfirmed = true;

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                _logger.LogInformation(LoggerMessageDisplay.UserCreated);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, user.RoleName);
                    _logger.LogInformation(LoggerMessageDisplay.UserAddedRole);

                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    _logger.LogError(LoggerMessageDisplay.UserNotCreatedModelStateInvalid);
                }
            }
            return View(user);
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            var roles = _roleManager.Roles; // get all roles from db
           
            if (user != null)
            {
                // var getUserRoles = await _userManager.GetRolesAsync(user); // get every role for specific user
                var userRoles = await _userManager.GetRolesAsync(user);
                
                var userModel = new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = GetSelectListRoles(roles, userRoles[0])
                };

                var selectedRoleId = roles.Where(x => x.Name == userRoles[0]).SingleOrDefault().Id;
                userModel.RoleId = selectedRoleId;
                //userModel.RoleId = ;
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, string email, string password, string RoleName)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var getUserOldRole = _roleManager.FindByNameAsync(userRoles[0]);

                if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                }
                else
                {
                    ModelState.AddModelError("", "Email cannot be empty");
                }

                if (!string.IsNullOrEmpty(password))
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                }
                else
                {
                    ModelState.AddModelError("", "Password cannot be empty");
                }

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.RemoveFromRoleAsync(user, getUserOldRole.Result.Name); // remove old role
                        await _userManager.AddToRoleAsync(user, RoleName); // add new role
                        _logger.LogInformation(LoggerMessageDisplay.UserEdited);
                        _logger.LogInformation(LoggerMessageDisplay.UserAddedRole);

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        Errors(result);
                        _logger.LogError(LoggerMessageDisplay.UserEditErrorModelStateInvalid);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
                _logger.LogWarning(LoggerMessageDisplay.NoUserFound);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    _logger.LogInformation(LoggerMessageDisplay.UserDeleted);
                    return RedirectToAction(nameof(Index));
                }          
                else
                {
                    Errors(result);
                    _logger.LogInformation(LoggerMessageDisplay.UserDeletedError);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
                _logger.LogWarning(LoggerMessageDisplay.NoUserFound);
            }

            return View(nameof(Index), _userManager.Users);
        }

        #region Helper Methods

        private IQueryable<SelectListItem> GetSelectListRoles(IQueryable<IdentityRole> roles, string? currentRoleName)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select role...",
                Selected = false
            });
            foreach (var item in roles)
            { 
                if (currentRoleName != null)
                {
                    if (item.Name.Equals(currentRoleName))
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = item.Id,
                            Text = item.Name,
                            Selected = true
                        });
                    }
                    else
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = item.Id,
                            Text = item.Name,
                            Selected = false
                        });
                    }
                }
                else
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = item.Id,
                        Text = item.Name,
                        Selected = false
                    });
                }
            }

            return selectList.AsQueryable();
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        #endregion
    }
}
