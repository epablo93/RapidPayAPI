using Contracts;
using System.Threading.Tasks;

namespace Service.abstractions
{
    public interface IUserService
    {
        bool ValidateCredentials(string username, string password);

        Task<UserDto> GetById(int id);
    }
}
