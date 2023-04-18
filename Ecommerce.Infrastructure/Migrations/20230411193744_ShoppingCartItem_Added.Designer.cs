﻿// <auto-generated />
using System;
using Ecommerce.Infrastructure.Persistence.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230411193744_ShoppingCartItem_Added")]
    partial class ShoppingCartItem_Added
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce.Domain.MovieAggregate.Entity.Cinema", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cinema", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Comfortable Cinema have Child Games. ",
                            Name = "GlaxyCinema"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Good Cinema have different movies. ",
                            Name = "ElthrirCinema"
                        });
                });

            modelBuilder.Entity("Ecommerce.Domain.MovieAggregate.Entity.MovieCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("MovieCategory", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.MovieAggregate.Entity.MovieStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("MovieStatus", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.MovieAggregate.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CinemaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieStatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("MovieCategoryId");

                    b.HasIndex("MovieStatusId");

                    b.ToTable("Movie", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CinemaId = 1L,
                            Description = "dramic movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 1,
                            MovieName = "After Ever Happy",
                            MovieStatusId = 1,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2L,
                            CinemaId = 1L,
                            Description = "dramic movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 1,
                            MovieName = "The Land",
                            MovieStatusId = 1,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3L,
                            CinemaId = 1L,
                            Description = "Action movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 2,
                            MovieName = "The North Man",
                            MovieStatusId = 1,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4L,
                            CinemaId = 1L,
                            Description = "dramic movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 1,
                            MovieName = "Brave Heart",
                            MovieStatusId = 2,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5L,
                            CinemaId = 1L,
                            Description = "dramic movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 4,
                            MovieName = "Luck",
                            MovieStatusId = 1,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6L,
                            CinemaId = 2L,
                            Description = "Comedy movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 2,
                            MovieName = "Wrath Of Man",
                            MovieStatusId = 1,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7L,
                            CinemaId = 1L,
                            Description = "dramic movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 1,
                            MovieName = "Flight",
                            MovieStatusId = 1,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8L,
                            CinemaId = 2L,
                            Description = "Comedy movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 4,
                            MovieName = "The Last Wish",
                            MovieStatusId = 2,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9L,
                            CinemaId = 1L,
                            Description = "Romantic movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 5,
                            MovieName = "Pocahontas",
                            MovieStatusId = 1,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10L,
                            CinemaId = 1L,
                            Description = "Horror movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 3,
                            MovieName = "The Invitation",
                            MovieStatusId = 1,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11L,
                            CinemaId = 1L,
                            Description = "Romantic movie",
                            EndDate = new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieCategoryId = 5,
                            MovieName = "Cinderella",
                            MovieStatusId = 1,
                            Price = 150m,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Ecommerce.Domain.OrderAggregate.Entity.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.OrderAggregate.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.ShoppingCartItemAggregate.ShoppingCartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShoppingCartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("ShoppingCartItem", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.MovieAggregate.Entity.MovieCategory", b =>
                {
                    b.OwnsOne("Ecommerce.Domain.ValueObjects.Auditables.LookupNameEn", "NameEn", b1 =>
                        {
                            b1.Property<int>("MovieCategoryId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar")
                                .HasColumnName("NameEn");

                            b1.HasKey("MovieCategoryId");

                            b1.ToTable("MovieCategory");

                            b1.WithOwner()
                                .HasForeignKey("MovieCategoryId");
                        });

                    b.Navigation("NameEn")
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommerce.Domain.MovieAggregate.Entity.MovieStatus", b =>
                {
                    b.OwnsOne("Ecommerce.Domain.ValueObjects.Auditables.LookupNameEn", "NameEn", b1 =>
                        {
                            b1.Property<int>("MovieStatusId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar")
                                .HasColumnName("NameEn");

                            b1.HasKey("MovieStatusId");

                            b1.ToTable("MovieStatus");

                            b1.WithOwner()
                                .HasForeignKey("MovieStatusId");
                        });

                    b.Navigation("NameEn")
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommerce.Domain.MovieAggregate.Movie", b =>
                {
                    b.HasOne("Ecommerce.Domain.MovieAggregate.Entity.Cinema", "Cinema")
                        .WithMany("Movies")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ecommerce.Domain.MovieAggregate.Entity.MovieCategory", "MovieCategory")
                        .WithMany("Movies")
                        .HasForeignKey("MovieCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ecommerce.Domain.MovieAggregate.Entity.MovieStatus", null)
                        .WithMany("Movies")
                        .HasForeignKey("MovieStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("MovieCategory");
                });

            modelBuilder.Entity("Ecommerce.Domain.OrderAggregate.Entity.OrderItem", b =>
                {
                    b.HasOne("Ecommerce.Domain.MovieAggregate.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Domain.OrderAggregate.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Ecommerce.Domain.ShoppingCartItemAggregate.ShoppingCartItem", b =>
                {
                    b.HasOne("Ecommerce.Domain.MovieAggregate.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Ecommerce.Domain.MovieAggregate.Entity.Cinema", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Ecommerce.Domain.MovieAggregate.Entity.MovieCategory", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Ecommerce.Domain.MovieAggregate.Entity.MovieStatus", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Ecommerce.Domain.OrderAggregate.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
