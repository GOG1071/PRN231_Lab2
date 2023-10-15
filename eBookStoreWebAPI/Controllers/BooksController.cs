namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class BooksController : ODataController
{
    private readonly BookRepository _bookRepository = new();

    [EnableQuery] public ActionResult<IEnumerable<Book>> Get()
    {
        return this.Ok(this._bookRepository.GetAll());
    }

    [EnableQuery] public ActionResult<Book> Get(int key) { return this.Ok(this._bookRepository.Get(key)); }

    [EnableQuery] public IActionResult Post([FromRoute] Book book)
    {
        this._bookRepository.Add(book);
        return this.Created(book);
    }

    [EnableQuery] public IActionResult Put(int key, [FromRoute] Book book)
    {
        var bk = this._bookRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._bookRepository.Update(book);
        return this.Updated(book);
    }

    [EnableQuery] public IActionResult Delete([FromRoute] int key)
    {
        var bk = this._bookRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._bookRepository.Delete(key);
        return this.Ok();
    }
}