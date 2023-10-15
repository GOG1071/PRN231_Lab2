namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookRepository _bookRepository = new BookRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return this._bookRepository.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = this._bookRepository.Get(id);
        if (book == null)
        {
            return NotFound();
        }
        return book;
    }
    
    [HttpPut]
    public ActionResult<Book> UpdateBook(Book book)
    {
        var aut = this._bookRepository.Get(book.BookId);
        if (aut == null)
        {
            return NotFound();
        }
        this._bookRepository.Update(book);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult<Book> AddBook(Book book)
    {
        var aut = this._bookRepository.Get(book.BookId);
        if (aut != null)
        {
            return Conflict();
        }
        this._bookRepository.Add(book);
        return this.NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Book> DeleteBook(int id)
    {
        var aut = this._bookRepository.Get(id);
        if (aut == null)
        {
            return NotFound();
        }
        this._bookRepository.Delete(id);
        return NoContent();
    }
}