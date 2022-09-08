using Microsoft.Extensions.Configuration;
using E_ticaret.Models;
using E_ticaret.Security.Encription;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace E_ticaret.Security.JWT
{
    public class JWTHelper
    {
        public IConfiguration _configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JWTHelper()
        {
            _configuration = new ConfigurationBuilder()
            .SetBasePath( "C:\\Users\\Mustafa\\source\\repos\\E-ticaret\\E-ticaret\\" )
            .AddJsonFile( "appsettings.json" )
            .Build();

            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(Musteri musteri)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey( _tokenOptions.SecurityKey );
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials( securityKey );
            var jwt = CreateJWTSecurityToken( _tokenOptions, musteri, signingCredentials );
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken( jwt );
            return new AccessToken { Token = token, Expiration = _accessTokenExpiration };
        }

        public JwtSecurityToken CreateJWTSecurityToken(TokenOptions tokenOptions, Musteri musteri, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken( issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials );
            return jwt;
        }
    }
}
