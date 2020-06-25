using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models
{
    public class Food
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string AdvertId { get; set; }
        public Advert Advert { get; set; }
        public string ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
        public string RestaurantId { get; set; }
        public User Restaurant { get; set; }
    }
}
