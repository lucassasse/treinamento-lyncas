using Dashboard.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Dashboard.Service.PasswordService
{
    public class PasswordService(IConfiguration config) : IPasswordService
    {
        private readonly IConfiguration _config = config;

        public void CreateHashPassword(string password, out byte[] hashPassword, out byte[] saltPassword)
        {

            using var hmac = new HMACSHA512();
            saltPassword = hmac.Key;
            hashPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyHashPassword(string password, byte[] hashPassword, byte[] saltPassword)
        {
            using var hmac = new HMACSHA512(saltPassword);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(hashPassword);
        }

        public string CreateToken(User user)
        {
            List<Claim> claims =
            [
                new Claim("Position", user.Position.ToString()),
                new Claim("Email", user.Email),
                new Claim("Username", user.FullName)
            ];

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
