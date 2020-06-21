using owasp_topten_api.Entities;

namespace owasp_topten_api.Services
{
    public interface IAppServices
    {
         Account GetAccount(int id);

         void CreateAccount(Account account);
    }
}