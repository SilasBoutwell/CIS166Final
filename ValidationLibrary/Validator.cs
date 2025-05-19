using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidationLibrary
{

    /// <summary>
    /// Provides static methods for validaing data
    /// </summary>
    public static class Validator
    {
        private static string title = "Entry Error";

        /// <summary>
        /// The character sequence to terminate each line in 
        /// the validation message.
        /// </summary>

        public static string LineEnd { get; set; } = "\n";

        public static string Title
        {
            get => title;
            set => title = value;
        }

        /// <summary>
        /// Checks if the textbox has any value in it
        /// </summary>
        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + " is a required field.", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the textbox has a valid Decimal number
        /// </summary>
        public static bool IsDecimal(TextBox textBox)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be a decimal value.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks if the textbox has a valid Int32 number
        /// </summary>
        public static bool IsInt32(TextBox textBox)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks if the textbox is withing the specified range
        /// </summary>
        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min
                    + " and " + max + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }
    }
}
