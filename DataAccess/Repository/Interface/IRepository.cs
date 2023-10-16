using BusinessObject;

namespace DataAccess.Repository.Interface;

using DataAccess.DAO;

public interface IRepository <TModel> where TModel : class, IModel
{
    void Add(TModel entity);
    void Update(TModel entity);
    void Delete(int id);
    TModel Get(int id);
    List<TModel> GetAll();
}