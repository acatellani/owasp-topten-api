using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace owasp_topten_api.Entities
{
    public class User
    {
        public const string TokenSecret = "f449a71cff1d56a122c84fa478c16af9075e5b4b8527787b56580773242e40ce";

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

       
    }
}