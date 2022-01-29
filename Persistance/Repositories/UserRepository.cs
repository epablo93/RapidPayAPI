using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MainDbContext _context;

        public UserRepository(MainDbContext context)
        {
            _context = context;

            SeedUser();
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        private void SeedUser()
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.Id == 1);
            
            if (existingUser == null)
            {
                _context.Users.Add(new User
                {
                    Username = "admin",
                    Password = "admin",
                    Id = 1
                });

                _context.SaveChanges();
            }
        }

        public bool ValidateCredentials(string username, string password)
        {
            var p = _context.Users.Any(x => x.Username == username && x.Password == password);
            return p;
        }
    }
}
