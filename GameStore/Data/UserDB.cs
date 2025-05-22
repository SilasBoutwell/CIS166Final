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
    }
}
