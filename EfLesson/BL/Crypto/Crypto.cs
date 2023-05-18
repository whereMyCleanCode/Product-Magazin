using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace EfLesson.BL.Crypto
{
    public class Crypto : ICrypto
    {
        public string GetCryptoImage(string image)
        {
            throw new NotImplementedException();
        }

        public string HashPassword(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(password,
               System.Text.Encoding.ASCII.GetBytes(salt),
               KeyDerivationPrf.HMACSHA512,
               5000, 64)
               );
        }
    }
}

