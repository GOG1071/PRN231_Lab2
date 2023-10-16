namespace eBookStore.Controllers;

using BusinessObject;
using Microsoft.AspNetCore.Mvc;

public interface IController<TModel> where TModel : class, IModel
{
    IActionResult Index();
    IActionResult Detail(int? id);
    IActionResult Edit(int id);
    IActionResult Delete(int id);
    IActionResult Create();
    
    IActionResult Edit(TModel model);
    IActionResult Delete(TModel model);
    IActionResult Create(TModel model);
}