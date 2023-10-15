namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PublisherController : ControllerBase
{
    private readonly PublisherRepository _publisherRepository = new PublisherRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<Publisher>> GetPublishers()
    {
        return this._publisherRepository.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<Publisher> GetPublisherById(int id)
    {
        var publisher = this._publisherRepository.Get(id);
        if (publisher == null)
        {
            return NotFound();
        }
        return publisher;
    }
    
    [HttpPut]
    public ActionResult<Publisher> UpdatePublisher(Publisher publisher)
    {
        var aut = this._publisherRepository.Get(publisher.PublisherId);
        if (aut == null)
        {
            return NotFound();
        }
        this._publisherRepository.Update(publisher);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult<Publisher> AddPublisher(Publisher publisher)
    {
        var aut = this._publisherRepository.Get(publisher.PublisherId);
        if (aut != null)
        {
            return Conflict();
        }
        this._publisherRepository.Add(publisher);
        return this.NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Publisher> DeletePublisher(int id)
    {
        var aut = this._publisherRepository.Get(id);
        if (aut == null)
        {
            return NotFound();
        }
        this._publisherRepository.Delete(id);
        return NoContent();
    }
    
}