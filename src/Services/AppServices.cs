using System.Linq;
using Microsoft.EntityFrameworkCore;
using owasp_topten_api.Entities;

namespace owasp_topten_api.Services
{
    public class AppServices:IAppServices
    {

        private DataContext dataContext;

        public AppServices(DataContext dContext) {
            dataContext = dContext;
        }

        public void CreateAccount(Account account)
        {
            dataContext.Accounts.Add(account);
            dataContext.SaveChanges();
        }

        public Account GetAccount(int id) { 

            return dataContext.Accounts.Include(a=> a.User).FirstOrDefault(a=> a.Id == id);

        }

    }
}