namespace IssueManager.Utilities
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class HashUtility
    {
        public static string HashPassword(string password)
        {
            var hashBytes = SHA1.Create()
                .ComputeHash(Encoding.Default.GetBytes(password))
                .Select(x => x.ToString());

            return string.Join(string.Empty, hashBytes);
        }
    }
}
