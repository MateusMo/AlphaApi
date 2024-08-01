using System.Threading.Tasks;

namespace Services.Services
{
    public interface ILoginService
    {
        Task<string> AuthenticateAsync(string email, string password);
    }
}
