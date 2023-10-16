namespace eBookStore.Controllers;

using BusinessObject;
using DataAccess.Repository.Base;
using Microsoft.AspNetCore.Mvc;

public abstract class BaseController<TModel, TRepo> : Controller, IController<TModel>
    where TModel : class, IModel where TRepo : IRepository<TModel>
{
    protected TRepo      Repository;
    protected string     RedirectUrl = "";
    protected HttpClient HttpClient = null;
    protected string     BaseUrl    = "";

    public IActionResult Index()
    {
        var list = this.Repository.GetAll();
        return View(list);
    }
    public IActionResult Detail(int? id)
    {
        if (id == null || id <= 0)
            return this.NotFound();
        var model = this.Repository.Get(id.Value);
        if (model == null)
            return this.NotFound();
        return this.View(model);
    }
    public IActionResult Edit(int id)
    {
        if (id == null || id <= 0)
            return this.NotFound();
        var model = this.Repository.Get(id);
        if (model == null)
            return this.NotFound();
        return this.View(model);
    }
    public IActionResult Delete(int id)
    {
        if (id == null || id <= 0)
            return this.NotFound();
        var model = this.Repository.Get(id);
        if (model == null)
            return this.NotFound();
        return this.View(model);
    }
    public IActionResult Create() { return this.View(); }
    [HttpPost] public IActionResult Edit(TModel model)
    {
        this.Repository.Update(model);
        return RedirectToAction(this.RedirectUrl);
    }
    [HttpPost] public IActionResult Delete(TModel model)
    {
        this.Repository.Delete(model.Id);
        return RedirectToAction(this.RedirectUrl);
    }
    [HttpPost] public IActionResult Create(TModel model)
    {
        this.Repository.Add(model);
        return RedirectToAction(this.RedirectUrl);
    }
}