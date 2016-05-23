using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Membership.Utils
{
    public static class HashingUtils
    {
        public static string Hash(string text)
        {
            var hash = SHA512.Create();
            var hashedBytes = hash.ComputeHash(Encoding.ASCII.GetBytes(text));
            return Encoding.UTF8.GetString(hashedBytes);
        }
    }
}
