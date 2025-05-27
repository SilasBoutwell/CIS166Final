using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    /// <summary>
    /// Represents a video game with various attributes.
    /// </summary>
    public class Game
    {

        //Properties
        public string TimeStamp { get; set; }
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Region { get; set; }
        public decimal Price { get; set; }

        //Constructor
        public Game(string timestamp, string title, string developer, string publisher, string genre, string platform, string region, decimal price)
        {
            this.TimeStamp = timestamp;
            this.Title = title;
            this.Developer = developer;
            this.Publisher = publisher;
            this.Genre = genre;
            this.Platform = platform;
            this.Region = region;
            this.Price = price;
        }
        //Override ToString method to display game information
        public override string ToString()
        {
            return $"{TimeStamp}|Title: {Title}|Developer: {Developer}|Publisher: {Publisher}|Genre: {Genre}|Platform: {Platform}|Region: {Region}|Price: ${Price}";
        }

        public static Game Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException("Input string is null or empty.", nameof(s));

            var parts = s.Split('|');
            if (parts.Length < 8)
                throw new FormatException("Input string is not in the correct format.");

            string timeStamp = parts[0];
            string title = parts[1];
            string developer = parts[2];
            string publisher = parts[3];
            string genre = parts[4];
            string platform = parts[5];
            string region = parts[6];

            // Fix: Remove label and dollar sign for price
            string pricePart = parts[7];
            if (pricePart.Contains(":"))
                pricePart = pricePart.Substring(pricePart.IndexOf(':') + 1);
            pricePart = pricePart.Replace("$", "").Trim();

            decimal price;
            if (!decimal.TryParse(pricePart, out price))
                throw new FormatException("Price is not a valid decimal.");

            return new Game(timeStamp, title, developer, publisher, genre, platform, region, price);
        }
    }
}
