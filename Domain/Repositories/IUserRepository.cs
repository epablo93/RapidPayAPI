using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);

        bool ValidateCredentials(string username, string password);
    }
}
