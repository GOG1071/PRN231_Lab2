namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]/[action]")]
public class AuthorController : ControllerBase
{
    private readonly AuthorRepository _authorRepository = new AuthorRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<Author>> GetAuthors()
    {
        return this._authorRepository.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<Author> GetAuthorById(int id)
    {
        var author = this._authorRepository.Get(id);
        if (author == null)
        {
            return NotFound();
        }
        return author;
    }
    
    [HttpPut]
    public ActionResult<Author> UpdateAuthor(Author author)
    {
        var aut = this._authorRepository.Get(author.AuthorId);
        if (aut == null)
        {
            return NotFound();
        }
        this._authorRepository.Update(author);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult<Author> AddAuthor(Author author)
    {
        var aut = this._authorRepository.Get(author.AuthorId);
        if (aut != null)
        {
            return Conflict();
        }
        this._authorRepository.Add(author);
        return this.NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Author> DeleteAuthor(int id)
    {
        var aut = this._authorRepository.Get(id);
        if (aut == null)
        {
            return NotFound();
        }
        this._authorRepository.Delete(id);
        return NoContent();
    }
}