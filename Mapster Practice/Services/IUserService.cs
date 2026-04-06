using Mapster_Practice.Dto;

namespace Mapster_Practice.Services
{
    public interface IUserService
    {
        UserDto GetUser(int id);
        IEnumerable<UserDto> GetAllUsers();
    }
}
