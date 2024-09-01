using Services.Domain;
using Services.ServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IUserService
    {
        Task<DefaultServiceReturnDto<User>> CreateUser(User user);
        Task<DefaultServiceReturnDto<bool>> IsActive(User user);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);

        Task<User> GetUserByField(string fieldName, object value);
    }
}
