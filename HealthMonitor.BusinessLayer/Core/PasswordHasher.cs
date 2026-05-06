using System.Security.Cryptography;
using System.Text;

namespace HealthMonitor.BusinessLayer.Core
{
    public static class PasswordHasher
    {
        private const string PasswordSuffix = "chitanu";

        public static string HashPassword(string password)
        {
            var input = password + PasswordSuffix;
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
