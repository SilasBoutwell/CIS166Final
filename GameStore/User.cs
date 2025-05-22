using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    public class User
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"{Encrypt(Username)}|{Encrypt(Email)}|{Encrypt(PWEncrypt(Encrypt(Password)))}";
        }

        public string Encrypt(string e)
        {
            char[] encryptedChars = new char[e.Length];
            for (int i = 0; i < e.Length; i++)
            {
                encryptedChars[i] = (char)(e[i] ^ 'K');
            }
            return new string(encryptedChars);
        }

        public string Decrypt(string d)
        {
            var items = d.Split('|');

            string decryptedUsername = Encrypt(items[0]);
            string decryptedEmail = Encrypt(items[1]);
            string decryptedPassword = Encrypt(PWDecrypt(Encrypt(items[2])));

            return $"{decryptedUsername}|{decryptedEmail}|{decryptedPassword}";
        }

        public string PWEncrypt(string password)
        {
            var rand = new Random();
            var sb = new StringBuilder(password.Length * 3);
            for (int i = 0; i < password.Length; i++)
            {
                sb.Append((char)(password[i] + 3));
                char filler1;
                do
                {
                    filler1 = (char)rand.Next(33, 126);
                } while (filler1 == '|');
                sb.Append(filler1);
                char filler2;
                do
                {
                    filler2 = (char)rand.Next(33, 126);
                } while (filler2 == '|');
                sb.Append(filler2);
            }
            return sb.ToString();
        }

        public string PWDecrypt(string encryptedPassword)
        {
            var sb = new StringBuilder(encryptedPassword.Length / 3);
            for (int i = 0; i < encryptedPassword.Length; i += 3)
            {
                char c = (char)(encryptedPassword[i] - 3); 
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
