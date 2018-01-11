using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Mvc.Common
{
    public static class CacheKeys
    {
        private const string WorkData = "WorkData";

        public static string GetWorkDataKey(string url, int topN)
        {
            return GetMd5Hash(topN.ToString() + url);
        }

        private static string GetMd5Hash(string input)
        {
            byte[] data;
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            }
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
