using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models
{
    public class Receipt
    {
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        public User Restaurant { get; set; }
        public string AdvertId { get; set; }
        public Advert Advert { get; set; }
        public string CharityId { get; set; }
        public User Charity { get; set; }
    }
}
