using BugTracker.auth;
using BugTracker.auth.domain;
using BugTracker.auth.service;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.auth.service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserAuth> _userManager;
        private readonly SignInManager<UserAuth> _signInManager;

        public AuthService(UserManager<UserAuth> userManager, SignInManager<UserAuth> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> FindByEmailOrUserName(string email, string userName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                return true;
            }

            user = await _userManager.FindByNameAsync(userName);

            return user != null;
        }

        public async Task<string> Login(string userName, string email, string password)
        {
            var success = await FindByEmailOrUserName(email, userName);

            if (!success)
            {
                return "false";
            }

            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);

            return GetJWTTokenForUserName(userName);
        }

        public async Task<string> Register(string userName, string email, string password)
        {
            var authUser = new UserAuth()
            {
                UserName = userName,
                Email = email,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(authUser, password);

            if (!result.Succeeded)
            {
                throw new Exception("Error signing up user!");
            }


            return GetJWTTokenForUserName(userName);
        }

        public void DeleteUser(string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;
            if (user != null)
            {
                _userManager.DeleteAsync(user).GetAwaiter().GetResult();
            }
        }

        public async void Logout(string userName)
        {
           await _signInManager.SignOutAsync();
        }

        private string GetJWTTokenForUserName(string userName)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(BugTrackerJWTConstants.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
               new Claim("User", userName)
            };

            var token = new JwtSecurityToken(
                BugTrackerJWTConstants.Issuer,
                BugTrackerJWTConstants.Audience,
                claims,
                null,
                DateTime.UtcNow.AddSeconds(30),
                credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
