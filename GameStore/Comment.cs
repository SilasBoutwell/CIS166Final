using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    public class Comment
    {
        public string Username { get; set; } // Username of the user who made the comment
        public IGame Game { get; set; } // The game associated with the comment
        public string Text { get; set; } // The content of the comment
        public DateTime DatePosted { get; set; } // Date and time when the comment was posted

        public Comment(string username, IGame game, string text, DateTime datePosted)
        {
            Username = username;
            Game = game;
            Text = text;
            DatePosted = datePosted;
        }

        // Override ToString method to display comment information
        public override string ToString()
        {
            return $"{DatePosted:yyyy-MM-ddTHH:mm:ss}|{Username}|{Game.ToString()}|{Text}";
        }
    }
}
