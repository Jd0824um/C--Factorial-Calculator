using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factorial_Calculator
{
    public partial class formFactorialCalculator : Form
    {
        public formFactorialCalculator()
        {
            InitializeComponent();
        }

        //Closes program
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValidData())
                {
                    Int64 number = Int64.Parse(txtNumber.Text);
                    Int64 result = number;

                    //Gets the factorial result of the number using a for loop
                    for (int x = 1; x < number; x++)
                    {
                        result = result * x;
                    }

                    //Sets txt box to the factorial result formatting commas
                    txtFactorial.Text = result.ToString("N0");
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Please use smaller numbers.", "Entry Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString(), ex.Message);
            }
        }

        //Checks data to see if there is not a n empty string ##From lab
        private bool isPresent(TextBox txtbox, string name)
        {
            if (txtbox.Text == "")
            {
                MessageBox.Show(name + " is a requred field.", "Entry Error");
                txtbox.Focus();
                return false;
            }
            return true;
        }

        //Checks the data to see if its a decimal number ##From lab
        private bool isDigit(TextBox txtbox, string name)
        {
            Int64 number = 0;
            if (Int64.TryParse(txtbox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a integer value.", "Entry Error");
                txtbox.Focus();
                return false;
            }
        }

        //Checks the data to see if its greater than 1 and less than 20 ##From lab
        private bool isWithinRange(TextBox txtbox, string name, int min, int max)
        {
            Int64 number = Convert.ToInt64(txtbox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be greater than " + min.ToString() + " and less than "
                    + max.ToString() + ".", "Entry Error");
                txtbox.Focus();
                return false;
            }
            return true;
        }


        //Checks input for valid data by calling methods to check for decimal, empty string, and in range
        private bool isValidData()
        {
            return
                isPresent(txtNumber, "Number") &&
                isDigit(txtNumber, "Number") &&
                isWithinRange(txtNumber, "Number", 1, 20);
        }

        //Clears values if number is changed
        private void clearFutureValue(object sender, EventArgs e)
        {
            txtFactorial.Clear();
        }

    }
}
