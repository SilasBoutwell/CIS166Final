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
