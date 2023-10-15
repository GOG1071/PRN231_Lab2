namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository = new UserRepository();
    
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return this._userRepository.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = this._userRepository.Get(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }
    
    [HttpPut]
    public ActionResult<User> UpdateUser(User user)
    {
        var aut = this._userRepository.Get(user.UserId);
        if (aut == null)
        {
            return NotFound();
        }
        this._userRepository.Update(user);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult<User> AddUser(User user)
    {
        var aut = this._userRepository.Get(user.UserId);
        if (aut != null)
        {
            return Conflict();
        }
        this._userRepository.Add(user);
        return this.NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult<User> DeleteUser(int id)
    {
        var aut = this._userRepository.Get(id);
        if (aut == null)
        {
            return NotFound();
        }
        this._userRepository.Delete(id);
        return this.NoContent();
    }
}