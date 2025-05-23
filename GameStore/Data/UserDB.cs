using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class UserDB
    {
        const string UserPath = @"../../Data/Users.txt";

        public static void Save(User user)
        {
            StreamWriter sw = new StreamWriter(new FileStream(UserPath, FileMode.Append, FileAccess.Write));
            sw.Write(user.ToString() + Environment.NewLine);
            sw.Close();
        }

        public static void DeleteUser(string username)
        {
            // Read all users
            var lines = File.ReadAllLines(UserPath).ToList();

            // Remove the user with the matching username
            lines = lines
                .Where(line =>
                {
                    var parts = line.Split('|');
                    return parts.Length > 0 && !string.Equals(parts[0], username, StringComparison.OrdinalIgnoreCase);
                })
                .ToList();

            // Write the updated list back to the file
            File.WriteAllLines(UserPath, lines);
        }

        public User GetUserByUsername(string username)
        {
            StreamReader sr = new StreamReader(new FileStream(UserPath, FileMode.Open, FileAccess.Read));
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts[0] == username)
                {
                    sr.Close();
                    return new User(parts[0], parts[1], parts[2], true);
                }
            }
            sr.Close();
            return null;
        }
    }
}
