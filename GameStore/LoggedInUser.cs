using System;
using System.IO;

namespace GameStore
{
    public static class LoggedInUser
    {
        private static User _currentUser;
        private static readonly string LastUserFile = "lastuser.txt";

        // Get the currently logged-in user
        public static User Current
        {
            get { return _currentUser; }
        }

        // Check if a user is logged in
        public static bool IsLoggedIn
        {
            get { return _currentUser != null; }
        }

        // Log in a user and save to file
        public static void Login(User user)
        {
            _currentUser = user;
            SaveLastUser(user?.Username);
        }

        // Log out the current user and clear file
        public static void Logout()
        {
            _currentUser = null;
            ClearLastUser();
        }

        // Save the last logged-in username to file
        private static void SaveLastUser(string username)
        {
            if (!string.IsNullOrEmpty(username))
                File.WriteAllText(LastUserFile, username);
        }

        // Clear the last user file
        private static void ClearLastUser()
        {
            if (File.Exists(LastUserFile))
                File.Delete(LastUserFile);
        }

        // Load the last user from file (call this on app startup)
        public static void TryAutoLogin()
        {
            if (File.Exists(LastUserFile))
            {
                string username = File.ReadAllText(LastUserFile).Trim();
                if (!string.IsNullOrEmpty(username))
                {
                    var userDb = new GameStore.Data.UserDB();
                    var user = userDb.GetUserByUsername(username);
                    if (user != null)
                    {
                        _currentUser = user;
                    }
                }
            }
        }
    }
}
