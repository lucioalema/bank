using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bank.Auth.Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace Bank.Auth.Infrastructure.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly string symmetricKey;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.symmetricKey = "123456ABC123456ABC";
        }

        public async Task<string> Authenticate(string userName, string password)
        {
            var user = await userRepository.FindByUserName(userName);
            if (user == null)
                return null;

            if (!user.PasswordMatches(password))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(symmetricKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("sub", user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName),
                    //new Claim(ClaimTypes.Role, "SALESMAN"),
                    //new Claim(ClaimTypes.Role, "USER"),
                    new Claim("avatar", user.Avatar),
                    //new Claim("userType", "SALESMAN"),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
