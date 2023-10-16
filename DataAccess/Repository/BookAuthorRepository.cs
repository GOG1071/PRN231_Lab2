namespace DataAccess.Repository;

using BusinessObject;
using DataAccess.DAO;
using DataAccess.Repository.Interface;

public class BookAuthorRepository : IBookAuthorRepository
{
    public void Add(BookAuthor bookAuthor)
    {
        BookAuthorDAO.Add(bookAuthor);
    }

    public void Update(BookAuthor bookAuthor)
    {
        BookAuthorDAO.Update(bookAuthor);
    }

    public void Delete(int Aid, int Bid)
    {
        BookAuthorDAO.Delete(Aid,Bid);
    }

    public BookAuthor Get(int Aid, int Bid)
    {
        return BookAuthorDAO.Get(Aid, Bid);
    }

    public IEnumerable<BookAuthor> GetAll()
    {
        return BookAuthorDAO.GetAll();
    }
}