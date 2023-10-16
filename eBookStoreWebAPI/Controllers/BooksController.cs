namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using eBookStoreWebAPI.Controllers.Base;

public class BooksController : BaseOdataController<Book, BookRepository>
{
    protected override BookRepository Repository => new();
}