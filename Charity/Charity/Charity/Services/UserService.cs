using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Charity.Models;
using Charity.Helpers;
using Charity.Contexts;

namespace Charity.Services
{
    public interface IUserService
    {
        AuthenticatedUser Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly DatabaseContext _context;

        public UserService(IOptions<AppSettings> appSettings, DatabaseContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthenticatedUser Authenticate(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == email && x.Password == password);

            if (user == null)
                return null;

            AuthenticatedUser authenticatedUser = new AuthenticatedUser()
            {
                Id = user.Id,
                CompanyName = user.CompanyName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                TelephoneNumber = user.TelephoneNumber,
                Email = user.Email,
                Adress = user.Adress,
                Role = user.Role,
                Town = user.Town,
                Confirmed = user.Confirmed,
                Token = GenerateJwtToken(user)
            };

            return authenticatedUser;
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}