using BugTracker.auth.domain;
using BugTracker.helpers;
using BugTracker.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.auth.service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserAuth> _userManager;

        public AuthService(UserManager<UserAuth> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return MagicStrings.Users.Error.NotFound;
            }
            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!userHasValidPassword)
            {
                return MagicStrings.Users.Error.Login;
            }

            return GetJWTTokenForUser(user);
        }

        public async Task<string> Register(User user, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser != null)
            {
                return MagicStrings.Users.Error.AlreadyExists;
            }

            var authUser = new UserAuth()
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                UserName = user.UserName,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(authUser, password);

            if (!result.Succeeded)
            {
                return MagicStrings.Users.Error.Signup;
            }


            return GetJWTTokenForUser(authUser);
        }

        public void DeleteUser(string email)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user != null)
            {
                Console.WriteLine("found user, deleting him from database.");
                _userManager.DeleteAsync(user).GetAwaiter().GetResult();
            }
        }
        private string GetJWTTokenForUser(UserAuth user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(BugTrackerJWTConstants.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
               new Claim(JwtRegisteredClaimNames.Sub, user.Email),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(JwtRegisteredClaimNames.Email, user.Email),
               new Claim("Id", user.Id)
            };

            var token = new JwtSecurityToken(
                BugTrackerJWTConstants.Issuer,
                BugTrackerJWTConstants.Audience,
                claims,
                null,
                DateTime.UtcNow.AddDays(3),
                credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
