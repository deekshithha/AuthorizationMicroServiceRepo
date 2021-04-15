using AuthorizationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Repositories
{
    public class AuthRepo:IAuthRepo
    {
        public List<User> users;
        public AuthRepo()
        {
            users = new List<User>()
            {
                new User(){username="user",password="user123"},new User(){username="Rama",password="rama123"},
                new User(){username="Sham",password="sham123"},new User(){username="Soma",password="soma123"},
                new User(){username="Vinay",password="vinay123"},new User(){username="Singh",password="singh123"},
                new User(){username="Deshik",password="deshik123"},new User(){username="Bama",password="bama123"},
                new User(){username="Kumar",password="kumar123"},new User(){username="Raja",password="raja123"},  
            };
        }
        public User GetUser(User user)
        {
            var userinfo = users.FirstOrDefault(x => x.username == user.username & x.password == user.password);
            return userinfo;
        }
    }
}
