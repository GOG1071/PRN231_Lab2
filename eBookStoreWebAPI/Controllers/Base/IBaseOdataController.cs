namespace eBookStoreWebAPI.Controllers.Base;

using BusinessObject;
using Microsoft.AspNetCore.Mvc;

public interface IBaseOdataController<TModel> where TModel : class, IModel
{
    ActionResult<IEnumerable<TModel>> Get();
    ActionResult                      Get(int key);
    ActionResult                      Post([FromBody] TModel model);
    ActionResult                      Put(int key, [FromBody] TModel model);
    ActionResult                      Delete(int key);
}