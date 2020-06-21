using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using owasp_topten_api.Entities;
using owasp_topten_api.Helpers;

namespace owasp_topten_api.Services
{

    public class UserServices : IUserServices
    {

        private DataContext dataContext;

        public UserServices(DataContext dContext) {
            dataContext = dContext;
            var dbC = dataContext.Database.GetDbConnection();
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await dataContext.Users.Where(u=> u.Username == username && u.Password == password).FirstOrDefaultAsync();

            if (user != null) {
                return user;
            }
            else
                return null;
        }

        public IEnumerable<User> GetAll()
        {
            return dataContext.Users.ToList();
        }
    }
}