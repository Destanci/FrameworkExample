using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WorkVitCenter.Core.Utilities.ExtensionMethods
{
    public static class ConvertExtensionMethods
    {
        public static DateTime YearOfFirstDay(this DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }
        public static DateTime YearOfLastDay(this DateTime dt)
        {
            return dt.YearOfFirstDay().AddYears(1).AddDays(-1);
        }
        public static DateTime MonthOfFirstDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }
        public static DateTime MonthOfLastDay(this DateTime dt)
        {
            return dt.MonthOfFirstDay().AddMonths(1).AddDays(-1);
        }
        public static DateTime ConvertDate(this DateTime dt)
        {
            return Convert.ToDateTime(dt);
        }
        public static DateTime AddThreeMonth(this DateTime dt)
        {
            return dt.AddMonths(-3);
        }
        public static DateTime AddOneDay(this DateTime dt)
        {
            return dt.AddDays(1);
        }
        public static DateTime TopOfTheDay(this DateTime dt)
        {
            return Convert.ToDateTime(dt.ToString("yyyy.MM.dd"));
        }

        public static DateTime TopOfTheHour(this DateTime dt)
        {
            return Convert.ToDateTime(dt.ToShortDateString() + " " + dt.Hour + ":00:00.000");
        }

        public static DateTime HalfOfTheHour(this DateTime dt)
        {
            return Convert.ToDateTime(dt.ToShortDateString() + " " + dt.Hour + ":30:00.000");
        }

        public static DateTime EndOfTheDay(this DateTime dt)
        {
            return Convert.ToDateTime(dt.ToString("yyyy.MM.dd 23:59:59.990"));
        }
        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }
        public static int ToInt16(this object obj)
        {
            return Convert.ToInt16(obj);
        }
        public static double ToDouble(this object obj)
        {
            return Convert.ToDouble(obj);
        }

        public static decimal ToDecimal(this object obj)
        {
            return Convert.ToDecimal(obj);
        }

        public static bool ToBoolean(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static long ToLong(this object obj)
        {
            return Convert.ToInt64(obj);
        }

        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// returns Encrypted string with SHA256
        /// </summary>
        /// <param name="input">String to be encrypted</param>
        /// <param name="password">Encryption key (do not forget)</param>
        /// <returns></returns>
        public static string EncryptText(this string input, string password)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
            string result = Convert.ToBase64String(bytesEncrypted);
            return result;
        }
        public static string DecryptText(this string input, string password)
        {
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            string result = Encoding.UTF8.GetString(bytesDecrypted);
            return result;
        }
        static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            byte[] saltBytes = new byte[] { 105, 108, 107, 101, 114, 114, 114, 114 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            byte[] saltBytes = new byte[] { 105, 108, 107, 101, 114, 114, 114, 114 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}
