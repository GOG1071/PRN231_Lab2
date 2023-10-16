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

    [EnableQuery] public ActionResult<BookAuthor> Get(int Aid, int Bid) { return this.Ok(this._bookAuthorRepository.Get(Aid,Bid)); }

    [EnableQuery] public IActionResult Post([FromBody] BookAuthor bookAuth)
    {
        this._bookAuthorRepository.Add(bookAuth);
        return this.Created(bookAuth);
    }

    [EnableQuery] public IActionResult Put(int Aid, int Bid, [FromBody] BookAuthor bookAuth)
    {
        var bk = this._bookAuthorRepository.Get(Aid,Bid);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._bookAuthorRepository.Update(bookAuth);
        return this.Updated(bookAuth);
    }

    [EnableQuery] public IActionResult Delete([FromBody] int Aid, int Bid)
    {
        var bk = this._bookAuthorRepository.Get(Aid,Bid);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._bookAuthorRepository.Delete(Aid,Bid);
        return this.Ok();
    }
}