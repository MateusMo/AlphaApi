using Services.ServiceDto;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface ILoginService
    {
        Task<DefaultServiceReturnDto<string>> AuthenticateAsync(string email, string password);
    }
}
