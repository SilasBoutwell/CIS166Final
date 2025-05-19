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
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Region { get; set; }
        public decimal Price { get; set; }

        //Constructor
        public Game(string title, string developer, string publisher, string genre, string platform, string region, decimal price)
        {
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
            return $"Title: {Title}|Developer: {Developer}|Publisher: {Publisher}|Genre: {Genre}|Platform: {Platform}|Region: {Region}|Price: ${Price}";
        }
    }
}
