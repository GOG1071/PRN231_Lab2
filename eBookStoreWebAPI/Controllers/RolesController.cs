namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class RolesController : ODataController
{
    private readonly RoleRepository _roleRepository = new();
    [EnableQuery] public ActionResult<IEnumerable<Role>> Get()
    {
        return this.Ok(this._roleRepository.GetAll());
    }

    [EnableQuery] public ActionResult<Role> Get(int key) { return this.Ok(this._roleRepository.Get(key)); }

    [EnableQuery] public IActionResult Post([FromBody] Role role)
    {
        this._roleRepository.Add(role);
        return this.Created(role);
    }

    [EnableQuery] public IActionResult Put(int key, [FromBody] Role role)
    {
        var bk = this._roleRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._roleRepository.Update(role);
        return this.Updated(role);
    }

    [EnableQuery] public IActionResult Delete([FromBody] int key)
    {
        var bk = this._roleRepository.Get(key);
        if (bk == null)
        {
            return this.NotFound();
        }

        this._roleRepository.Delete(key);
        return this.Ok();
    }
}