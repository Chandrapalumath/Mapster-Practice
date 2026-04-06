using Mapster_Practice.Models;

namespace Mapster_Practice.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Mocking a database in-memory
        private readonly List<User> _users = new()
        {
            new User
            {
                Id = 1,
                FirstName = "Arjun",
                LastName = "Sharma",
                Email = "arjun@example.com",
                PasswordHash = "SECRET_HASH_123", // Mapster will ignore this
                CreatedAt = DateTime.Now,
                HomeAddress = new Address { Street = "123 MG Road", City = "Bangalore", ZipCode = "560001" }
            },
            new User
            {
                Id = 2,
                FirstName = "Priya",
                LastName = "Singh",
                Email = "priya@example.com",
                PasswordHash = "SECRET_HASH_456",
                CreatedAt = DateTime.Now,
                HomeAddress = new Address { Street = "45 Park Street", City = "Kolkata", ZipCode = "700016" }
            }
        };

        public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
        public IEnumerable<User> GetAll() => _users;
    }
}
