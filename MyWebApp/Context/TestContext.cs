using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;
using System.Collections.Generic;

namespace MyWebApp.Context
{
    public class TestContext : DbContext
    {
        protected TestContext()
        {
        }
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(new List<Book>
            {
                new Book()
                {
                    AuthorId = 1,
                    Id = 1,
                    Title = "Rok 2024"
                }
            });
            modelBuilder.Entity<Author>().HasData(new List<Author>
            {
                new Author()
                {
                    Id = 1,
                    Name = "Kowalski"
                }
            });
        }
    }
}