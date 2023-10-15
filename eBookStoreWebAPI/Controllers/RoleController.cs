namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly RoleRepository _roleRepository = new RoleRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<Role>> GetRoles()
    {
        return this._roleRepository.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<Role> GetRoleById(int id)
    {
        var role = this._roleRepository.Get(id);
        if (role == null)
        {
            return NotFound();
        }
        return role;
    }
    
    [HttpPut]
    public ActionResult<Role> UpdateRole(Role role)
    {
        var aut = this._roleRepository.Get(role.RoleId);
        if (aut == null)
        {
            return NotFound();
        }
        this._roleRepository.Update(role);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult<Role> AddRole(Role role)
    {
        var aut = this._roleRepository.Get(role.RoleId);
        if (aut != null)
        {
            return Conflict();
        }
        this._roleRepository.Add(role);
        return this.NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult<Role> DeleteRole(int id)
    {
        var aut = this._roleRepository.Get(id);
        if (aut == null)
        {
            return NotFound();
        }
        this._roleRepository.Delete(id);
        return this.NoContent();
    }
}