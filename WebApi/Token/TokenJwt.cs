using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Token
{
    public class TokenJwt
    {
        private JwtSecurityToken _Token;
        internal TokenJwt(JwtSecurityToken token) 
        {
            _Token = token;
        }

        public DateTime ValidTo => _Token.ValidTo;

        public string value => new JwtSecurityTokenHandler().WriteToken(_Token);
    }
}
