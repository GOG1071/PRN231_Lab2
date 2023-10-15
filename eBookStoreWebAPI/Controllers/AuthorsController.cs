namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class AuthorsController : ODataController
{
    private readonly AuthorRepository _authorRepository = new();
    [EnableQuery] public ActionResult<IEnumerable<Author>> Get()
    {
        return this.Ok(this._authorRepository.GetAll());
    }

    [EnableQuery] public ActionResult<Author> Get(int key) { return this.Ok(this._authorRepository.Get(key)); }

    [EnableQuery] public IActionResult Post([FromBody] Author author)
    {
        this._authorRepository.Add(author);
        return this.Created(author);
    }

    [EnableQuery] public IActionResult Put(int key, [FromBody] Author author)
    {
        var bk = this._authorRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._authorRepository.Update(author);
        return this.Updated(author);
    }

    [EnableQuery] public IActionResult Delete([FromBody] int key)
    {
        var bk = this._authorRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._authorRepository.Delete(key);
        return this.Ok();
    }
}