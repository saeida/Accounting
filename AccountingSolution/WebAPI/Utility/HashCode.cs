using System.Security.Cryptography;
using System.Text;

namespace WebAPI.Utility
{
    public class HashCode
    {

        private string GetHashedPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = $"{password}{salt}";
                var hashedPasswordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                var hashedPassword = Convert.ToBase64String(hashedPasswordBytes);
                return hashedPassword;
            }
        }
    }
}
