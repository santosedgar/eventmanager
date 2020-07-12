using EventManager.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace EventManager.Helpers.AuthProvider
{
    public class UserManager
    {
        public UserManager()
        {

        }

        public dynamic GetToken(User user, SigningConfiguration signingConfigurations, TokenConfiguration tokenConfigurations)
        {
            var creationDate = DateTime.UtcNow;

            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.ID.ToString(), "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.ID.ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.ID.ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(creationDate).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                        new Claim(Constants.CLAIM_ROLE_ID, ((int)user.RoleId).ToString()),
                        new Claim(Constants.CLAIM_USER_ID, user.ID.ToString())
                    }
                );

            DateTime expirationDate = creationDate +
                TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = creationDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = creationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }

    }
}
