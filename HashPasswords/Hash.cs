using System;
using System.Security.Cryptography;
using System.Text;

namespace HashPasswords
{
    public static class Hash
    {
        public static string HashPasswords(string password)
        {
            string hashPassword;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] pasBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(pasBytes);

                hashPassword = Convert.ToBase64String(hashBytes);
            }

            return hashPassword;
        }
    }
}
