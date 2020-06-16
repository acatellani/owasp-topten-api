using System.Collections.Generic;
using System.Linq;
using owasp_topten_api.Entities;

namespace owasp_topten_api.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users) {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user) {
            user.Password = null;
            return user;
        }
    }
}