using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data
{
    /// <summary>
    /// A class to manage the game database.
    /// </summary>
    public static class GameDB
    {
        const string GamePath = @"../../Data/Games.txt";

        public static void Save(Game game)
        {
            string games = System.IO.File.ReadAllText(GamePath);
            games += game.ToString() + Environment.NewLine;
            System.IO.File.WriteAllText(GamePath, games);
        }
    }
}
