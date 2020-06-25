using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models
{
    public class User
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelephoneNumber { get; set; }
        public string Adress { get; set; }
        public string Town { get; set; }
        public string Role { get; set; }
        public int Confirmed { get; set; }
    }
}
