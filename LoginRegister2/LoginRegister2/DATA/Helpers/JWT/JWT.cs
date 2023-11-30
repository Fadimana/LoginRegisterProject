using LoginRegister2.DATA.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginRegister2.DATA.Helpers.JWT
{
    public class JWT : IJWT
    {
        private readonly IConfiguration _configuration;

        public JWT(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            var claims = new[]
                {
                 new Claim(JwtRegisteredClaimNames.Email,user.Email),
                 new Claim("Id" ,user.Id),
                };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            JwtSecurityToken token = new JwtSecurityToken(
                 claims: claims,
                 issuer: _configuration["Token:Issuer"],
                 audience: _configuration["Token:Audience"],
                 expires: DateTime.Now.AddDays(Convert.ToInt16(2)),
                 signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
