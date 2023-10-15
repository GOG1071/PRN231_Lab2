namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class BookAuthorAuthorsController : ODataController
{
    private readonly BookAuthorRepository _bookAuthorRepository = new();
    [EnableQuery] public ActionResult<IEnumerable<BookAuthor>> Get()
    {
        return this.Ok(this._bookAuthorRepository.GetAll());
    }

    [EnableQuery] public ActionResult<BookAuthor> Get(int key) { return this.Ok(this._bookAuthorRepository.Get(key)); }

    [EnableQuery] public IActionResult Post([FromBody] BookAuthor bookAuth)
    {
        this._bookAuthorRepository.Add(bookAuth);
        return this.Created(bookAuth);
    }

    [EnableQuery] public IActionResult Put(int key, [FromBody] BookAuthor bookAuth)
    {
        var bk = this._bookAuthorRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._bookAuthorRepository.Update(bookAuth);
        return this.Updated(bookAuth);
    }

    [EnableQuery] public IActionResult Delete([FromBody] int key)
    {
        var bk = this._bookAuthorRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._bookAuthorRepository.Delete(key);
        return this.Ok();
    }
}