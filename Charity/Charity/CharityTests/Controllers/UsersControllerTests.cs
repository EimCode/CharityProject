using Microsoft.VisualStudio.TestTools.UnitTesting;
using Charity.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Charity.Services;
using Microsoft.Extensions.Configuration;
using Charity.Models;
using Charity.Contexts;
using Charity.Helpers;
using Charity.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Moq;
using Charity.Mock;
using Microsoft.EntityFrameworkCore;

namespace Charity.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests
    {

        [TestMethod()]
        public void AuthenticateTest()
        {
            
        }

        [TestMethod()]
        public void GetFoodsTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: "CharityDatabase")
            .Options;

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

            // Insert seed data into the database using one instance of the context
            using (var context = new DatabaseContext(options))
            {
                context.Food.Add(food_1);
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new DatabaseContext(options))
            {
                FoodsController foodsController = new FoodsController(context);
                List<Food> foods = foodsController.GetFood();

                Assert.Equals(foods.First(), food_1);
            }

        }
    }
}