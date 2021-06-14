namespace Bookstore.Data
{
    using Bookstore.Entities;
    using Bookstore.Entities.Quotes;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        // *** have to tell the datacontext class about our models ***
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<QuoteMap> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // *************** DATA SEED:
            #region Admin and Roles
            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ID = ADMIN_ID;
            const string password = "Test123!";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                    Name = "editor",
                    NormalizedName = "EDITOR"
                },
                new IdentityRole
                {
                    Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                    Name = "guest",
                    NormalizedName = "GUEST"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Test@test.com",
                NormalizedUserName = "Test@TEST.COM",
                Email = "Test@test.com",
                NormalizedEmail = "TEST@TEst.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            #endregion

            #region Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction" },
                new Category { Id = 2, Name = "Action" },
                new Category { Id = 3, Name = "Crime" },
                new Category { Id = 4, Name = "Adventure" },
                new Category { Id = 5, Name = "Drama" },
                new Category { Id = 6, Name = "Fantasy" },
                new Category { Id = 7, Name = "Thriller" },
                new Category { Id = 8, Name = "General" },
                new Category { Id = 9, Name = "Horror" },
                new Category { Id = 10, Name = "Comedy" },
                new Category { Id = 11, Name = "Uncategorised" }
             );
            #endregion

            #region Author
            modelBuilder.Entity<Author>().HasData(
            new Author
            {
                Id = 1,
                Name = "Agatha Christie",
                ShortDescription = "Dame Agatha Mary Clarissa Christie, Lady Mallowan, DBE (née Miller; 15 September 1890 – 12 January 1976) " +
                   "was an English writer known for her 66 detective novels and 14 short story collections, particularly those revolving around " +
                   "fictional detectives Hercule Poirot and Miss Marple. She also wrote the world's longest-running play The Mousetrap and " +
                   "six romances under the pen name Mary Westmacott. In 1971, she was appointed a Dame Commander of the Order of the British Empire " +
                   "(DBE) for her contribution to literature",
                Popularity = false,
                Country = "Country1",
                Gender = "Female",
                DateBirth = DateTime.Now,
                Language = "English"
            },
                new Author
                {
                    Id = 2,
                    Name = "Stephen King",
                    ShortDescription = "Stephen Edwin King (born September 21, 1947) is an American author of horror, " +
                    "supernatural fiction, suspense, and fantasy novels. His books have sold more than 350 million copies, " +
                    "many of which have been adapted into feature films, miniseries, television series, and comic books. " +
                    "King has published 61 novels (including seven under the pen name Richard Bachman) and six non-fiction books. " +
                    "He has written approximately 200 short stories, most of which have been published in book collections.",
                    Popularity = true,
                    Country = "Country2",
                    Gender = "Male",
                    DateBirth = DateTime.Now,
                    Language = "English"
                },
                new Author
                {
                    Id = 3,
                    Name = "William Shakespeare",
                    ShortDescription = "William Shakespeare (bapt. 26 April 1564 – 23 April 1616) was an English poet, playwright, and actor, " +
                    "widely regarded as the greatest writer in the English language and the world's greatest dramatist. He is often called England's " +
                    "national poet and the \"Bard of Avon\" (or simply \"the Bard\"). His extant works, including collaborations, consist of some " +
                    "39 plays, 154 sonnets, two long narrative poems, and a few other verses, some of uncertain authorship. " +
                    "His plays have been translated into every major living language and are performed more often than those of any other playwright",
                    Popularity = false,
                    Country = "Country3",
                    Gender = "Male",
                    DateBirth = DateTime.Now,
                    Language = "English"
                },
                new Author
                {
                    Id = 4,
                    Name = "J. K. Rowling",
                    ShortDescription = "Joanne Rowling CH, OBE, HonFRSE, FRCPE, FRSL, (born 31 July 1965), better known by her pen name J. K. Rowling, " +
                    "is a British author, film producer, television producer, screenwriter, and philanthropist. She is best known for writing the Harry Potter fantasy series," +
                    "which has won multiple awards and sold more than 500 million copies, becoming the best-selling book series in history. The books are the basis of a popular " +
                    "film series, over which Rowling had overall approval on the scripts and was a producer on the final films. She also writes crime fiction under the name Robert Galbraith.",
                    Popularity = false,
                    Country = "Country4",
                    Gender = "Female",
                    DateBirth = DateTime.Now,
                    Language = "English"
                },
                new Author
                {
                    Id = 5,
                    Name = "Leo Tolstoy",
                    ShortDescription = "Count Lev Nikolayevich Tolstoy (9 September [O.S. 28 August] 1828 – 20 November [O.S. 7 November] 1910), usually referred to in English as Leo Tolstoy, " +
                    "was a Russian writer who is regarded as one of the greatest authors of all time. He received multiple nominations for the Nobel Prize in Literature every year " +
                    "from 1902 to 1906, and nominations for Nobel Peace Prize in 1901, 1902 and 1910, and the fact that he never won is a major Nobel prize controversy",
                    Popularity = false,
                    Country = "Country5",
                    Gender = "Male",
                    DateBirth = DateTime.Now,
                    Language = "English"
                },
                new Author
                {
                    Id = 6,
                    Name = "Paulo Coelho",
                    ShortDescription = "Paulo Coelho de Souza (born 24 August 1947) is a Brazilian lyricist and novelist, best known for his novel The Alchemist. " +
                    "In 2014, he uploaded his personal papers online to create a virtual Paulo Coelho Foundation",
                    Popularity = false,
                    Country = "Country6",
                    Gender = "Male",
                    DateBirth = DateTime.Now,
                    Language = "English"
                },
                new Author
                {
                    Id = 7,
                    Name = "Jeffrey Archer",
                    ShortDescription = "Jeffrey Howard Archer (born 15 April 1940) is an English novelist, former politician, convicted perjurer, and peer of the realm. " +
                    "Before becoming an author,Archer was a Member of Parliament(1969–1974), but did not seek re - election after a financial scandal that left him almost bankrupt." +
                    "He revived his fortunes as a best - selling novelist; his books have sold around 330 million copies worldwide",
                    Popularity = false,
                    Country = "Country7",
                    Gender = "Male",
                    DateBirth = DateTime.Now,
                    Language = "English"
                },
                new Author
                {
                    Id = 8,
                    Name = "Ian Fleming",
                    ShortDescription = "Ian Lancaster Fleming (28 May 1908 – 12 August 1964) was an English author, journalist and naval intelligence officer who is best known " +
                    "for his James Bond series of spy novels. Fleming came from a wealthy family connected to the merchant bank Robert Fleming & Co., and his father was the " +
                    "Member of Parliament for Henley from 1910 until his death on the Western Front in 1917. Educated at Eton, Sandhurst and, briefly, the universities of Munich and Geneva, " +
                    "Fleming moved through several jobs before he started writing.",
                    Popularity = false,
                    Country = "Country8",
                    Gender = "Male",
                    DateBirth = DateTime.Now,
                    Language = "English"
                },
                new Author
                {
                    Id = 9,
                    Name = "Nicholas Sparks",
                    ShortDescription = "Nicholas Charles Sparks (born December 31, 1965) is an American romance novelist and screenwriter. " +
                    "He has published twenty novels and two non-fiction books. Several of his novels have become international bestsellers, " +
                    "and eleven of his romantic-drama novels have been adapted to film all with multimillion-dollar box office grosses." +
                    "His novels feature stories of tragic love with happy endings.",
                    Popularity = false,
                    Country = "Country9",
                    Gender = "Male",
                    DateBirth = DateTime.Now,
                    Language = "English"
                },
                new Author
                {
                    Id = 10,
                    Name = "Dan Brown",
                    ShortDescription = "Daniel Gerhard Brown (born June 22, 1964) is an American author best known for his thriller novels," +
                    " including the Robert Langdon novels Angels & Demons (2000), The Da Vinci Code (2003), The Lost Symbol (2009), Inferno (2013) and Origin (2017). " +
                    "His novels are treasure hunts that usually take place over a period of 24 hours.[2] They feature recurring themes of cryptography, art, " +
                    "and conspiracy theories. His books have been translated into 57 languages and, as of 2012, have sold over 200 million copies. " +
                    "Three of them, Angels & Demons, The Da Vinci Code, and Inferno, have been adapted into films.",
                    Popularity = false,
                    Country = "Country10",
                    Gender = "Male",
                    DateBirth = DateTime.Now,
                    Language = "English"
                }
            );
            #endregion

            #region Publihser
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "William Morrow Paperbacks",
                    Country = "Ireland",
                    Year = "2020"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Scholastic",
                    Country = "USA",
                    Year = "2020"
                },
                new Publisher
                {
                    Id = 3,
                    Name = "Penguin Random House",
                    Country = "Not known",
                    Year = "2020"
                },
                new Publisher
                {
                    Id = 4,
                    Name = "Hachette Livre",
                    Country = "France",
                    Year = "2020"
                },
                new Publisher
                {
                    Id = 5,
                    Name = "HarperCollins",
                    Country = "USA",
                    Year = "2020"
                },
                new Publisher
                {
                    Id = 6,
                    Name = "Macmillan Publishers",
                    Country = "Germany",
                    Year = "2020"
                },
                new Publisher
                {
                    Id = 7,
                    Name = "Simon & Schuster",
                    Country = "USA",
                    Year = "2020"
                },
                new Publisher
                {
                    Id = 8,
                    Name = "McGraw-Hill Education",
                    Country = "USA",
                    Year = "2020"
                },
                new Publisher
                {
                    Id = 9,
                    Name = "Houghton Mifflin Harcourt",
                    Country = "USA",
                    Year = "2020"
                },
                new Publisher
                {
                    Id = 10,
                    Name = "Pearson Education",
                    Country = "USA",
                    Year = "2020"
                }
            );
            #endregion

            #region Books
            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   Id = 1,
                   Title = "Murder On The Orient Express",
                   AuthorID = 1,
                   AuthorName = "Agatha Cristie",
                   BookType = "Paperback",
                   CategoryID = 1,
                   CategoryName = "Fiction",
                   Copies = 100,
                   Country = "UK",
                   Description = "Book seed 1 Description",
                   Dimensions = "12x12x20",
                   Genre = "Fiction",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 586,
                   Price = 9.99,
                   PublisherID = 1,
                   PublisherName = "William Morrow Paperbacks",
                   Shipping = "Free",
                   Weight = 0.49,
                   YearOfIssue = new DateTime(2020, 02, 29, 23, 29, 25),
                   PhotoURL = "AgathaCristie_MurderOnTheOrientExpress.jpg",
                   SoldItems = 20,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 2,
                   Title = "The Dark Tower I: The Gunslinger",
                   AuthorID = 2,
                   AuthorName = "Stephen King",
                   BookType = "Paperback",
                   CategoryID = 6,
                   CategoryName = "Fantasy",
                   Copies = 50,
                   Country = "",
                   Description = "Now a major motion picture starring Matthew McConaughey and Idris Elba. " +
                   "An impressive work of mythic magnitude that may turn out to be Stephen King's greatest literary " +
                   "achievement (The Atlanta Journal-Constitution), The Gunslinger is the first volume in the epic Dark Tower Series. " +
                   "A #1 national bestseller, The Gunslinger introduces readers to one of Stephen King's most powerful creations, " +
                   "Roland of Gilead: The Last Gunslinger. He is a haunting figure, a loner on a spellbinding journey into good and evil. " +
                   "In his desolate world, which mirrors our own in frightening ways, Roland tracks The Man in Black, encounters an enticing " +
                   "woman named Alice, and begins a friendship with the boy from New York named Jake. Inspired in part by the Robert Browning narrative poem," +
                   "Childe Roland to the Dark Tower Came, The Gunslinger is a compelling whirlpool of a story that draws one irretrievable to its center ( Milwaukee Sentinel ). " +
                   "It is brilliant and fresh...and will leave you panting for more ( Booklist ).",
                   Dimensions = "Not known",
                   Genre = "Fantasy",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 586,
                   Price = 11.48,
                   PublisherID = 2,
                   PublisherName = "Scholastic",
                   Shipping = "Free",
                   Weight = 0.60,
                   YearOfIssue = new DateTime(2017, 06, 13, 00, 00, 00),
                   PhotoURL = "StephenKing_The_Dark_Tower.jpg",
                   SoldItems = 19,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 3,
                   Title = "Dreamcatcher",
                   AuthorID = 2,
                   AuthorName = "Stephen King",
                   BookType = "Paperback",
                   CategoryID = 9,
                   CategoryName = "Horror",
                   Copies = 20,
                   Country = "USA",
                   Description = "Once upon a time, in the haunted city of Derry (site of the classics \"It\" and \"Insomnia),\" four boys stood together " +
                   "and did a brave thing. Certainly a good thing, perhaps even a great thing. Something that changed them in ways they could never begin to understand. " +
                   "Twenty - five years later, the boys are now men with separate lives and separate troubles. But the ties endure. " +
                   "Each hunting season the foursome reunite in the woods of Maine. This year, a stranger stumbles into their camp, disoriented, " +
                   "mumbling something about lights in the sky. His incoherent ravings prove to be dis - turbingly prescient.Before long, these men will be plunged into a " +
                   "horrifying struggle with a creature from another world. Their only chance of survival is locked in their shared past-- and in the Dreamcatcher.",
                   Dimensions = "6.51 x 9.56 x 2.01 inches",
                   Genre = "Horror",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 624,
                   Price = 13.98,
                   PublisherID = 7,
                   PublisherName = "Simon & Schuster",
                   Shipping = "Free",
                   Weight = 2.22,
                   YearOfIssue = new DateTime(2020, 02, 29, 23, 29, 25),
                   PhotoURL = "StephenKing_Dreamcatcher.jpg",
                   SoldItems = 3,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 4,
                   Title = "The Green Mile",
                   AuthorID = 2,
                   AuthorName = "Stephen King",
                   BookType = "Paperback",
                   CategoryID = 8,
                   CategoryName = "General",
                   Copies = 150,
                   Country = "USA",
                   Description = "Stephen King's international bestselling - and highly acclaimed - novel, also a hugely successful film starring Tom Hanks",
                   Dimensions = "5.12 x 7.80 x 1.22 inches",
                   Genre = "Drama",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 480,
                   Price = 23.98,
                   PublisherID = 9,
                   PublisherName = "Houghton Mifflin Harcourt",
                   Shipping = "Free",
                   Weight = 0.49,
                   YearOfIssue = new DateTime(2005, 03, 24, 00, 00, 00),
                   PhotoURL = "StephenKing-The-Green-Mile.jpg",
                   SoldItems = 4,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 5,
                   Title = "Insomnia",
                   AuthorID = 2,
                   AuthorName = "Stephen King",
                   BookType = "Paperback",
                   CategoryID = 9,
                   CategoryName = "Horror",
                   Copies = 200,
                   Country = "USA",
                   Description = "Old Ralph Roberts hasn't been sleeping well lately. Every night he wakes just a little bit earlier, and pretty soon, he thinks, " +
                   "he won't get any sleep at all. It wouldn't be so bad, except for the strange hallucinations he's been having. " +
                   "Or, at least, he hopes they are hallucinations--because here in Derry, one never can tell. Part of the \"Books That Take You Anywhere You Want To Go\" " +
                   "Summer Reading Promotion.",
                   Dimensions = "4.21 x 6.93 x 1.51 inches",
                   Genre = "Horror",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 663,
                   Price = 12.98,
                   PublisherID = 5,
                   PublisherName = "HarperCollins",
                   Shipping = "Free",
                   Weight = 0.70,
                   YearOfIssue = new DateTime(1995, 09, 01, 00, 00, 00),
                   PhotoURL = "StephenKing_Insomnia.jpg",
                   SoldItems = 5,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 6,
                   Title = "The Shining",
                   AuthorID = 2,
                   AuthorName = "Stephen King",
                   BookType = "Paperback",
                   CategoryID = 7,
                   CategoryName = "Thrillers",
                   Copies = 40,
                   Country = "USA",
                   Description = "Evil forces try to destroy a boy with psychic powers.",
                   Dimensions = "6.44 x 9.42 x 1.46 inches",
                   Genre = "Thriller",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 450,
                   Price = 33.48,
                   PublisherID = 5,
                   PublisherName = "HarperCollins",
                   Shipping = "Free",
                   Weight = 1.68,
                   YearOfIssue = new DateTime(1990, 06, 01, 00, 00, 00),
                   PhotoURL = "StephenKing_The-Shining.jpg",
                   SoldItems = 6,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 7,
                   Title = "Desperation",
                   AuthorID = 2,
                   AuthorName = "Stephen King",
                   BookType = "Paperback",
                   CategoryID = 9,
                   CategoryName = "Horror",
                   Copies = 230,
                   Country = "USA",
                   Description = "Now repackaged with stunning new cover art, this #1 bestseller is a chilling story set in a lonely Nevada town " +
                   "where the evil embedded in the landscape is awesome--but so are the forces summoned to combat it. Reissue",
                   Dimensions = "4.22 x 6.86 x 1.52 inches",
                   Genre = "Horror",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 547,
                   Price = 22.98,
                   PublisherID = 10,
                   PublisherName = "Pearson Education",
                   Shipping = "Free",
                   Weight = 0.49,
                   YearOfIssue = new DateTime(2003, 04, 01, 00, 00, 00),
                   PhotoURL = "StephenKing_Desperation.jpg",
                   SoldItems = 7,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 8,
                   Title = "Othello",
                   AuthorID = 3,
                   AuthorName = "William Shakespeare",
                   BookType = "Paperback",
                   CategoryID = 5,
                   CategoryName = "Drama",
                   Copies = 65,
                   Country = "UK",
                   Description = "Shakespeare's tragedy about Othello the Moor is presented in this freshly edited text with full explanatory notes, " +
                   "scene-by-scene plot summaries, an Introduction to reading Shakespeare's language, and much more. Reissue.",
                   Dimensions = "4.10 x 6.70 x 1.00 inches",
                   Genre = "Drama",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 368,
                   Price = 5.98,
                   PublisherID = 7,
                   PublisherName = "Simon & Schuster",
                   Shipping = "Free",
                   Weight = 0.40,
                   YearOfIssue = new DateTime(2003, 12, 23, 00, 00, 00),
                   PhotoURL = "WilliamShakespeare_Othello.jpg",
                   SoldItems = 18,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 9,
                   Title = "Harry Potter and the Philosopher's Stone",
                   AuthorID = 4,
                   AuthorName = "J. K. Rowling",
                   BookType = "Paperback",
                   CategoryID = 1,
                   CategoryName = "Fiction",
                   Copies = 131,
                   Country = "UK",
                   Description = "The one that started the biggest publishing phenomenon of our time",
                   Dimensions = "4.45 x 7.01 x 0.87 inches",
                   Genre = "Fiction",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 336,
                   Price = 9.98,
                   PublisherID = 1,
                   PublisherName = "William Morrow Paperbacks",
                   Shipping = "Free",
                   Weight = 0.35,
                   YearOfIssue = new DateTime(2004, 07, 10, 00, 00, 00),
                   PhotoURL = "Harry-Potter-and-the-Philosopher-s-Stone-Rowling-J-K.jpg",
                   SoldItems = 17,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 10,
                   Title = "The Alchemist",
                   AuthorID = 6,
                   AuthorName = "Paulo Coelho",
                   BookType = "Paperback",
                   CategoryID = 1,
                   CategoryName = "Fiction",
                   Copies = 222,
                   Country = "UK",
                   Description = "This international bestseller about the shepherd boy Santiago who learns how to live " +
                   "his dreams includes an inspiring afterword by the author.",
                   Dimensions = "5.36 x 8.02 x 0.56 inches",
                   Genre = "Fiction",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 197,
                   Price = 6.98,
                   PublisherID = 1,
                   PublisherName = "William Morrow Paperbacks",
                   Shipping = "Free",
                   Weight = 0.49,
                   YearOfIssue = new DateTime(2006, 04, 25, 00, 00, 00),
                   PhotoURL = "PauloCoelho_The-Alchemist.jpg",
                   SoldItems = 16,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 11,
                   Title = "Eleven Minutes",
                   AuthorID = 6,
                   AuthorName = "Paulo Coelho",
                   BookType = "Paperback",
                   CategoryID = 1,
                   CategoryName = "Fiction",
                   Copies = 34,
                   Country = "USA",
                   Description = "This gripping and daring novel by the author of the bestselling \"The Alchemist\" sensitively " +
                   "explores the sacred nature of sex and love. \"Sensual. . . for-adults - only fairytale.\"--\"Washington Post.\"",
                   Dimensions = "5.32 x 8.04 x 0.77 inches",
                   Genre = "Fiction",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 320,
                   Price = 12.48,
                   PublisherID = 5,
                   PublisherName = "HarperCollins",
                   Shipping = "Free",
                   Weight = 0.52,
                   YearOfIssue = new DateTime(2005, 03, 29, 00, 00, 00),
                   PhotoURL = "PauloCoelho_Eleven-Minutes.jpg",
                   SoldItems = 8,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 12,
                   Title = "Best Kept Secret (The Clifton Chronicles)",
                   AuthorID = 7,
                   AuthorName = "Jeffrey Archer",
                   BookType = "Paperback",
                   CategoryID = 1,
                   CategoryName = "Fiction",
                   Copies = 87,
                   Country = "USA",
                   Description = "Jeffrey Archer's mesmerizing saga of the Clifton and Barrington families continues... " +
                   "1945, London. The vote in the House of Lords as to who should inherit the Barrington family fortune has " +
                   "ended in a tie. The Lord Chancellor's deciding vote will cast a long shadow on the lives of Harry Clifton " +
                   "and Giles Barrington. Harry returns to America to promote his latest novel, while his beloved Emma goes in " +
                   "search of the little girl who was found abandoned in her father's office on the night he was killed. " +
                   "When the general election is called, Giles Barrington has to defend his seat in the House of Commons and " +
                   "is horrified to discover who the Conservatives select to stand against him. But it is Sebastian Clifton, " +
                   "Harry and Emma's son, who ultimately influences his uncle's fate. In 1957, Sebastian wins a scholarship to " +
                   "Cambridge, and a new generation of the Clifton family marches onto the page. But after Sebastian is expelled " +
                   "from school, he unwittingly becomes caught up in an international art fraud involving a Rodin statue that is " +
                   "worth far more than the sum it raises at auction. Does he become a millionaire? Does he go to Cambridge? " +
                   "Is his life in danger?",
                   Dimensions = "4.32 x 6.04 x 0.57 inches",
                   Genre = "Fiction",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 423,
                   Price = 14.48,
                   PublisherID = 4,
                   PublisherName = "Hachette Livre",
                   Shipping = "Free",
                   Weight = 0.57,
                   YearOfIssue = new DateTime(2014, 02, 18, 00, 00, 00),
                   PhotoURL = "ArcherJeffrey-Best-Kept-Secret.jpg",
                   SoldItems = 9,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 13,
                   Title = "Casino Royale",
                   AuthorID = 8,
                   AuthorName = "Ian Fleming",
                   BookType = "Paperback",
                   CategoryID = 2,
                   CategoryName = "Action",
                   Copies = 122,
                   Country = "UK",
                   Description = "In the novel that introduced James Bond to the world, Ian Fleming's agent 007 is dispatched to " +
                   "a French casino in Royale-les-Eaux. His mission? Bankrupt a ruthless Russian agent who's been on a bad luck streak " +
                   "at the baccarat table. One of SMERSH's most deadly operatives, the man known only as ?Le Chiffre, ? has been a prime " +
                   "target of the British Secret Service for years. If Bond can wipe out his bankroll, Le Chiffre will likely be ?retired? " +
                   "by his paymasters in Moscow. But what if the cards won't cooperate? After a brutal night at the gaming tables, " +
                   "Bond soon finds himself dodging would-be assassins, fighting off brutal torturers, and going all-in to save the life " +
                   "of his beautiful female counterpart, Vesper Lynd. Taut, tense, and effortlessly stylish, Ian Fleming's inaugural " +
                   "James Bond adventure has all the hallmarks that made the series a touchstone for a generation of readers.",
                   Dimensions = "4.32 x 6.04 x 0.57 inches",
                   Genre = "Action",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 486,
                   Price = 13.48,
                   PublisherID = 3,
                   PublisherName = "Penguin Random House",
                   Shipping = "Free",
                   Weight = 0.30,
                   YearOfIssue = new DateTime(2012, 10, 16, 00, 00, 00),
                   PhotoURL = "IanFlemming_Casino_Royale.jpg",
                   SoldItems = 15,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 14,
                   Title = "From Russia with Love",
                   AuthorID = 8,
                   AuthorName = "Ian Fleming",
                   BookType = "Paperback",
                   CategoryID = 2,
                   CategoryName = "Action",
                   Copies = 10,
                   Country = "UK",
                   Description = "The lethal SMERSH organization in Russia has targeted Agent 007 for elimination. " +
                   "But when James Bond allows himself to be lured to Istanbul and walks willingly into a trap, " +
                   "a game of cross and double-cross ensues, with Bond as both the stakes and the prize.",
                   Dimensions = "5.12 x 7.72 x 0.53 inches",
                   Genre = "Action",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 272,
                   Price = 6.48,
                   PublisherID = 3,
                   PublisherName = "Penguin Random House",
                   Shipping = "Free",
                   Weight = 0.42,
                   YearOfIssue = new DateTime(2002, 12, 31, 00, 00, 00),
                   PhotoURL = "IanFleming_From-Russia-with-Love.jpg",
                   SoldItems = 14,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 15,
                   Title = "Every Breath",
                   AuthorID = 9,
                   AuthorName = "Nicholas Sparks",
                   BookType = "Paperback",
                   CategoryID = 1,
                   CategoryName = "Fiction",
                   Copies = 37,
                   Country = "UK",
                   Description = "No description is available.",
                   Dimensions = "4.10 x 6.70 x 1.00 inches",
                   Genre = "Romance",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 463,
                   Price = 8.98,
                   PublisherID = 4,
                   PublisherName = "Hachette Livre",
                   Shipping = "Free",
                   Weight = 0.50,
                   YearOfIssue = new DateTime(2010, 03, 01, 00, 00, 00),
                   PhotoURL = "NicolasSparks_Every13Breath.jpg",
                   SoldItems = 13,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 16,
                   Title = "The Last Song",
                   AuthorID = 9,
                   AuthorName = "Nicholas Sparks",
                   BookType = "Paperback",
                   CategoryID = 1,
                   CategoryName = "Fiction",
                   Copies = 44,
                   Country = "UK",
                   Description = "#1 bestselling author Nicholas Sparks's new novel is at once a compelling family drama and a heartrending " +
                   "tale of young love.Seventeen year old Veronica \"Ronnie\" Miller's life was turned upside-down when her parents divorced " +
                   "and her father moved from New York City to Wilmington, North Carolina. Three years later, she remains angry and alientated " +
                   "from her parents, especially her father...until her mother decides it would be in everyone's best interest if she spent " +
                   "the summer in Wilmington with him. Ronnie's father, a former concert pianist and teacher, is living a quiet life in the " +
                   "beach town, immersed in creating a work of art that will become the centerpiece of a local church.The tale that unfolds is " +
                   "an unforgettable story of love on many levels--first love, love between parents and children -- that demonstrates, " +
                   "as only a Nicholas Sparks novel can, the many ways that love can break our hearts...and heal them.",
                   Dimensions = "4.10 x 6.70 x 1.00 inches",
                   Genre = "Romance",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 463,
                   Price = 8.98,
                   PublisherID = 4,
                   PublisherName = "Hachette Livre",
                   Shipping = "Free",
                   Weight = 0.50,
                   YearOfIssue = new DateTime(2010, 03, 01, 00, 00, 00),
                   PhotoURL = "NicolasSparks_The-Last-Song.jpg",
                   SoldItems = 10,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 17,
                   Title = "The Da Vinci Code",
                   AuthorID = 10,
                   AuthorName = "Dan Brown",
                   BookType = "Paperback",
                   CategoryID = 7,
                   CategoryName = "Thrillers",
                   Copies = 111,
                   Country = "USA",
                   Description = "PREMIUM MASS MARKET EDITION #1 Worldwide Bestseller" +
                   "--More Than 80 Million Copies Sold As millions of readers around the globe have already discovered, " +
                   "The Da Vinci Code is a reading experience unlike any other.Simultaneously lightning - paced, intelligent," +
                   "and intricately layered with remarkable research and detail, Dan Brown's novel is a thrilling masterpiece" +
                   "--from its opening pages to its stunning conclusion.",
                   Dimensions = "4.28 x 7.54 x 1.33 inches",
                   Genre = "Thriller",
                   Edition = 2,
                   Language = "English",
                   NumberOfPages = 608,
                   Price = 12.98,
                   PublisherID = 6,
                   PublisherName = "Macmillan Publishers",
                   Shipping = "Free",
                   Weight = 0.49,
                   YearOfIssue = new DateTime(2009, 03, 31, 00, 00, 00),
                   PhotoURL = "Dan-Brown_The-Da-Vinci-Code.jpg",
                   SoldItems = 12,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 18,
                   Title = "Inferno",
                   AuthorID = 10,
                   AuthorName = "Dan Brown",
                   BookType = "Paperback",
                   CategoryID = 7,
                   CategoryName = "Thrillers",
                   Copies = 100,
                   Country = "USA",
                   Description = "#1 WORLDWIDE BESTSELLER Harvard professor of symbology Robert Langdon awakens in an Italian hospital, " +
                   "disoriented and with no recollection of the past thirty-six hours, including the origin of the macabre object hidden " +
                   "in his belongings. With a relentless female assassin trailing them through Florence, he and his resourceful doctor, " +
                   "Sienna Brooks, are forced to flee. Embarking on a harrowing journey, they must unravel a series of codes, which are " +
                   "the work of a brilliant scientist whose obsession with the end of the world is matched only by his passion for one of the " +
                   "most influential masterpieces ever written, Dante Alighieri's \"The Inferno.\" Dan Brown has raised the bar yet again, " +
                   "combining classical Italian art, history, and literature with cutting-edge science in this sumptuously entertaining thriller.",
                   Dimensions = "4.28 x 7.54 x 1.33 inches",
                   Genre = "Thriller",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 648,
                   Price = 5.98,
                   PublisherID = 6,
                   PublisherName = "Macmillan Publishers",
                   Shipping = "Free",
                   Weight = 0.50,
                   YearOfIssue = new DateTime(2014, 06, 06, 00, 00, 00),
                   PhotoURL = "Dan-Brown_Inferno.jpg",
                   SoldItems = 11,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 19,
                   Title = "The Thirteen Problems",
                   AuthorID = 1,
                   AuthorName = "Agatha Christie",
                   BookType = "Paperback",
                   CategoryID = 7,
                   CategoryName = "Thrillers",
                   Copies = 300,
                   Country = "UK",
                   Description = "No description is available.",
                   Dimensions = "5.82 x 8.52 x 0.94 inches",
                   Genre = "Thriller",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 256,
                   Price = 17.48,
                   PublisherID = 7,
                   PublisherName = "Simon & Schuster",
                   Shipping = "Free",
                   Weight = 0.35,
                   YearOfIssue = new DateTime(2016, 01, 01, 00, 00, 00),
                   PhotoURL = "AgathaCristie_13_Problems.jpg",
                   SoldItems = 11,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               },
               new Book
               {
                   Id = 20,
                   Title = "The A.B.C. Murders",
                   AuthorID = 1,
                   AuthorName = "Agatha Christie",
                   BookType = "Paperback",
                   CategoryID = 7,
                   CategoryName = "Thrillers",
                   Copies = 70,
                   Country = "UK",
                   Description = "When Alice Ascher is murdered in Andover, Hercule Poirot is already onto the clues. " +
                   "Alphabetically speaking, it's one down, 25 to go. This classic mystery is now repackaged in a digest-sized " +
                   "edition for young adults. Reissue.",
                   Dimensions = "5.82 x 8.52 x 0.94 inches",
                   Genre = "Thriller",
                   Edition = 1,
                   Language = "English",
                   NumberOfPages = 256,
                   Price = 8.48,
                   PublisherID = 7,
                   PublisherName = "Simon & Schuster",
                   Shipping = "Free",
                   Weight = 0.99,
                   YearOfIssue = new DateTime(2006, 09, 30, 00, 00, 00),
                   PhotoURL = "AgathaCristie_TheABCMurders.jpg",
                   SoldItems = 11,
                   DateAdded = DateTime.Now,
                   Rating = 3.5,
                   BookCoverType = "Paper",
                   UserId = 1
               }
            );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
