namespace DataAccess.DAO;

using BusinessObject;

public abstract class DAO<T> : IDAO<T> where T : class, IModel
{
    public static T Get(int id)
    {
        T t = null;
        try
        {
            using var context = new EBookStoreDbContext();
            t = context.Set<T>().Find(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return t;
    }

    public static T Get(params object[]? objects)
    {
        T t;
        try
        {
            using var context = new EBookStoreDbContext();
            t = context.Set<T>().Find(objects);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return t;
    }

    public static T Get(T t)
    {
        T t1;
        try
        {
            using var context = new EBookStoreDbContext();
            t1 = context.Set<T>().Find(t.Id);
        }   
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return t1;
    }

    public static List<T> GetAll()
    {
        List<T> ts = null;
        try
        {
            using var context = new EBookStoreDbContext();
            ts = context.Set<T>().ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return ts;
    }
    public static void Add(T t)
    {
        try
        {
            using var context = new EBookStoreDbContext();
            t.Id = 0;
            context.Set<T>().Add(t);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public static void Update(T t)
    {
        try
        {
            using var context = new EBookStoreDbContext();
            context.Set<T>().Update(t);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public static void Delete(int id)
    {
        try
        {
            using var context = new EBookStoreDbContext();
            var t = context.Set<T>().Find(id);
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}