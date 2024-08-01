using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);

        Task<User> GetUserByField(string fieldName, object value);
    }
}
