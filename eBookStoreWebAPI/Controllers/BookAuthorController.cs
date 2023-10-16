namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]/[action]")]
public class BookAuthorController : ControllerBase
{
    private readonly BookAuthorRepository _bookAuthorRepository = new BookAuthorRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<BookAuthor>> GetBookAuthors()
    {
        return this._bookAuthorRepository.GetAll().ToList();
    }
    
    [HttpGet("{Aid}&{Bid}")]
    public ActionResult<BookAuthor> GetBookAuthorById(int Aid,int Bid)
    {
        var bookAuthor = this._bookAuthorRepository.Get(Aid,Bid);
        if (bookAuthor == null)
        {
            return NotFound();
        }
        return bookAuthor;
    }
    
    [HttpPut]
    public ActionResult<BookAuthor> UpdateBookAuthor(BookAuthor bookAuthor)
    {
        var aut = this._bookAuthorRepository.Get(bookAuthor.AuthorId,bookAuthor.BookId);
        if (aut == null)
        {
            return NotFound();
        }
        this._bookAuthorRepository.Update(bookAuthor);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult<BookAuthor> AddBookAuthor(BookAuthor bookAuthor)
    {
        var aut = this._bookAuthorRepository.Get(bookAuthor.AuthorId,bookAuthor.BookId);
        if (aut != null)
        {
            return Conflict();
        }
        this._bookAuthorRepository.Add(bookAuthor);
        return this.NoContent();
    }
    
    [HttpDelete("{Aid}&{Bid}")]
    public ActionResult<BookAuthor> DeleteBookAuthor(int Aid, int Bid)
    {
        var aut = this._bookAuthorRepository.Get(Aid, Bid);
        if (aut == null)
        {
            return NotFound();
        }
        this._bookAuthorRepository.Delete(Aid,Bid);
        return NoContent();
    }
}