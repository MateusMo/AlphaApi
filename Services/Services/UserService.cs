using Services.Domain;
using Services.ExternalServices;
using Services.Repository.Repositories;
using Services.ServiceDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISmtp _smtp;

        public UserService(IUserRepository userRepository, ISmtp smtp)
        {
            _userRepository = userRepository;
            _smtp = smtp;
        }

        // Create
        public async Task<DefaultServiceReturnDto<User>> CreateUser(User user)
        {
            var existsEmail = await _userRepository.GetByField("Email", user.Email);
            if (existsEmail != null)
            {
                return new DefaultServiceReturnDto<User>()
                {
                    Status = 409,
                    Message = "This email is not avaiable",
                    Data = user
                };
            }

            var existsName = await _userRepository.GetByField("Name", user.Name);
            if (existsName != null)
            {
                return new DefaultServiceReturnDto<User>()
                {
                    Status = 409,
                    Message = "This name is not avaiable",
                    Data = user
                };
            }

            var sentEmail = await _smtp.EnviarEmailAsync(user.Email, "Account Validation <project name> 🔗", $@"Hello ;) Let's create amazing links? this is your confirmation code. Type it on the website {user.RecoverAccessGuid}");
            if (!sentEmail)
            {
                return new DefaultServiceReturnDto<User>
                {
                    Status = 500,
                    Message = "Error - Email not sent, try again later",
                    Data = user
                };
            }

            var createdUser = await _userRepository.Create(user);
            return new DefaultServiceReturnDto<User>
            {
                Status = 201,
                Message = "A verify code was sent to you via email. Log in the aplication and type the code to use the website.",
                Data = createdUser
            };
        }

        public async Task<DefaultServiceReturnDto<bool>> IsActive(User user)
        {
            var userLoginAttempt = await _userRepository.GetByField("Email", user.Email);
            if (userLoginAttempt == null)
            {
                return new DefaultServiceReturnDto<bool>()
                {
                    Status = 409,
                    Message = "Email not found",
                    Data = false
                };
            }

            return new DefaultServiceReturnDto<bool>()
            {
                Status = userLoginAttempt.IsActive ? 200 : 401,
                Message = userLoginAttempt.IsActive ? "" : "Type the code you received via E-mail",
                Data = userLoginAttempt.IsActive
            };
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
