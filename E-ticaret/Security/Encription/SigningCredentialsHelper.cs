﻿using Microsoft.IdentityModel.Tokens;

namespace E_ticaret.Security.Encription
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials( securityKey, SecurityAlgorithms.HmacSha256Signature );
        }
    }
}
