using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore.Data
{
    /// <summary>
    /// A class to manage the game database.
    /// </summary>
    public static class GameDB
    {
        const string GamePath = @"../../Data/Games.txt";

        public static void Save(IGame game)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(GamePath, FileMode.Append, FileAccess.Write)))
            {
                sw.Write(game.ToString() + Environment.NewLine);
            }
        }
    }
}
