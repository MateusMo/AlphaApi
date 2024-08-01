using Services.Domain;
using Services.Repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Create
        public async Task<User> CreateUser(User user)
        {
            return await _userRepository.Create(user);
        }

        // Read
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }

        // ReadAll
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        // Update
        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.Update(user);
        }

        // Delete
        public async Task DeleteUser(int id)
        {
            await _userRepository.Deactivate(id);
        }

        public async Task<User> GetUserByField(string fieldName, object value)
        {
            return await _userRepository.GetByField(fieldName, value);
        }
    }
}
