namespace DataAccess.DAO;

using BusinessObject;

public static class BookAuthorDAO
{
    public static BookAuthor Get(int Aid, int Bid)
    {
        try
        {
            using var context = new EBookStoreDbContext();
            return context.Set<BookAuthor>().FirstOrDefault(x => x.AuthorId == Aid && x.BookId == Bid);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static List<BookAuthor> GetAll()
    {
        try
        {
            using var context = new EBookStoreDbContext();
            return context.Set<BookAuthor>().ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void Add(BookAuthor bookAuthor)
    {
        try
        {
            using var context = new EBookStoreDbContext();
            context.Set<BookAuthor>().Add(bookAuthor);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void Update(BookAuthor bookAuthor)
    {
        try
        {
            using var context = new EBookStoreDbContext();
            context.Set<BookAuthor>().Update(bookAuthor);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void Delete(int Aid, int Bid)
    {
        try
        {
            using var context = new EBookStoreDbContext();
            var obj = context.Set<BookAuthor>().First(x => x.AuthorId == Aid && x.BookId == Bid);
            context.Set<BookAuthor>().Remove(obj);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}