using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Token
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secretKey)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        }
    }
}
