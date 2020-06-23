using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using owasp_topten_api.Entities;
using owasp_topten_api.Helpers;
using owasp_topten_api.Model;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace owasp_topten_api.Services
{

    public class UserServices : IUserServices
    {

        private DataContext dataContext;
        private IConfiguration configuration;

        public UserServices(DataContext dContext, IConfiguration config) {
            dataContext = dContext;
            configuration = config;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await dataContext.Users.Where(u=> u.Username == username && u.Password == password).FirstOrDefaultAsync();

            if (user != null) {
                return user;
            }
            else
                return null;
        }

        public AuthenticateResponse AuthenticateJwt(AuthenticateRequest model){
            var user = dataContext.Users.Where(u=> u.Username == model.Username && u.Password == model.Password).FirstOrDefault();

            if (user != null) {
                return new AuthenticateResponse(user, GenerateJwtToken(user));
            }
            else
                return null;
        }

        public IEnumerable<User> GetAll()
        {
            return dataContext.Users.ToList();
        }

         private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}