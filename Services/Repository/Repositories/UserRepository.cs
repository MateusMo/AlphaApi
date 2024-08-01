using Microsoft.EntityFrameworkCore;
using Services.Data;
using Services.Domain;
using System.Threading.Tasks;

namespace Services.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AlphaContext context) : base(context)
        {
        }
    }
}
