using Data.Books;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityFramework
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(18, 3);

            base.OnModelCreating(modelBuilder);

            // Seeding initial data
            SeedingBooks(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }

        #region Seeding
        private void SeedingBooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Epic Reads Book Club",
                    Author = "George Orwell",
                    Price = 10,
                    PublicationDate = DateTime.Now,
                },
                new Book
                {
                    Id = 2,
                    Title = "A Sarah Dessen",
                    Author = "John Green",
                    Price = 10,
                    PublicationDate = DateTime.Now,
                },
                new Book
                {
                    Id = 3,
                    Title = "Must-Read Teen Novel",
                    Author = "Melissa Pearl",
                    Price = 10,
                    PublicationDate = DateTime.Now,
                },
                new Book
                {
                    Id = 4,
                    Title = "Hunger for Dystopian",
                    Author = "Jeramey Kraatz",
                    Price = 10,
                    PublicationDate = DateTime.Now,
                },
                new Book
                {
                    Id = 5,
                    Title = "The John Green",
                    Author = "John Green",
                    Price = 10,
                    PublicationDate = DateTime.Now,
                });
        }
        #endregion
    }
}
