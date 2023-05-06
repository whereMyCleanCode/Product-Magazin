using System;
using System.Security.Cryptography;

namespace EfLesson.BL.Crypro
{
	public interface ICrypto
	{
        public string HashPassword(string password, string sault);
        public string GetCryptoImage(string imageFile);
    }
}

