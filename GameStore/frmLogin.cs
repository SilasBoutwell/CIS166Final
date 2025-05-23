using GameStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public User IsLoggedInUser()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;

            UserDB userDb = new UserDB();
            User user = userDb.GetUserByUsername(username);

            if (user != null &&
                User.VerifyPassword(password, user.Password) &&
                User.DecryptEmail(user.Email, User.AesKey) == email)
            {
                return user;
            }
            return null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = IsLoggedInUser();

            if (user == null)
            {
                UserDB userDb = new UserDB();
                var username = txtUsername.Text;
                var existingUser = userDb.GetUserByUsername(username);

                if (existingUser == null)
                    MessageBox.Show("Username not found. Please create an account.");
                else
                    MessageBox.Show("Incorrect email or password.");
                return;
            }

            LoggedInUser.Login(user);
            MessageBox.Show("Login successful!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;

            UserDB userDb = new UserDB();
            User existingUser = userDb.GetUserByUsername(username);

            if (existingUser != null)
            {
                MessageBox.Show("Username already exists. Please log in instead.");
                return;
            }

            User newUser = new User(username, email, password);
            UserDB.Save(newUser);

            LoggedInUser.Login(newUser);
            MessageBox.Show("Account created and logged in!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
