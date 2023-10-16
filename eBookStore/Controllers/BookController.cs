namespace eBookStore.Controllers;

using System.Net.Http.Headers;
using BusinessObject;
using DataAccess.Repository;

public class BookController : BaseController<Book,BookRepository>
{
    public BookController() {
        this.HttpClient = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        this.HttpClient.DefaultRequestHeaders.Accept.Add(contentType);
        this.BaseUrl     = "http://localhost:5134/Book";
        this.RedirectUrl = "Index";
        this.Repository  = new BookRepository();
    }
}