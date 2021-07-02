using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtTokenGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenExpiration = DateTime.UtcNow.AddDays(1);

            var tokenHandler = new JwtSecurityTokenHandler();

            var secretKey = Encoding.ASCII.GetBytes("YOUR_SECRET_KEY_123456789abcdefg");

            SecurityTokenDescriptor tokenDescriptor = BuildSecurityTokenDescriptor(tokenExpiration, secretKey);

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var generatedToken = tokenHandler.WriteToken(token);

            Console.WriteLine(generatedToken);

            Console.ReadKey();
        }

        private static SecurityTokenDescriptor BuildSecurityTokenDescriptor(DateTime tokenExpiration, byte[] secretKey)
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>()),
                Expires = tokenExpiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };
        }
    }
}
