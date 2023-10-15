namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class PublishersController : ODataController
{
    private readonly PublisherRepository _publisherRepository = new();
    [EnableQuery] public ActionResult<IEnumerable<Publisher>> Get()
    {
        return this.Ok(this._publisherRepository.GetAll());
    }

    [EnableQuery] public ActionResult<Publisher> Get(int key) { return this.Ok(this._publisherRepository.Get(key)); }

    [EnableQuery] public IActionResult Post([FromBody] Publisher publisher)
    {
        this._publisherRepository.Add(publisher);
        return this.Created(publisher);
    }

    [EnableQuery] public IActionResult Put(int key, [FromBody] Publisher publisher)
    {
        var bk = this._publisherRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._publisherRepository.Update(publisher);
        return this.Updated(publisher);
    }

    [EnableQuery] public IActionResult Delete([FromBody] int key)
    {
        var bk = this._publisherRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._publisherRepository.Delete(key);
        return this.Ok();
    }
}