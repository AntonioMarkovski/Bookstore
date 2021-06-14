using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 1500, nullable: true),
                    Language = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 50, nullable: true),
                    Popularity = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    BookTitle = table.Column<string>(nullable: true),
                    BookAuthor = table.Column<string>(nullable: true),
                    BookCountry = table.Column<string>(nullable: true),
                    BookPublisher = table.Column<string>(nullable: true),
                    BookCategory = table.Column<string>(nullable: true),
                    BookType = table.Column<string>(nullable: true),
                    BookDimensions = table.Column<string>(nullable: true),
                    BookWeight = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShippedDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    Year = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tags = table.Column<string>(nullable: true),
                    Quote = table.Column<string>(nullable: true),
                    Lang = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 350, nullable: true),
                    AuthorName = table.Column<string>(maxLength: 350, nullable: true),
                    AuthorID = table.Column<int>(nullable: false),
                    YearOfIssue = table.Column<DateTime>(nullable: false),
                    NumberOfPages = table.Column<int>(nullable: false),
                    PublisherName = table.Column<string>(maxLength: 350, nullable: true),
                    PublisherID = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Genre = table.Column<string>(maxLength: 150, nullable: true),
                    CategoryName = table.Column<string>(maxLength: 150, nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    BookType = table.Column<string>(maxLength: 50, nullable: true),
                    BookCoverType = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 1500, nullable: true),
                    Language = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 150, nullable: true),
                    Edition = table.Column<int>(nullable: false),
                    Dimensions = table.Column<string>(maxLength: 50, nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Copies = table.Column<int>(nullable: false),
                    Shipping = table.Column<string>(maxLength: 50, nullable: true),
                    PhotoURL = table.Column<string>(nullable: true),
                    SoldItems = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Test = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e74", "3aa983fc-40bd-4d64-8592-1c04dbcd05aa", "editor", "EDITOR" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "fa5e5c18-3638-4f74-b04e-73cca94bb3d8", "admin", "ADMIN" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e75", "d2439c46-60de-4569-95f5-30878a5b508c", "guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", 0, "c8554266-b401-4519-9aeb-a9283053fc58", "Test@test.com", true, false, null, "TEST@TEst.COM", "Test@TEST.COM", "AQAAAAEAACcQAAAAEIUj3+g2wNl73m8cwQmOxsNRrUhMnk2YZjULphTOg4DV7mDuMEI6w5LNI4Y+AUuH4g==", null, false, "", false, "Test@test.com" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "DateBirth", "Gender", "Language", "Name", "Popularity", "ShortDescription" },
                values: new object[,]
                {
                    { 10, "Country10", new DateTime(2021, 5, 10, 20, 37, 4, 871, DateTimeKind.Local).AddTicks(9947), "Male", "English", "Dan Brown", false, "Daniel Gerhard Brown (born June 22, 1964) is an American author best known for his thriller novels, including the Robert Langdon novels Angels & Demons (2000), The Da Vinci Code (2003), The Lost Symbol (2009), Inferno (2013) and Origin (2017). His novels are treasure hunts that usually take place over a period of 24 hours.[2] They feature recurring themes of cryptography, art, and conspiracy theories. His books have been translated into 57 languages and, as of 2012, have sold over 200 million copies. Three of them, Angels & Demons, The Da Vinci Code, and Inferno, have been adapted into films." },
                    { 9, "Country9", new DateTime(2021, 5, 10, 20, 37, 4, 871, DateTimeKind.Local).AddTicks(9942), "Male", "English", "Nicholas Sparks", false, "Nicholas Charles Sparks (born December 31, 1965) is an American romance novelist and screenwriter. He has published twenty novels and two non-fiction books. Several of his novels have become international bestsellers, and eleven of his romantic-drama novels have been adapted to film all with multimillion-dollar box office grosses.His novels feature stories of tragic love with happy endings." },
                    { 8, "Country8", new DateTime(2021, 5, 10, 20, 37, 4, 871, DateTimeKind.Local).AddTicks(9938), "Male", "English", "Ian Fleming", false, "Ian Lancaster Fleming (28 May 1908 – 12 August 1964) was an English author, journalist and naval intelligence officer who is best known for his James Bond series of spy novels. Fleming came from a wealthy family connected to the merchant bank Robert Fleming & Co., and his father was the Member of Parliament for Henley from 1910 until his death on the Western Front in 1917. Educated at Eton, Sandhurst and, briefly, the universities of Munich and Geneva, Fleming moved through several jobs before he started writing." },
                    { 1, "Country1", new DateTime(2021, 5, 10, 20, 37, 4, 871, DateTimeKind.Local).AddTicks(8154), "Female", "English", "Agatha Christie", false, "Dame Agatha Mary Clarissa Christie, Lady Mallowan, DBE (née Miller; 15 September 1890 – 12 January 1976) was an English writer known for her 66 detective novels and 14 short story collections, particularly those revolving around fictional detectives Hercule Poirot and Miss Marple. She also wrote the world's longest-running play The Mousetrap and six romances under the pen name Mary Westmacott. In 1971, she was appointed a Dame Commander of the Order of the British Empire (DBE) for her contribution to literature" },
                    { 6, "Country6", new DateTime(2021, 5, 10, 20, 37, 4, 871, DateTimeKind.Local).AddTicks(9928), "Male", "English", "Paulo Coelho", false, "Paulo Coelho de Souza (born 24 August 1947) is a Brazilian lyricist and novelist, best known for his novel The Alchemist. In 2014, he uploaded his personal papers online to create a virtual Paulo Coelho Foundation" },
                    { 5, "Country5", new DateTime(2021, 5, 10, 20, 37, 4, 871, DateTimeKind.Local).AddTicks(9923), "Male", "English", "Leo Tolstoy", false, "Count Lev Nikolayevich Tolstoy (9 September [O.S. 28 August] 1828 – 20 November [O.S. 7 November] 1910), usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time. He received multiple nominations for the Nobel Prize in Literature every year from 1902 to 1906, and nominations for Nobel Peace Prize in 1901, 1902 and 1910, and the fact that he never won is a major Nobel prize controversy" },
                    { 2, "Country2", new DateTime(2021, 5, 10, 20, 37, 4, 871, DateTimeKind.Local).AddTicks(9867), "Male", "English", "Stephen King", true, "Stephen Edwin King (born September 21, 1947) is an American author of horror, supernatural fiction, suspense, and fantasy novels. His books have sold more than 350 million copies, many of which have been adapted into feature films, miniseries, television series, and comic books. King has published 61 novels (including seven under the pen name Richard Bachman) and six non-fiction books. He has written approximately 200 short stories, most of which have been published in book collections." },
                    { 3, "Country3", new DateTime(2021, 5, 10, 20, 37, 4, 871, DateTimeKind.Local).AddTicks(9910), "Male", "English", "William Shakespeare", false, "William Shakespeare (bapt. 26 April 1564 – 23 April 1616) was an English poet, playwright, and actor, widely regarded as the greatest writer in the English language and the world's greatest dramatist. He is often called England's national poet and the \"Bard of Avon\" (or simply \"the Bard\"). His extant works, including collaborations, consist of some 39 plays, 154 sonnets, two long narrative poems, and a few other verses, some of uncertain authorship. His plays have been translated into every major living language and are performed more often than those of any other playwright" },
                    { 7, "Country7", new DateTime(2021, 5, 10, 20, 37, 4, 871, DateTimeKind.Local).AddTicks(9933), "Male", "English", "Jeffrey Archer", false, "Jeffrey Howard Archer (born 15 April 1940) is an English novelist, former politician, convicted perjurer, and peer of the realm. Before becoming an author,Archer was a Member of Parliament(1969–1974), but did not seek re - election after a financial scandal that left him almost bankrupt.He revived his fortunes as a best - selling novelist; his books have sold around 330 million copies worldwide" },
                    { 4, "Country4", new DateTime(2021, 5, 10, 20, 37, 4, 871, DateTimeKind.Local).AddTicks(9917), "Female", "English", "J. K. Rowling", false, "Joanne Rowling CH, OBE, HonFRSE, FRCPE, FRSL, (born 31 July 1965), better known by her pen name J. K. Rowling, is a British author, film producer, television producer, screenwriter, and philanthropist. She is best known for writing the Harry Potter fantasy series,which has won multiple awards and sold more than 500 million copies, becoming the best-selling book series in history. The books are the basis of a popular film series, over which Rowling had overall approval on the scripts and was a producer on the final films. She also writes crime fiction under the name Robert Galbraith." }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 11, "Uncategorised" },
                    { 10, "Comedy" },
                    { 9, "Horror" },
                    { 8, "General" },
                    { 6, "Fantasy" },
                    { 5, "Drama" },
                    { 4, "Adventure" },
                    { 3, "Crime" },
                    { 1, "Fiction" },
                    { 2, "Action" },
                    { 7, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "Name", "Year" },
                values: new object[,]
                {
                    { 10, "USA", "Pearson Education", "2020" },
                    { 9, "USA", "Houghton Mifflin Harcourt", "2020" },
                    { 8, "USA", "McGraw-Hill Education", "2020" },
                    { 6, "Germany", "Macmillan Publishers", "2020" },
                    { 5, "USA", "HarperCollins", "2020" },
                    { 4, "France", "Hachette Livre", "2020" },
                    { 3, "Not known", "Penguin Random House", "2020" },
                    { 2, "USA", "Scholastic", "2020" },
                    { 7, "USA", "Simon & Schuster", "2020" },
                    { 1, "Ireland", "William Morrow Paperbacks", "2020" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorID", "AuthorName", "BookCoverType", "BookType", "CategoryID", "CategoryName", "Copies", "Country", "DateAdded", "Description", "Dimensions", "Edition", "Genre", "Language", "NumberOfPages", "PhotoURL", "Price", "PublisherID", "PublisherName", "Rating", "Shipping", "SoldItems", "Test", "Title", "UserId", "Weight", "YearOfIssue" },
                values: new object[,]
                {
                    { 4, 2, "Stephen King", "Paper", "Paperback", 8, "General", 150, "USA", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5168), "Stephen King's international bestselling - and highly acclaimed - novel, also a hugely successful film starring Tom Hanks", "5.12 x 7.80 x 1.22 inches", 1, "Drama", "English", 480, "StephenKing-The-Green-Mile.jpg", 23.98, 9, "Houghton Mifflin Harcourt", 3.5, "Free", 4, null, "The Green Mile", 1, 0.48999999999999999, new DateTime(2005, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1, "Agatha Christie", "Paper", "Paperback", 7, "Thrillers", 70, "UK", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5355), "When Alice Ascher is murdered in Andover, Hercule Poirot is already onto the clues. Alphabetically speaking, it's one down, 25 to go. This classic mystery is now repackaged in a digest-sized edition for young adults. Reissue.", "5.82 x 8.52 x 0.94 inches", 1, "Thriller", "English", 256, "AgathaCristie_TheABCMurders.jpg", 8.4800000000000004, 7, "Simon & Schuster", 3.5, "Free", 11, null, "The A.B.C. Murders", 1, 0.98999999999999999, new DateTime(2006, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, "Agatha Christie", "Paper", "Paperback", 7, "Thrillers", 300, "UK", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5347), "No description is available.", "5.82 x 8.52 x 0.94 inches", 1, "Thriller", "English", 256, "AgathaCristie_13_Problems.jpg", 17.48, 7, "Simon & Schuster", 3.5, "Free", 11, null, "The Thirteen Problems", 1, 0.34999999999999998, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, "William Shakespeare", "Paper", "Paperback", 5, "Drama", 65, "UK", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5200), "Shakespeare's tragedy about Othello the Moor is presented in this freshly edited text with full explanatory notes, scene-by-scene plot summaries, an Introduction to reading Shakespeare's language, and much more. Reissue.", "4.10 x 6.70 x 1.00 inches", 1, "Drama", "English", 368, "WilliamShakespeare_Othello.jpg", 5.9800000000000004, 7, "Simon & Schuster", 3.5, "Free", 18, null, "Othello", 1, 0.40000000000000002, new DateTime(2003, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "Stephen King", "Paper", "Paperback", 9, "Horror", 20, "USA", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5157), "Once upon a time, in the haunted city of Derry (site of the classics \"It\" and \"Insomnia),\" four boys stood together and did a brave thing. Certainly a good thing, perhaps even a great thing. Something that changed them in ways they could never begin to understand. Twenty - five years later, the boys are now men with separate lives and separate troubles. But the ties endure. Each hunting season the foursome reunite in the woods of Maine. This year, a stranger stumbles into their camp, disoriented, mumbling something about lights in the sky. His incoherent ravings prove to be dis - turbingly prescient.Before long, these men will be plunged into a horrifying struggle with a creature from another world. Their only chance of survival is locked in their shared past-- and in the Dreamcatcher.", "6.51 x 9.56 x 2.01 inches", 1, "Horror", "English", 624, "StephenKing_Dreamcatcher.jpg", 13.98, 7, "Simon & Schuster", 3.5, "Free", 3, null, "Dreamcatcher", 1, 2.2200000000000002, new DateTime(2020, 2, 29, 23, 29, 25, 0, DateTimeKind.Unspecified) },
                    { 18, 10, "Dan Brown", "Paper", "Paperback", 7, "Thrillers", 100, "USA", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5339), "#1 WORLDWIDE BESTSELLER Harvard professor of symbology Robert Langdon awakens in an Italian hospital, disoriented and with no recollection of the past thirty-six hours, including the origin of the macabre object hidden in his belongings. With a relentless female assassin trailing them through Florence, he and his resourceful doctor, Sienna Brooks, are forced to flee. Embarking on a harrowing journey, they must unravel a series of codes, which are the work of a brilliant scientist whose obsession with the end of the world is matched only by his passion for one of the most influential masterpieces ever written, Dante Alighieri's \"The Inferno.\" Dan Brown has raised the bar yet again, combining classical Italian art, history, and literature with cutting-edge science in this sumptuously entertaining thriller.", "4.28 x 7.54 x 1.33 inches", 1, "Thriller", "English", 648, "Dan-Brown_Inferno.jpg", 5.9800000000000004, 6, "Macmillan Publishers", 3.5, "Free", 11, null, "Inferno", 1, 0.5, new DateTime(2014, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 10, "Dan Brown", "Paper", "Paperback", 7, "Thrillers", 111, "USA", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5331), "PREMIUM MASS MARKET EDITION #1 Worldwide Bestseller--More Than 80 Million Copies Sold As millions of readers around the globe have already discovered, The Da Vinci Code is a reading experience unlike any other.Simultaneously lightning - paced, intelligent,and intricately layered with remarkable research and detail, Dan Brown's novel is a thrilling masterpiece--from its opening pages to its stunning conclusion.", "4.28 x 7.54 x 1.33 inches", 2, "Thriller", "English", 608, "Dan-Brown_The-Da-Vinci-Code.jpg", 12.98, 6, "Macmillan Publishers", 3.5, "Free", 12, null, "The Da Vinci Code", 1, 0.48999999999999999, new DateTime(2009, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 6, "Paulo Coelho", "Paper", "Paperback", 1, "Fiction", 34, "USA", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5223), "This gripping and daring novel by the author of the bestselling \"The Alchemist\" sensitively explores the sacred nature of sex and love. \"Sensual. . . for-adults - only fairytale.\"--\"Washington Post.\"", "5.32 x 8.04 x 0.77 inches", 1, "Fiction", "English", 320, "PauloCoelho_Eleven-Minutes.jpg", 12.48, 5, "HarperCollins", 3.5, "Free", 8, null, "Eleven Minutes", 1, 0.52000000000000002, new DateTime(2005, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, "Stephen King", "Paper", "Paperback", 9, "Horror", 230, "USA", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5193), "Now repackaged with stunning new cover art, this #1 bestseller is a chilling story set in a lonely Nevada town where the evil embedded in the landscape is awesome--but so are the forces summoned to combat it. Reissue", "4.22 x 6.86 x 1.52 inches", 1, "Horror", "English", 547, "StephenKing_Desperation.jpg", 22.98, 10, "Pearson Education", 3.5, "Free", 7, null, "Desperation", 1, 0.48999999999999999, new DateTime(2003, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, "Stephen King", "Paper", "Paperback", 7, "Thrillers", 40, "USA", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5184), "Evil forces try to destroy a boy with psychic powers.", "6.44 x 9.42 x 1.46 inches", 1, "Thriller", "English", 450, "StephenKing_The-Shining.jpg", 33.479999999999997, 5, "HarperCollins", 3.5, "Free", 6, null, "The Shining", 1, 1.6799999999999999, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 9, "Nicholas Sparks", "Paper", "Paperback", 1, "Fiction", 44, "UK", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5322), "#1 bestselling author Nicholas Sparks's new novel is at once a compelling family drama and a heartrending tale of young love.Seventeen year old Veronica \"Ronnie\" Miller's life was turned upside-down when her parents divorced and her father moved from New York City to Wilmington, North Carolina. Three years later, she remains angry and alientated from her parents, especially her father...until her mother decides it would be in everyone's best interest if she spent the summer in Wilmington with him. Ronnie's father, a former concert pianist and teacher, is living a quiet life in the beach town, immersed in creating a work of art that will become the centerpiece of a local church.The tale that unfolds is an unforgettable story of love on many levels--first love, love between parents and children -- that demonstrates, as only a Nicholas Sparks novel can, the many ways that love can break our hearts...and heal them.", "4.10 x 6.70 x 1.00 inches", 1, "Romance", "English", 463, "NicolasSparks_The-Last-Song.jpg", 8.9800000000000004, 4, "Hachette Livre", 3.5, "Free", 10, null, "The Last Song", 1, 0.5, new DateTime(2010, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 9, "Nicholas Sparks", "Paper", "Paperback", 1, "Fiction", 37, "UK", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5312), "No description is available.", "4.10 x 6.70 x 1.00 inches", 1, "Romance", "English", 463, "NicolasSparks_Every13Breath.jpg", 8.9800000000000004, 4, "Hachette Livre", 3.5, "Free", 13, null, "Every Breath", 1, 0.5, new DateTime(2010, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 7, "Jeffrey Archer", "Paper", "Paperback", 1, "Fiction", 87, "USA", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5231), "Jeffrey Archer's mesmerizing saga of the Clifton and Barrington families continues... 1945, London. The vote in the House of Lords as to who should inherit the Barrington family fortune has ended in a tie. The Lord Chancellor's deciding vote will cast a long shadow on the lives of Harry Clifton and Giles Barrington. Harry returns to America to promote his latest novel, while his beloved Emma goes in search of the little girl who was found abandoned in her father's office on the night he was killed. When the general election is called, Giles Barrington has to defend his seat in the House of Commons and is horrified to discover who the Conservatives select to stand against him. But it is Sebastian Clifton, Harry and Emma's son, who ultimately influences his uncle's fate. In 1957, Sebastian wins a scholarship to Cambridge, and a new generation of the Clifton family marches onto the page. But after Sebastian is expelled from school, he unwittingly becomes caught up in an international art fraud involving a Rodin statue that is worth far more than the sum it raises at auction. Does he become a millionaire? Does he go to Cambridge? Is his life in danger?", "4.32 x 6.04 x 0.57 inches", 1, "Fiction", "English", 423, "ArcherJeffrey-Best-Kept-Secret.jpg", 14.48, 4, "Hachette Livre", 3.5, "Free", 9, null, "Best Kept Secret (The Clifton Chronicles)", 1, 0.56999999999999995, new DateTime(2014, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 8, "Ian Fleming", "Paper", "Paperback", 2, "Action", 10, "UK", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5246), "The lethal SMERSH organization in Russia has targeted Agent 007 for elimination. But when James Bond allows himself to be lured to Istanbul and walks willingly into a trap, a game of cross and double-cross ensues, with Bond as both the stakes and the prize.", "5.12 x 7.72 x 0.53 inches", 1, "Action", "English", 272, "IanFleming_From-Russia-with-Love.jpg", 6.4800000000000004, 3, "Penguin Random House", 3.5, "Free", 14, null, "From Russia with Love", 1, 0.41999999999999998, new DateTime(2002, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 8, "Ian Fleming", "Paper", "Paperback", 2, "Action", 122, "UK", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5238), "In the novel that introduced James Bond to the world, Ian Fleming's agent 007 is dispatched to a French casino in Royale-les-Eaux. His mission? Bankrupt a ruthless Russian agent who's been on a bad luck streak at the baccarat table. One of SMERSH's most deadly operatives, the man known only as ?Le Chiffre, ? has been a prime target of the British Secret Service for years. If Bond can wipe out his bankroll, Le Chiffre will likely be ?retired? by his paymasters in Moscow. But what if the cards won't cooperate? After a brutal night at the gaming tables, Bond soon finds himself dodging would-be assassins, fighting off brutal torturers, and going all-in to save the life of his beautiful female counterpart, Vesper Lynd. Taut, tense, and effortlessly stylish, Ian Fleming's inaugural James Bond adventure has all the hallmarks that made the series a touchstone for a generation of readers.", "4.32 x 6.04 x 0.57 inches", 1, "Action", "English", 486, "IanFlemming_Casino_Royale.jpg", 13.48, 3, "Penguin Random House", 3.5, "Free", 15, null, "Casino Royale", 1, 0.29999999999999999, new DateTime(2012, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Stephen King", "Paper", "Paperback", 6, "Fantasy", 50, "", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5098), "Now a major motion picture starring Matthew McConaughey and Idris Elba. An impressive work of mythic magnitude that may turn out to be Stephen King's greatest literary achievement (The Atlanta Journal-Constitution), The Gunslinger is the first volume in the epic Dark Tower Series. A #1 national bestseller, The Gunslinger introduces readers to one of Stephen King's most powerful creations, Roland of Gilead: The Last Gunslinger. He is a haunting figure, a loner on a spellbinding journey into good and evil. In his desolate world, which mirrors our own in frightening ways, Roland tracks The Man in Black, encounters an enticing woman named Alice, and begins a friendship with the boy from New York named Jake. Inspired in part by the Robert Browning narrative poem,Childe Roland to the Dark Tower Came, The Gunslinger is a compelling whirlpool of a story that draws one irretrievable to its center ( Milwaukee Sentinel ). It is brilliant and fresh...and will leave you panting for more ( Booklist ).", "Not known", 1, "Fantasy", "English", 586, "StephenKing_The_Dark_Tower.jpg", 11.48, 2, "Scholastic", 3.5, "Free", 19, null, "The Dark Tower I: The Gunslinger", 1, 0.59999999999999998, new DateTime(2017, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 6, "Paulo Coelho", "Paper", "Paperback", 1, "Fiction", 222, "UK", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5214), "This international bestseller about the shepherd boy Santiago who learns how to live his dreams includes an inspiring afterword by the author.", "5.36 x 8.02 x 0.56 inches", 1, "Fiction", "English", 197, "PauloCoelho_The-Alchemist.jpg", 6.9800000000000004, 1, "William Morrow Paperbacks", 3.5, "Free", 16, null, "The Alchemist", 1, 0.48999999999999999, new DateTime(2006, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 4, "J. K. Rowling", "Paper", "Paperback", 1, "Fiction", 131, "UK", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5207), "The one that started the biggest publishing phenomenon of our time", "4.45 x 7.01 x 0.87 inches", 1, "Fiction", "English", 336, "Harry-Potter-and-the-Philosopher-s-Stone-Rowling-J-K.jpg", 9.9800000000000004, 1, "William Morrow Paperbacks", 3.5, "Free", 17, null, "Harry Potter and the Philosopher's Stone", 1, 0.34999999999999998, new DateTime(2004, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, "Stephen King", "Paper", "Paperback", 9, "Horror", 200, "USA", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(5175), "Old Ralph Roberts hasn't been sleeping well lately. Every night he wakes just a little bit earlier, and pretty soon, he thinks, he won't get any sleep at all. It wouldn't be so bad, except for the strange hallucinations he's been having. Or, at least, he hopes they are hallucinations--because here in Derry, one never can tell. Part of the \"Books That Take You Anywhere You Want To Go\" Summer Reading Promotion.", "4.21 x 6.93 x 1.51 inches", 1, "Horror", "English", 663, "StephenKing_Insomnia.jpg", 12.98, 5, "HarperCollins", 3.5, "Free", 5, null, "Insomnia", 1, 0.69999999999999996, new DateTime(1995, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, "Agatha Cristie", "Paper", "Paperback", 1, "Fiction", 100, "UK", new DateTime(2021, 5, 10, 20, 37, 4, 874, DateTimeKind.Local).AddTicks(1935), "Book seed 1 Description", "12x12x20", 1, "Fiction", "English", 586, "AgathaCristie_MurderOnTheOrientExpress.jpg", 9.9900000000000002, 1, "William Morrow Paperbacks", 3.5, "Free", 20, null, "Murder On The Orient Express", 1, 0.48999999999999999, new DateTime(2020, 2, 29, 23, 29, 25, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryID",
                table: "Books",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherID",
                table: "Books",
                column: "PublisherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
