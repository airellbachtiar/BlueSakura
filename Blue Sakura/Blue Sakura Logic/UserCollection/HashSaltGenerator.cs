using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Sakura_Logic.UserCollection
{
    public static class HashSaltGenerator
    {
        public static string GetSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            return Encoding.Default.GetString(salt);
        }

        public static string GetHash(string password, string salt)
        {
            string combined = password + salt;
            byte[] passwordForHash = Encoding.ASCII.GetBytes(combined);
            HashAlgorithm algorithm = new SHA256Managed();

            return Encoding.Default.GetString(algorithm.ComputeHash(passwordForHash));
        }    
    }
}
