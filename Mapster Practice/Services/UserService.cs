using Mapster;
using Mapster_Practice.Dto;
using Mapster_Practice.Models;
using Mapster_Practice.Repositories;

namespace Mapster_Practice.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            IEnumerable<User> users = _repository.GetAll();
            return users.Adapt<IEnumerable<UserDto>>();
        }

        public UserDto GetUser(int id)
        {
            User user = _repository.GetById(id);

            // Mapster performs the conversion here
            return user.Adapt<UserDto>();
        }
    }
}
