namespace eBookStoreWebAPI.Controllers.Base;

using BusinessObject;
using DataAccess.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public abstract class BaseOdataController<TModel, TRepo> : ODataController, IBaseOdataController<TModel>
    where TModel : class, IModel where TRepo : class, IRepository<TModel>
{
    protected virtual            TRepo                             Repository { get; set; }
    [EnableQuery] public virtual ActionResult<IEnumerable<TModel>> Get() { return this.Ok(this.Repository.GetAll()); }
    [EnableQuery] public virtual ActionResult Get(int key)
    {
        if (key <= 0)
            return this.BadRequest();
        var model = this.Repository.Get(key);
        return this.Ok(model);
    }
    [EnableQuery] public virtual ActionResult Post([FromBody] TModel model)
    {
        if (model is not { Id: > 0 })
            return this.BadRequest();
        this.Repository.Add(model);
        return this.Created(model);
    }
    [EnableQuery] public virtual ActionResult Put(int key, [FromBody] TModel model)
    {
        if (key <= 0 || model is not { Id: > 0 })
            return this.BadRequest();
        model.Id = key;
        this.Repository.Update(model);
        return this.Updated(model);
    }
    [EnableQuery] public virtual ActionResult Delete(int key)
    {
        if (key <= 0)
            return this.BadRequest();
        var model = this.Repository.Get(key);
        if (model == null)
        {
            return this.NotFound();
        }

        this.Repository.Delete(key);
        return this.Ok(model);
    }
}