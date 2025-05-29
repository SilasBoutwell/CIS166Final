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
using GameStore;

namespace GameStore.Data
{
    /// <summary>
    /// A generic class to manage the game database.
    /// </summary>
    public class GameDB<T> where T : IGame
    {
        private readonly string _gamePath;
        private readonly Func<string, T> _parseFunc;

        public GameDB(string gamePath, Func<string, T> parseFunc)
        {
            _gamePath = gamePath;
            _parseFunc = parseFunc;
        }

        public void Save(T game)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(_gamePath, FileMode.Append, FileAccess.Write)))
            {
                sw.Write(game.ToString() + Environment.NewLine);
            }
        }

        public List<T> GetAllGames()
        {
            var games = new List<T>();
            if (!File.Exists(_gamePath))
                return games;

            foreach (var line in File.ReadAllLines(_gamePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                T game = _parseFunc(line);
                if (game != null)
                    games.Add(game);
            }
            return games;
        }
    }

    public static class GameDBFactory
    {
        public static GameDB<IGame> CreateEuropeGameDB(string gamePath)
        {
            Func<string, IGame> parseEurope = line =>
            {
                var parts = line.Split('|');
                if (parts.Length != 8) return null;
                return new Regions.Europe(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], decimal.TryParse(parts[7], out var price) ? price : 0);
            };
            return new GameDB<IGame>(gamePath, parseEurope);
        }

        public static GameDB<IGame> CreateNorthAmericaGameDB(string gamePath)
        {
            Func<string, IGame> parseNA = line =>
            {
                var parts = line.Split('|');
                if (parts.Length != 8) return null;
                return new Regions.NorthAmerica(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], decimal.TryParse(parts[7], out var price) ? price : 0);
            };
            return new GameDB<IGame>(gamePath, parseNA);
        }

        public static GameDB<IGame> CreateJapanGameDB(string gamePath)
        {
            Func<string, IGame> parseJapan = line =>
            {
                var parts = line.Split('|');
                if (parts.Length != 8) return null;
                return new Regions.Japan(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], decimal.TryParse(parts[7], out var price) ? price : 0);
            };
            return new GameDB<IGame>(gamePath, parseJapan);
        }

        public static GameDB<IGame> CreateKoreaGameDB(string gamePath)
        {
            Func<string, IGame> parseKorea = line =>
            {
                var parts = line.Split('|');
                if (parts.Length != 8) return null;
                return new Regions.Korea(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], decimal.TryParse(parts[7], out var price) ? price : 0);
            };
            return new GameDB<IGame>(gamePath, parseKorea);
        }

        public static GameDB<IGame> CreateAsiaGameDB(string gamePath)
        {
            Func<string, IGame> parseAsia = line =>
            {
                var parts = line.Split('|');
                if (parts.Length != 8) return null;
                return new Regions.Asia(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], decimal.TryParse(parts[7], out var price) ? price : 0);
            };
            return new GameDB<IGame>(gamePath, parseAsia);
        }

        // Optional: A universal factory that parses by region
        public static GameDB<IGame> CreateUniversalGameDB(string gamePath)
        {
            Func<string, IGame> parseAny = line =>
            {
                var parts = line.Split('|');
                if (parts.Length != 8) return null;
                var region = parts[6];
                decimal price = decimal.TryParse(parts[7], out var p) ? p : 0;
                switch (region)
                {
                    case "Europe":
                        return new Regions.Europe(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], region, price);
                    case "North America":
                        return new Regions.NorthAmerica(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], region, price);
                    case "Japan":
                        return new Regions.Japan(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], region, price);
                    case "Korea":
                        return new Regions.Korea(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], region, price);
                    case "Asia":
                        return new Regions.Asia(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], region, price);
                    default:
                        return null;
                }
            };
            return new GameDB<IGame>(gamePath, parseAny);
        }
    }
}
