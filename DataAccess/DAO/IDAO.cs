namespace DataAccess.DAO;

public interface IDAO<T> where T : class
{
    static abstract T       Get(int id);
    static abstract List<T> GetAll();
    static abstract void    Add(T t);
    static abstract void    Update(T t);
    static abstract void    Delete(int id);
}