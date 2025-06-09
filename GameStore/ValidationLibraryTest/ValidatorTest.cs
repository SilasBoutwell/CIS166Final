using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using ValidationLibrary;

namespace ValidationLibraryTest
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void IsDecimal_ValidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "123.45";

            bool expected = true;
            var result = Validator.IsDecimal(txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsDecimal_InvalidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "abc";

            bool expected = false;
            var result = Validator.IsDecimal(txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsPresent_ValidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "Test";

            bool expected = true;
            var result = Validator.IsPresent(txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsPresent_EmptyValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "";

            bool expected = false;
            var result = Validator.IsPresent(txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsInt32_ValidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "123";

            bool expected = true;
            var result = Validator.IsInt32(txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsInt32_InvalidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "123.45";

            bool expected = false;
            var result = Validator.IsInt32(txtBox);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsWithinRange_ValidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "123";
            decimal min = 100;
            decimal max = 200;

            bool expected = true;
            var result = Validator.IsWithinRange(txtBox, min, max);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsWithinRange_InvalidValue()
        {
            TextBox txtBox = new TextBox();
            txtBox.Text = "50";
            decimal min = 100;
            decimal max = 200;

            bool expected = false;
            var result = Validator.IsWithinRange(txtBox, min, max);
            Assert.AreEqual(expected, result);
        }
    }
}
