using Charity.Contexts;
using Charity.Controllers;
using Charity.Models;
using Charity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Charity.Mock
{
    public class FoodsControllerFixture
    {
        public Mock<DatabaseContext> context { get; private set; }
        public FoodsController FoodsController { get; private set; }

        public FoodsControllerFixture()
        {
            context = new Mock<DatabaseContext>();

            User restaurant_1 = new User()
            {
                Id = "1",
                Adress = "Taikos pr.53",
                CompanyName = "Pavadinimas",
                Confirmed = 1,
                LastName = "Pavardenis",
                FirstName = "Vardenis",
                Email = "vardPav@gmail.com",
                Password = "vp",
                Role = "restaurant",
                TelephoneNumber = 862222222,
                Town = "Kaunas"
            };
            User charity_1 = new User()
            {
                Id = "10",
                Adress = "Taikos pr.53",
                CompanyName = "Pavadinimas",
                Confirmed = 1,
                LastName = "Pavardenis",
                FirstName = "Vardenis",
                Email = "vardPav@gmail.com",
                Password = "vp",
                Role = "charity",
                TelephoneNumber = 862222222,
                Town = "Kaunas"
            };

            Advert advert_1 = new Advert() { id = "1", Date = "2020-05-29", isTaken = false, Description = "Description", ImageUrl = "ImageUrl", RestaurantId = restaurant_1.Id };


            Food food_1 = new Food() { Id = "1", Name = "kiaušinis", Quantity = "5 vnt.", RestaurantId = restaurant_1.Id, ReceiptId = null, AdvertId = advert_1.id };

            var list = new List<Food>() { food_1 };

            this.FoodsController = new FoodsController(context.Object);
        }
    }
}