namespace DataAccess.Repository;

using BusinessObject;
using DataAccess.DAO;
using DataAccess.Repository.Interface;

public class AuthorRepository : Repository<Author, AuthorDAO>
{
}