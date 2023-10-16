namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class BookAuthorsController : ODataController
{
    private readonly BookAuthorRepository _bookAuthorRepository = new();
    [EnableQuery][HttpGet("odata/BookAuthors/GetAll")] public ActionResult<IEnumerable<BookAuthor>> Get()
    {
        return this.Ok(this._bookAuthorRepository.GetAll());
    }

    [EnableQuery][HttpGet("odata/BookAuthors/Get({Aid}&{Bid})")] public ActionResult Get(int Aid, int Bid)
    {
        try
        {
            return this.Ok(this._bookAuthorRepository.Get(Aid, Bid));
        }
        catch (Exception e)
        {
            return this.BadRequest();
        }
    }

    [EnableQuery] public ActionResult Post([FromBody] BookAuthor bookAuth)
    {
        try
        {
            this._bookAuthorRepository.Add(bookAuth);
            return this.Created(bookAuth);
        }
        catch (Exception e)
        {
            return this.BadRequest();
        }
    }

    [EnableQuery] public ActionResult Put(int Aid, int Bid, [FromBody] BookAuthor bookAuth)
    {
        try
        {
            var bk = this._bookAuthorRepository.Get(Aid, Bid);
            if (bk == null)
            {
                return this.NotFound();
            }

            this._bookAuthorRepository.Update(bookAuth);
            return this.Updated(bookAuth);
        }
        catch (Exception e)
        {
            return this.BadRequest();
        }
    }

    [EnableQuery] public ActionResult Delete(int Aid, int Bid)
    {
        try
        {
            var bk = this._bookAuthorRepository.Get(Aid, Bid);
            if (bk == null)
            {
                return this.NotFound();
            }

            this._bookAuthorRepository.Delete(Aid, Bid);
            return this.Ok();
        }
        catch (Exception e)
        {
            return this.BadRequest();
        }
    }
}