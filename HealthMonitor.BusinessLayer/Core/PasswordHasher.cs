using System.Security.Cryptography;
using System.Text;

namespace HealthMonitor.BusinessLayer.Core
{
    public static class PasswordHasher
    {
        public static string GenerateSalt()
        {
            return Convert.ToBase64String(
                RandomNumberGenerator.GetBytes(16));
        }

        public static string HashPassword(string password, string salt)
        {
            var input = password + salt;
            var bytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = SHA256.HashData(bytes);

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
