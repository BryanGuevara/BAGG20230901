using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BAGG2309.Inventario.Auth
{
    public interface JwtAuthenticationService : IJwtAuthenticationService
    {
        _key = key;
    }

    public string Authenticate(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenKey = Encoding.ASCII.GetBytes(_key);

        var tokkenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, username)
            }),

            Expires = DateTime.UtcNow.AddHours(8),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
            , SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokkenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
}
