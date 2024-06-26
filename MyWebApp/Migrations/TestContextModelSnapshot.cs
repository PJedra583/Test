﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebApp.Context;

#nullable disable

namespace MyWebApp.Migrations
{
    [DbContext(typeof(TestContext))]
    partial class TestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyWebApp.Models.Backpack", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("backpacks");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            ItemId = 1,
                            Amount = 2
                        },
                        new
                        {
                            CharacterId = 1,
                            ItemId = 2,
                            Amount = 4
                        });
                });

            modelBuilder.Entity("MyWebApp.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentWeight = 60,
                            FirstName = "Stefan",
                            LastName = "Bary",
                            MaxWeight = 120
                        },
                        new
                        {
                            Id = 2,
                            CurrentWeight = 30,
                            FirstName = "Magda",
                            LastName = "Curry",
                            MaxWeight = 120
                        });
                });

            modelBuilder.Entity("MyWebApp.Models.Character_title", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CharacterId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("character_titles");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            TitleId = 1,
                            AcquiredAt = new DateTime(2024, 6, 11, 13, 23, 28, 731, DateTimeKind.Local).AddTicks(8209)
                        },
                        new
                        {
                            CharacterId = 2,
                            TitleId = 1,
                            AcquiredAt = new DateTime(2024, 6, 11, 13, 23, 28, 731, DateTimeKind.Local).AddTicks(8323)
                        });
                });

            modelBuilder.Entity("MyWebApp.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Miecz",
                            Weight = 20
                        },
                        new
                        {
                            Id = 2,
                            Name = "Krótki Miecz",
                            Weight = 5
                        });
                });

            modelBuilder.Entity("MyWebApp.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("titles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jak rozpętałem II wojne światową"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Minecraft dla ..."
                        });
                });

            modelBuilder.Entity("MyWebApp.Models.Backpack", b =>
                {
                    b.HasOne("MyWebApp.Models.Character", "Character")
                        .WithMany("CharacterItems")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApp.Models.Item", "Item")
                        .WithMany("ItemsBackpacks")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("MyWebApp.Models.Character_title", b =>
                {
                    b.HasOne("MyWebApp.Models.Character", "Character")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApp.Models.Title", "Title")
                        .WithMany("Charactertitles")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("MyWebApp.Models.Character", b =>
                {
                    b.Navigation("CharacterItems");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("MyWebApp.Models.Item", b =>
                {
                    b.Navigation("ItemsBackpacks");
                });

            modelBuilder.Entity("MyWebApp.Models.Title", b =>
                {
                    b.Navigation("Charactertitles");
                });
#pragma warning restore 612, 618
        }
    }
}
