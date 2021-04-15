using AuthorizationService.Models;
using AuthorizationService.Services;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IAuthService _service;
        private IConfiguration _configuration;
        private ILog log = LogManager.GetLogger(typeof(AuthorizationController));
        public AuthorizationController(IAuthService service,IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;

        }
        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            log.Info("HttpPost Request for Login");
            if(user==null)
            {
                return BadRequest();
            }
            try
            {
                var userinfo = _service.AuthenticateUser(user);
                if(userinfo!=null)
                {
                    var token = _service.GetToken(user, _configuration);
                    return Ok(token);
                }
                return BadRequest("Invalid User");
            }
            catch(Exception e)
            {
                log.Error("Exception "+e.Message+"occured for Login");
                return BadRequest();
            }
        }
    }
}
