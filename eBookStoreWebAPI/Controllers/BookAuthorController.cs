namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class BookAuthorController : ControllerBase
{
    private readonly BookAuthorRepository _bookAuthorRepository = new BookAuthorRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<BookAuthor>> GetBookAuthors()
    {
        return this._bookAuthorRepository.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<BookAuthor> GetBookAuthorById(int id)
    {
        var bookAuthor = this._bookAuthorRepository.Get(id);
        if (bookAuthor == null)
        {
            return NotFound();
        }
        return bookAuthor;
    }
    
    [HttpPut]
    public ActionResult<BookAuthor> UpdateBookAuthor(BookAuthor bookAuthor)
    {
        var aut = this._bookAuthorRepository.Get(bookAuthor.BookId);
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
        var aut = this._bookAuthorRepository.Get(bookAuthor.BookId);
        if (aut != null)
        {
            return Conflict();
        }
        this._bookAuthorRepository.Add(bookAuthor);
        return this.NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult<BookAuthor> DeleteBookAuthor(int id)
    {
        var aut = this._bookAuthorRepository.Get(id);
        if (aut == null)
        {
            return NotFound();
        }
        this._bookAuthorRepository.Delete(id);
        return NoContent();
    }
}