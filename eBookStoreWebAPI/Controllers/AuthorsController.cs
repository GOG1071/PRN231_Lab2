namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using eBookStoreWebAPI.Controllers.Base;

public class AuthorsController : BaseOdataController<Author, AuthorRepository>
{
    protected override AuthorRepository Repository => new();
}