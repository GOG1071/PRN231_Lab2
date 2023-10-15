namespace eBookStoreWebAPI.Controllers;

using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class BooksController : ODataController
{
    private readonly BookRepository _bookRepository = new BookRepository();
    
    [EnableQuery(PageSize = 1)]
    public IActionResult Get()
    {
        return this.Ok(this._bookRepository.GetAll());
    }
    
    [EnableQuery]
    public IActionResult Get(int key)
    {
        return this.Ok(this._bookRepository.Get(key));
    }
    
    [EnableQuery]
    public IActionResult Post([FromBody] BusinessObject.Book book)
    {
        this._bookRepository.Add(book);
        return this.Created(book);
    }
    
    [EnableQuery]
    public IActionResult Put(int key, [FromBody] BusinessObject.Book book)
    {
        var bk = this._bookRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }
        this._bookRepository.Update(book);
        return this.Updated(book);
    }
    
    [EnableQuery]
    public IActionResult Delete([FromBody]int key)
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