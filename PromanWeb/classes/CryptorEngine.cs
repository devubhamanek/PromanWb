﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace PromanWeb
{
    /// <summary>
    /// This class handle the encryption and decryption in the application
    /// </summary>
    public class CryptorEngine
    {
        /// <summary>
        /// This function used in encryption and decription in the application
        /// </summary>
        /// <param name="s_Data">Data you want to encrypt or decrypt</param>
        /// <param name="s_Password">Password used for encryption and decryption</param>
        /// <param name="b_Encrypt">If need to encrypt then true, for decrypt set to false</param>
        /// <returns></returns>
        public string Crypt(string s_Data, string s_Password, bool b_Encrypt)
        {
            byte[] u8_Salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };

            PasswordDeriveBytes i_Pass = new PasswordDeriveBytes(s_Password, u8_Salt);

            Rijndael i_Alg = Rijndael.Create();
            i_Alg.Key = i_Pass.GetBytes(32);
            i_Alg.IV = i_Pass.GetBytes(16);

            ICryptoTransform i_Trans = (b_Encrypt) ? i_Alg.CreateEncryptor() : i_Alg.CreateDecryptor();

            MemoryStream i_Mem = new MemoryStream();
            CryptoStream i_Crypt = new CryptoStream(i_Mem, i_Trans, CryptoStreamMode.Write);

            byte[] u8_Data;
            if (b_Encrypt) u8_Data = Encoding.Unicode.GetBytes(s_Data);
            else u8_Data = Convert.FromBase64String(s_Data);

            try
            {
                i_Crypt.Write(u8_Data, 0, u8_Data.Length);
                i_Crypt.Close();
                if (b_Encrypt) return Convert.ToBase64String(i_Mem.ToArray());
                else return Encoding.Unicode.GetString(i_Mem.ToArray());
            }
            catch { return null; }
        }
    }
}