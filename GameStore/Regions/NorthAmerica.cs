﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore;

namespace GameStore.Regions
{
    internal class NorthAmerica : IGame
    {
        public string TimeStamp { get; set; }
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Region { get; set; }
        public decimal Price { get; set; }

        public NorthAmerica(string timestamp, string title, string developer, string publisher, string genre, string platform, string region, decimal price)
        {
            TimeStamp = timestamp;
            Title = title;
            Developer = developer;
            Publisher = publisher;
            Genre = genre;
            Platform = platform;
            Region = "North America";
            Price = price;
        }

        public override string ToString()
        {
            return $"{TimeStamp}|Title: {Title}|Developer: {Developer}|Publisher: {Publisher}|Genre: {Genre}|Platform: {Platform}|Region: {Region}|Price: ${Price}";
        }

        public int CompareTo(IGame other)
        {
            if (other == null) return 1;
            return string.Compare(this.Title, other.Title, StringComparison.OrdinalIgnoreCase);
        }
    }
}
