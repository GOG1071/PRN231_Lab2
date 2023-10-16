﻿// <auto-generated />
using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObject.Migrations
{
    [DbContext(typeof(EBookStoreDbContext))]
    [Migration("20231016044409_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObject.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Nguyen Trai",
                            City = "HCM",
                            EmailAddress = "abc@email.com",
                            FirstName = "Nguyen",
                            LastName = "Nhat Anh",
                            Phone = "123456789",
                            State = "HCM",
                            Zip = "700000"
                        },
                        new
                        {
                            Id = 2,
                            Address = "123 Nguyen Trai",
                            City = "HCM",
                            EmailAddress = "acb@email.com",
                            FirstName = "To",
                            LastName = "Hoai",
                            Phone = "123456789",
                            State = "HCM",
                            Zip = "700000"
                        });
                });

            modelBuilder.Entity("BusinessObject.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Advance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<decimal>("Royalty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YtdSales")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Advance = "256789",
                            Notes = "A",
                            Price = 10000m,
                            PublishedDate = new DateTime(2023, 10, 16, 11, 44, 9, 377, DateTimeKind.Local).AddTicks(7255),
                            PublisherId = 1,
                            Royalty = 10m,
                            Title = "Cho Toi Xin Mot Ve Di Tuoi Tho",
                            Type = "A",
                            YtdSales = 10
                        },
                        new
                        {
                            Id = 2,
                            Advance = "14789",
                            Notes = "B",
                            Price = 123454m,
                            PublishedDate = new DateTime(2023, 10, 16, 11, 44, 9, 377, DateTimeKind.Local).AddTicks(7260),
                            PublisherId = 1,
                            Royalty = 10m,
                            Title = "Ngua mat len troi, Han doi vo doi",
                            Type = "B",
                            YtdSales = 10
                        },
                        new
                        {
                            Id = 3,
                            Advance = "23789",
                            Notes = "C",
                            Price = 10020m,
                            PublishedDate = new DateTime(2023, 10, 16, 11, 44, 9, 377, DateTimeKind.Local).AddTicks(7263),
                            PublisherId = 2,
                            Royalty = 10m,
                            Title = "Cho Toi Xin M Tuoi Tho",
                            Type = "C",
                            YtdSales = 10
                        },
                        new
                        {
                            Id = 4,
                            Advance = "1345679",
                            Notes = "D",
                            Price = 10343m,
                            PublishedDate = new DateTime(2023, 10, 16, 11, 44, 9, 377, DateTimeKind.Local).AddTicks(7266),
                            PublisherId = 2,
                            Royalty = 10m,
                            Title = "Ngua mat vo doi",
                            Type = "D",
                            YtdSales = 10
                        },
                        new
                        {
                            Id = 5,
                            Advance = "5789",
                            Notes = "E",
                            Price = 10000m,
                            PublishedDate = new DateTime(2023, 10, 16, 11, 44, 9, 377, DateTimeKind.Local).AddTicks(7270),
                            PublisherId = 1,
                            Royalty = 10m,
                            Title = "Cho Toi Xin Tuoi Tho",
                            Type = "E",
                            YtdSales = 10
                        });
                });

            modelBuilder.Entity("BusinessObject.BookAuthor", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoyaltyPercentage")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "BookId");

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            BookId = 1,
                            AuthorOrder = "Dun Knuw",
                            RoyaltyPercentage = 97
                        },
                        new
                        {
                            AuthorId = 1,
                            BookId = 2,
                            AuthorOrder = "Dun Knuw",
                            RoyaltyPercentage = 97
                        },
                        new
                        {
                            AuthorId = 2,
                            BookId = 3,
                            AuthorOrder = "Dun Knuw",
                            RoyaltyPercentage = 97
                        },
                        new
                        {
                            AuthorId = 2,
                            BookId = 4,
                            AuthorOrder = "Dun Knuw",
                            RoyaltyPercentage = 97
                        },
                        new
                        {
                            AuthorId = 1,
                            BookId = 5,
                            AuthorOrder = "Dun Knuw",
                            RoyaltyPercentage = 97
                        });
                });

            modelBuilder.Entity("BusinessObject.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "HCM",
                            Country = "VN",
                            PublisherName = "NXB Tre",
                            State = "HCM"
                        },
                        new
                        {
                            Id = 2,
                            City = "HCM",
                            Country = "VN",
                            PublisherName = "NXB Kim Dong",
                            State = "HCM"
                        });
                });

            modelBuilder.Entity("BusinessObject.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleDesc = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            RoleDesc = "User"
                        });
                });

            modelBuilder.Entity("BusinessObject.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "user1@email.com",
                            FirstName = "Ngua",
                            HireDate = new DateTime(2023, 10, 16, 11, 44, 9, 377, DateTimeKind.Local).AddTicks(7020),
                            LastName = "Len Troi",
                            MiddleName = "Mat",
                            Password = "abc",
                            PublisherId = "1",
                            RoleId = 2,
                            Source = "Web"
                        },
                        new
                        {
                            Id = 2,
                            Email = "user2@email.com",
                            FirstName = "Han",
                            HireDate = new DateTime(2023, 10, 16, 11, 44, 9, 377, DateTimeKind.Local).AddTicks(7034),
                            LastName = "Vo Doi",
                            MiddleName = "Doi",
                            Password = "abc",
                            PublisherId = "1",
                            RoleId = 2,
                            Source = "Web"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}