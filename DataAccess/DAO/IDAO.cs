using BusinessObject;

namespace DataAccess.DAO;

public interface IDAO<T> where T : class, IModel
{
    static abstract T Get(int id);
    static abstract T Get(params object[]? objects);
    static abstract T Get(T t);
    static abstract List<T> GetAll();
    static abstract void Add(T t);
    static abstract void Update(T t);
    static abstract void Delete(int id);
}