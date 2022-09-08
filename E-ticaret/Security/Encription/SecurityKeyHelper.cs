using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace E_ticaret.Security.Encription
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey( Encoding.UTF8.GetBytes( securityKey ));
        }
    }
}
