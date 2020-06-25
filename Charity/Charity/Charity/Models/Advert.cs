using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models
{
    public class Advert
    {
        public string id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string RestaurantId { get; set; }
        public string CharityGroupId { get; set; }
        public User Restaurant { get; set; }
        public User CharityGroup { get; set; }
        public List<Food> Foods { get; set; }
        public bool isTaken { get; set; }
        public string ImageUrl { get; set; }

    }
}
