using System.Collections.Generic;
using System.Threading.Tasks;
using owasp_topten_api.Entities;
using owasp_topten_api.Model;

namespace owasp_topten_api.Services
{
    public interface IUserServices
    {
        Task<User> Authenticate(string username, string password);
        AuthenticateResponse AuthenticateJwt(AuthenticateRequest model);
        IEnumerable<User> GetAll();
    }
}