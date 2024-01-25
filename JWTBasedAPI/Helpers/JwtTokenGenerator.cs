using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JWTBasedAPI.Helpers
{
    public static class JwtTokenGenerator
    {
        public static string GenerateToken(string username)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            // Add more claims as needed
        };


            /*
             * This code generates a secure random key of 128 bits and converts it to Base64 encoding, 
             * suitable for use as a JWT secret key. 
             * Ensure that you keep this key secure and do not expose it publicly.
             */
            var keyTemp = new byte[32]; // 32 bytes = 256 bits
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyTemp);
            }
            var secret = Convert.ToBase64String(keyTemp);



            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secure_key_with_at_least_128_bits"));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your_issuer",      //ValidIssuer = "https://yourdomain.com",
        
                audience: "your_audience",  //ValidAudience = "your_angular_app",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // Adjust expiration as needed
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
