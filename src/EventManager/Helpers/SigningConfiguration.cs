using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Helpers
{
    public class SigningConfiguration
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfiguration()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secretkey_#123!secretkey_#123!")); //TODO Should add the key to "User secrets" or hide it in a proper way
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.HmacSha256);
        }
    }
}
