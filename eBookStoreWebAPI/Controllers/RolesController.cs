namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using eBookStoreWebAPI.Controllers.Base;

public class RolesController : BaseOdataController<Role, RoleRepository>
{
    protected override RoleRepository Repository => new();
}