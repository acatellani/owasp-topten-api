using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using owasp_topten_api.Entities;
using owasp_topten_api.Services;

namespace src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserManagement : ControllerBase
    {

        private IUserServices userServices;

        public UserManagement(IUserServices uService)
        {
            userServices = uService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {

            return userServices.GetAll();

        }     
    }
}