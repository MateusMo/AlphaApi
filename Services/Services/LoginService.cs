using Services.Repository.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.ServiceDto;

namespace Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;

        public LoginService(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }

        public async Task<DefaultServiceReturnDto<string>> AuthenticateAsync(string email, string password)
        {
            var user = await _loginRepository.GetUserByEmailAndPasswordAsync(email, password);
            if (user == null)
            {
                return new DefaultServiceReturnDto<string>()
                {
                    Status = 409,
                    Message = "Incorrect email or password",
                    Data = ""
                };
            }

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new DefaultServiceReturnDto<string>()
            {
                Status = 200,
                Message = "Loggin authorized",
                Data = tokenHandler.WriteToken(token)
            };
        }
    }
}
