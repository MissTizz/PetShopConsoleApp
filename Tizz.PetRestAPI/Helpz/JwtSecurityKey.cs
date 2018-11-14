using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Tizz.PetRestAPI.Helpz
{
    public static class JwtSecurityKey
    {
        private static byte[] _secretBytes = Encoding.UTF8.GetBytes("A secret default value for HmacSha256");

        public static SymmetricSecurityKey Key
        {
            get { return new SymmetricSecurityKey(_secretBytes); }
        }

        public static void SetSecret(string secret)
        {
            _secretBytes = Encoding.UTF8.GetBytes(secret);
        }

    }
}
