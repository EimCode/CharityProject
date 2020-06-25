using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Charity.Contexts;
using Charity.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using Charity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Charity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private IConfiguration configuration;
        IUserService _userService;

        public UsersController(DatabaseContext context, IConfiguration configuration, IUserService userService)
        {
            this.configuration = configuration;
            _context = context;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User model)
        {
            var user = _userService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            if (user.Confirmed != 1)
                return Unauthorized(new { message = "User is not confirmed yet" });

            return Ok(user);
        }


        // GET: api/Charity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [Authorize(Roles = "administrator")]
        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> ConfirmUser(string id)
        {
            User foundUser = _context.Users.FirstOrDefault(u => u.Id == id);

            if (foundUser == null)
                return NotFound();

            foundUser.Confirmed = 1;

            _context.SaveChanges();
            return NoContent();

        }

        // PUT: api/Charity/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            if (user.Id != User.FindFirst("id").Value)
                return Forbid();

            User foundUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (foundUser == null)
                return NotFound();

            foundUser.CompanyName = user.CompanyName;
            foundUser.FirstName = user.FirstName;
            foundUser.LastName = user.LastName;
            foundUser.TelephoneNumber = user.TelephoneNumber;
            foundUser.Email = user.Email;
            foundUser.Adress = user.Adress;
            foundUser.Town = user.Town;
            foundUser.Confirmed = user.Confirmed;

            _context.SaveChanges();
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
