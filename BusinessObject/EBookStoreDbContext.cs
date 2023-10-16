namespace BusinessObject;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class EBookStoreDbContext : DbContext
{
    public EBookStoreDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        IConfiguration configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("EBookStoreDB"));
    }

    public virtual DbSet<Author>     Authors     { get; set; }
    public virtual DbSet<Book>       Books       { get; set; }
    public virtual DbSet<BookAuthor> BookAuthors { get; set; }
    public virtual DbSet<Publisher>  Publishers  { get; set; }
    public virtual DbSet<Role>       Roles       { get; set; }
    public virtual DbSet<User>       Users       { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>().HasKey(vf => new { vf.AuthorId, vf.BookId });
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, RoleDesc = "Administrator" },
            new Role { Id = 2, RoleDesc = "User" }
        );
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1, Password = "abc", RoleId = 2, FirstName = "Ngua", LastName = "Len Troi", MiddleName = "Mat",
                Email  = "user1@email.com",
                Source = "Web", PublisherId = "1", HireDate = DateTime.Now
            },
            new User
            {
                Id = 2, Password = "abc", RoleId = 2, FirstName = "Han", LastName = "Vo Doi", MiddleName = "Doi",
                Email  = "user2@email.com",
                Source = "Web", PublisherId = "1", HireDate = DateTime.Now
            }
        );
        modelBuilder.Entity<Publisher>().HasData(
            new Publisher { Id = 1, PublisherName = "NXB Tre", City = "HCM", State = "HCM", Country = "VN"},
            new Publisher { Id = 2, PublisherName = "NXB Kim Dong", City = "HCM", State = "HCM", Country = "VN" }
        );
        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                Id     = 1, FirstName = "Nguyen", LastName = "Nhat Anh", Phone = "123456789",
                EmailAddress = "abc@email.com",
                Address      = "123 Nguyen Trai", City = "HCM", State = "HCM", Zip = "700000"
            },
            new Author
            {
                Id = 2, FirstName = "To", LastName = "Hoai", Phone = "123456789", EmailAddress = "acb@email.com",
                Address  = "123 Nguyen Trai", City = "HCM", State = "HCM", Zip = "700000"
            });
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1, Title = "Cho Toi Xin Mot Ve Di Tuoi Tho", Advance = "256789", Price = 10000, PublisherId = 1,Notes = "A", Royalty = 10, YtdSales = 10, PublishedDate = DateTime.Now, Type = "A"
            },
            new Book
            {
                Id      = 2, Title = "Ngua mat len troi, Han doi vo doi", Advance = "14789", Price = 123454,
                PublisherId = 1, Notes = "B", Royalty = 10, YtdSales = 10, PublishedDate = DateTime.Now, Type = "B"
            },
            new Book
            {
                Id = 3, Title = "Cho Toi Xin M Tuoi Tho", Advance = "23789", Price = 10020, PublisherId = 2, Notes = "C", PublishedDate = DateTime.Now, Type = "C", Royalty = 10, YtdSales = 10
            },
            new Book { Id = 4, Title = "Ngua mat vo doi", Advance = "1345679", Price = 10343, PublisherId = 2, Notes = "D", PublishedDate = DateTime.Now, Type = "D", Royalty = 10, YtdSales = 10 },
            new Book { Id = 5, Title = "Cho Toi Xin Tuoi Tho", Advance = "5789", Price = 10000, PublisherId = 1, Notes = "E", PublishedDate = DateTime.Now, Type = "E", Royalty = 10, YtdSales = 10 }
        );
        modelBuilder.Entity<BookAuthor>().HasData(
            new BookAuthor { AuthorId = 1, BookId = 1, AuthorOrder = "Dun Knuw", RoyaltyPercentage = 97 },
            new BookAuthor { AuthorId = 1, BookId = 2, AuthorOrder = "Dun Knuw", RoyaltyPercentage = 97 },
            new BookAuthor { AuthorId = 2, BookId = 3, AuthorOrder = "Dun Knuw", RoyaltyPercentage = 97 },
            new BookAuthor { AuthorId = 2, BookId = 4, AuthorOrder = "Dun Knuw", RoyaltyPercentage = 97 },
            new BookAuthor { AuthorId = 1, BookId = 5, AuthorOrder = "Dun Knuw", RoyaltyPercentage = 97 }
        );
    }
}