using AuthorizationService.Models;
using AuthorizationService.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationService.Services
{
    public class AuthService:IAuthService
    {
        private IAuthRepo _repo;
        public AuthService(IAuthRepo repo)
        {
            _repo = repo;
        }
        public User AuthenticateUser(User user)
        {
            
            try
            {
                var userinfo = _repo.GetUser(user);

                if (userinfo == null)
                {
                    return null;
                }
                else
                {
                    return userinfo;
                }
               
            }
            catch
            {
                
                return null;
            }
        }
        public string GetToken(User user,IConfiguration _configuration)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.username)
            };
           var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenKey"]));
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
