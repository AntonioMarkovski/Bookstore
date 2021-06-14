namespace Bookstore.Areas.Identity
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2, 6}$", ErrorMessage = "E-mail is not valid!")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IQueryable<SelectListItem> Roles { get; set; }

        public string RoleId { get; set; }

        public string RoleName { get; set; }
    }
}
