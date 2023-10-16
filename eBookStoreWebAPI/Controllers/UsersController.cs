namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using eBookStoreWebAPI.Controllers.Base;

public class UsersController : BaseOdataController<User, UserRepository>
{
    protected override UserRepository Repository => new();
}