using System;
using System.Security.Cryptography;
using System.Text;

namespace CardDetails.API.Commons
{
    public static class Utilities
    {

        /// <summary>Encrypts a string to a hash512 algorithm</summary>
        /// <param name="input">string to be encrypted</param>
        public static string GetHash(string input)
        {
            var result = Array.Empty<byte>();
            using (var sha512Hash = new SHA512Managed())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                result = sha512Hash.ComputeHash(inputBytes);
            }
            return Convert.ToBase64String(result);
        }
    }
}
