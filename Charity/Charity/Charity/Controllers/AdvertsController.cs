using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Charity.Contexts;
using Charity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Charity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AdvertsController(DatabaseContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Advert>>> GetAdverts()
        {
            return await _context.Adverts.Include(ad => ad.Restaurant).ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Advert>> GetAdvert(string id)
        {
            var advert = await _context.Adverts.FindAsync(id);

            if (advert == null)
            {
                return NotFound();
            }
            return advert;
        }

        [Authorize(Roles = "charity")]
        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> ConfirmOrder(string id)
        {
            Advert foundAdvert = _context.Adverts.FirstOrDefault(ad => ad.id == id);

            if (foundAdvert == null)
                return NotFound();

            foundAdvert.isTaken = true;
            foundAdvert.CharityGroupId = User.FindFirst("id").Value;

            _context.SaveChanges();
            return NoContent();

        }

        [Authorize(Roles = "restaurant")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvert(string id, Advert advert)
        {
            if (id != advert.id)
            {
                return BadRequest();
            }

            if (advert.RestaurantId != User.FindFirst("id").Value)
                return Forbid();

            _context.Entry(advert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertExists(id))
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
        public async Task<ActionResult<Advert>> PostAdvert(Advert advert)
        {
            advert.RestaurantId = User.FindFirst("id").Value;
            _context.Adverts.Add(advert);
            await _context.SaveChangesAsync();
            Advert advertWithRestaurant = _context.Adverts.Include(ad => ad.Restaurant).Include(ad => ad.Foods).First(ad => ad.id == advert.id);

            return CreatedAtAction("GetAdvert", new { id = advert.id }, advertWithRestaurant);
        }

        // DELETE: api/Adverts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Advert>> DeleteAdvert(string id)
        {
            var advert = await _context.Adverts.FindAsync(id);

            if (advert == null)
            {
                return NotFound();
            }

            string restaurantId = User.FindFirst("id").Value;
            if (advert.RestaurantId != restaurantId)
                return Forbid();

            _context.Adverts.Remove(advert);
            await _context.SaveChangesAsync();

            return advert;
        }

        private bool AdvertExists(string id)
        {
            return _context.Adverts.Any(e => e.id == id);
        }
    }
}
