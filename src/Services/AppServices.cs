using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Entities;

namespace owasp_topten_api.Services
{
    public class AppServices:IAppServices
    {

        private DataContext dataContext;
        private ILogger logger;

        public AppServices(ILogger<AppServices> logEngine, DataContext dContext) {
            dataContext = dContext;
            logger = logEngine;
        }

        public void CreateAccount(Account account)
        {
            dataContext.Accounts.Add(account);
            dataContext.SaveChanges();
        }

        public Account GetAccount(int id) { 

            logger.LogWarning($"Obteniendo datos de la cuenta {id}");
            return dataContext.Accounts.Include(a=> a.User).FirstOrDefault(a=> a.Id == id);

        }

        public void CreateUser(User user)
        {
            dataContext.Users.Add(user);
            dataContext.SaveChanges();
        }

    }
}