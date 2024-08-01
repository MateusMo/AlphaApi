using Microsoft.EntityFrameworkCore;
using Services.Data;
using Services.Domain;
using System.Threading.Tasks;

namespace Services.Repository.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AlphaContext _context;

        public LoginRepository(AlphaContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(user => user.Email == email && user.Password == password);
        }
    }
}
