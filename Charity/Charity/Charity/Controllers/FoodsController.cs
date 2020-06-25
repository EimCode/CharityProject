using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Charity.Contexts;
using Charity.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Charity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FoodsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Foods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFood()
        {
            return await _context.Food.ToListAsync();
        }

        // GET: api/Foods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(string id)
        {
            var food = await _context.Food.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return food;
        }

        // PUT: api/Foods/5
        [Authorize(Roles = "restaurant")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(string id, Food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }

            if (food.RestaurantId != User.FindFirst("id").Value)
                return Forbid();

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Authorize(Roles = "restaurant")]
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food food)
        {
            food.RestaurantId = User.FindFirst("id").Value;
            _context.Food.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFood", new { id = food.Id }, food);
        }

        [Authorize(Roles = "restaurant")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Food>> DeleteFood(string id)
        {
            var food = await _context.Food.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            string restaurantId = User.FindFirst("id").Value;
            if (food.RestaurantId != restaurantId)
                return Forbid();

            _context.Food.Remove(food);
            await _context.SaveChangesAsync();

            return food;
        }

        private bool FoodExists(string id)
        {
            return _context.Food.Any(e => e.Id == id);
        }
    }
}
