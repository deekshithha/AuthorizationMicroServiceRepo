using AuthorizationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Repositories
{
    public interface IAuthRepo
    {
        public User GetUser(User user);
    }
}
