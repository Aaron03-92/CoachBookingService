﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BookingSystemGUI
{
    class Security
    {
        public static string hashPassword(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            byte[] encryptedBytes = sha1.ComputeHash(passwordBytes);
            return Convert.ToBase64String(encryptedBytes);

        }
    }
}
