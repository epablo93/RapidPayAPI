using Contracts;
using Domain.Repositories;
using Mapster;
using Service.abstractions;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user =  await _userRepository.GetById(id);

            return user.Adapt<UserDto>();
        }

        public bool ValidateCredentials(string username, string password)
        {
            return _userRepository.ValidateCredentials(username, password);
        }
    }
}
