using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class EBookStoreDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoyaltyPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.AuthorId, x.BookId });
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Advance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Royalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YtdSales = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Address", "City", "EmailAddress", "FirstName", "LastName", "Phone", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "123 Nguyen Trai", "HCM", "abc@email.com", "Nguyen", "Nhat Anh", "123456789", "HCM", "700000" },
                    { 2, "123 Nguyen Trai", "HCM", "acb@email.com", "To", "Hoai", "123456789", "HCM", "700000" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId", "AuthorOrder", "RoyaltyPercentage" },
                values: new object[,]
                {
                    { 1, 1, "Dun Knuw", 97 },
                    { 1, 2, "Dun Knuw", 97 },
                    { 1, 5, "Dun Knuw", 97 },
                    { 2, 3, "Dun Knuw", 97 },
                    { 2, 4, "Dun Knuw", 97 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Advance", "Notes", "Price", "PublishedDate", "PublisherId", "Royalty", "Title", "Type", "YtdSales" },
                values: new object[,]
                {
                    { 1, "256789", "A", 10000m, new DateTime(2023, 10, 15, 12, 4, 59, 747, DateTimeKind.Local).AddTicks(9222), 1, 10m, "Cho Toi Xin Mot Ve Di Tuoi Tho", "A", 10 },
                    { 2, "14789", "B", 123454m, new DateTime(2023, 10, 15, 12, 4, 59, 747, DateTimeKind.Local).AddTicks(9225), 1, 10m, "Ngua mat len troi, Han doi vo doi", "B", 10 },
                    { 3, "23789", "C", 10020m, new DateTime(2023, 10, 15, 12, 4, 59, 747, DateTimeKind.Local).AddTicks(9226), 2, 10m, "Cho Toi Xin M Tuoi Tho", "C", 10 },
                    { 4, "1345679", "D", 10343m, new DateTime(2023, 10, 15, 12, 4, 59, 747, DateTimeKind.Local).AddTicks(9228), 2, 10m, "Ngua mat vo doi", "D", 10 },
                    { 5, "5789", "E", 10000m, new DateTime(2023, 10, 15, 12, 4, 59, 747, DateTimeKind.Local).AddTicks(9230), 1, 10m, "Cho Toi Xin Tuoi Tho", "E", 10 }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "City", "Country", "PublisherName", "State" },
                values: new object[,]
                {
                    { 1, "HCM", "VN", "NXB Tre", "HCM" },
                    { 2, "HCM", "VN", "NXB Kim Dong", "HCM" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleDesc" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "HireDate", "LastName", "MiddleName", "Password", "PublisherId", "RoleId", "Source" },
                values: new object[,]
                {
                    { 1, "user1@email.com", "Ngua", new DateTime(2023, 10, 15, 12, 4, 59, 747, DateTimeKind.Local).AddTicks(9175), "Len Troi", "Mat", "abc", "1", 2, "Web" },
                    { 2, "user2@email.com", "Han", new DateTime(2023, 10, 15, 12, 4, 59, 747, DateTimeKind.Local).AddTicks(9187), "Vo Doi", "Doi", "abc", "1", 2, "Web" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
