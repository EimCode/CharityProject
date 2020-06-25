using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models
{
    public class Charity2
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Members { get; set; }
        public User Identity { get; set; }
        public string Token { get; set; }

    }
}
