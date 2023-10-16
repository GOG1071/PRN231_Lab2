namespace eStoreClient.Controllers;

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using eBookStore.Controllers;
using Microsoft.AspNetCore.Mvc;

public class AuthorController : BaseController<Author, AuthorRepository>
{
    public AuthorController()
    {
        this.HttpClient = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        this.HttpClient.DefaultRequestHeaders.Accept.Add(contentType);
        this.BaseUrl     = "http://localhost:5134/Author";
        this.RedirectUrl = "Index";
        this.Repository  = new AuthorRepository();
    }
}