using Mapster_Practice.Models;

namespace Mapster_Practice.Repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
    }
}
