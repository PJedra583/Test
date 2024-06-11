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
        
        public DbSet<Item> items { get; set; }
        public DbSet<Backpack> backpacks { get; set; }
        public DbSet<Character> characters { get; set; }
        public DbSet<Character_title> character_titles { get; set; }
        public DbSet<Title> titles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().HasData(new List<Item>
            {
                new Item()
                {
                    Id = 1,
                    Name = "Miecz",
                    Weight = 20
                },
                new Item()
                {
                    Id = 2,
                    Name = "Krótki Miecz",
                    Weight = 5
                }
            });
            modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
            {
                new Backpack()
                {
                    CharacterId = 1,
                    ItemId = 1,
                    Amount = 2
                },
                new Backpack()
                {
                    CharacterId = 1,
                    ItemId = 2,
                    Amount = 4
                },
            });
            modelBuilder.Entity<Character>().HasData(new List<Character>
            {
                new Character()
                {
                    Id = 1,
                    FirstName = "Stefan",
                    LastName = "Bary",
                    CurrentWeight = 60,
                    MaxWeight = 120
                },
                new Character()
                {
                    Id = 2,
                    FirstName = "Magda",
                    LastName = "Curry",
                    CurrentWeight = 30,
                    MaxWeight = 120
                },
            });
            modelBuilder.Entity<Character_title>().HasData(new List<Character_title>
            {
                new Character_title()
                {
                   CharacterId = 1,
                   TitleId = 1,
                   AcquiredAt = DateTime.Now
                },
                new Character_title()
                {
                    CharacterId = 2,
                    TitleId = 1,
                    AcquiredAt = DateTime.Now
                }
            });
            modelBuilder.Entity<Title>().HasData(new List<Title>
            {
                new Title()
                {
                    Id = 1,
                    Name = "Jak rozpętałem II wojne światową"
                },
                new Title()
                {
                    Id = 2,
                    Name = "Minecraft dla ..."
                }
            });
        }
    }
}