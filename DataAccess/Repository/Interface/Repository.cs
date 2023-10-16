using BusinessObject;

namespace DataAccess.Repository.Interface;

using DataAccess.DAO;

public class Repository<TModel, TDAO> : IRepository<TModel> where TModel : class, IModel where TDAO : IDAO<TModel>
{
    public void         Add(TModel entity)    { TDAO.Add(entity); }
    public void         Update(TModel entity) { TDAO.Update(entity); }
    public void         Delete(int id)        { TDAO.Delete(id); }
    public TModel       Get(int id)           { return TDAO.Get(id); }
    public List<TModel> GetAll()              { return TDAO.GetAll(); }
}