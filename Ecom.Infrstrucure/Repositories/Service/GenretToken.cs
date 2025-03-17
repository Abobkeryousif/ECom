
using Ecom.Core.Entities;
using Ecom.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Ecom.Infrstrucure.Repositories.Service
{
    class GenretToken : IGenretToken
    {
        private readonly IConfiguration _configuration;

        public GenretToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(UserApp user)
        {
            var Secret = _configuration["Token:Key"];
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var claim = new List<Claim>()
            { 
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email)

            };

            SecurityTokenDescriptor Token = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = _configuration["Token:Issure"],
                SigningCredentials = credentials,
                NotBefore = DateTime.UtcNow,
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(Token);
            return handler.WriteToken(token);
        }
    }
}
