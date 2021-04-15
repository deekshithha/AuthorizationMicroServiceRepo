using AuthorizationService.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Services
{
    public interface IAuthService
    {
        public User AuthenticateUser(User user);
        public string GetToken(User user, IConfiguration _configuration);
    }
}
