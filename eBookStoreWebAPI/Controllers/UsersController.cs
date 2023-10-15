namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class UsersController : ODataController
{
    private readonly UserRepository _userRepository = new();
    [EnableQuery] public ActionResult<IEnumerable<User>> Get()
    {
        return this.Ok(this._userRepository.GetAll());
    }

    [EnableQuery] public ActionResult<User> Get(int key) { return this.Ok(this._userRepository.Get(key)); }

    [EnableQuery] public IActionResult Post([FromBody] User user)
    {
        this._userRepository.Add(user);
        return this.Created(user);
    }

    [EnableQuery] public IActionResult Put(int key, [FromBody] User user)
    {
        var bk = this._userRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._userRepository.Update(user);
        return this.Updated(user);
    }

    [EnableQuery] public IActionResult Delete([FromBody] int key)
    {
        var bk = this._userRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._userRepository.Delete(key);
        return this.Ok();
    }
}