using System.Collections.Generic;
using System.Threading.Tasks;
using owasp_topten_api.Entities;

namespace owasp_topten_api.Services
{
        public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}