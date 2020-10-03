using System.Security.Cryptography;
using System.Text;

namespace Sales_system.Tools
{
    public static class Encrypt
    {
        public static string GetSha256(string str)
        {
            var sha256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            var sb = new StringBuilder();
            var stream = sha256.ComputeHash(encoding.GetBytes(str));
            foreach (var t in stream)
                sb.AppendFormat("{0:x2}", t);

            return sb.ToString();
        }
    }
}