using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Project_16HCB.Helpers
{
    public static class ConvertMD5
    {
        public static string Md5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));
            byte[] md5Bytes = md5.Hash;
            StringBuilder sb = new StringBuilder();

            foreach (byte b in md5Bytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}