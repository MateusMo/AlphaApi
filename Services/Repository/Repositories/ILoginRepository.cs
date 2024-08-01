using Services.Domain;
using System.Threading.Tasks;

namespace Services.Repository.Repositories
{
    public interface ILoginRepository
    {
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
