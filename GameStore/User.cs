using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GameStore
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // AES key
        public static readonly byte[] AesKey = Encoding.UTF8.GetBytes("ThisIsA16ByteKey"); 

        public User(string username, string email, string password)
        {
            Username = username;
            Email = EncryptEmail(email, AesKey);
            Password = HashPassword(password);
        }

        // For loading from storage
        public User(string username, string encryptedEmail, string passwordHash, bool isHashed)
        {
            Username = username;
            Email = encryptedEmail;
            Password = passwordHash;
        }

        public override string ToString()
        {
            return $"{Username}|{Email}|{Password}";
        }

        // Email Encryption
        public static string EncryptEmail(string plainEmail, byte[] key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV(); // Random IV for each encryption
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainEmail);
                    byte[] encrypted = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                    // Prepend IV to ciphertext
                    byte[] result = new byte[aes.IV.Length + encrypted.Length];
                    Array.Copy(aes.IV, 0, result, 0, aes.IV.Length);
                    Array.Copy(encrypted, 0, result, aes.IV.Length, encrypted.Length);

                    return Convert.ToBase64String(result);
                }
            }
        }

        public static string DecryptEmail(string encryptedEmail, byte[] key)
        {
            byte[] fullCipher = Convert.FromBase64String(encryptedEmail);
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                byte[] iv = new byte[16];
                Array.Copy(fullCipher, 0, iv, 0, iv.Length);
                aes.IV = iv;
                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    byte[] cipherText = new byte[fullCipher.Length - iv.Length];
                    Array.Copy(fullCipher, iv.Length, cipherText, 0, cipherText.Length);
                    byte[] decrypted = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                    return Encoding.UTF8.GetString(decrypted);
                }
            }
        }

        // Password Hashing
        public static string HashPassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
                {
                    byte[] hash = pbkdf2.GetBytes(32);
                    byte[] hashBytes = new byte[48];
                    Array.Copy(salt, 0, hashBytes, 0, 16);
                    Array.Copy(hash, 0, hashBytes, 16, 32);
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                for (int i = 0; i < 32; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                        return false;
                }
                return true;
            }
        }
    }
}
