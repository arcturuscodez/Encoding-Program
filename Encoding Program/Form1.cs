using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Encoding_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Encode Button

            string InputString;
            InputString = ImportBox1.Text;
            bool b = false;

            StatusBox1.Text = string.Empty;
            
            //check for bad passwords
            if (InputString.Equals("password"))
            {
                StatusBox1.Text = "This passcode is too common and will not securely protect your account. Use another passcode.";
                return;
            }

            b = Regex.IsMatch(InputString, "[A-Z]");
            if (b == false)
            {
                StatusBox1.Text = "Please provide a password with an uppercase letter!";
                return;
            }

            b = Regex.IsMatch(InputString, "[0-9]");
            if (b == false)
            {
                StatusBox1.Text = "Please provide a password with a number!";
                return;
            }

            if (InputString.IndexOf("!") < 0) 
            {
                StatusBox1.Text = "Please provide a password with an exclamation mark!";
                return;
            }

            if (InputString.Length < 6)
            {
                StatusBox1.Text = "Please provide a password with at least 6 characters!";
                return;
            }

            if(InputString.Length >= 20)
            {
                StatusBox1.Text = "Please provide a password with less than 20 characters!";
                return;
            }

            ExportBox1.Text = EncodingProcess (InputString);

            //Sends new code to decode

            ImportBox2.Text = ExportBox1.Text;

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Decode Button

            string DecodeString;
            DecodeString = ImportBox2.Text;
            ExportBox2.Text = DecodingProcess (DecodeString);
        }

      
        private string EncodingProcess (string S)
        {
            string OutputString;
            OutputString = "";
            

            char[] charlist = S.ToCharArray();
            char tmp;
            char[] newcharlist = new char[25];
            int index = 0;
            foreach (char c in charlist)
            {
                if (index >= 20) //stops code from breaking when exceeding 25 characters 
                {
                    StatusBox1.Text = "You have exceeded the maximum amount of characters. You need to specify less than 20 characters. Please reset the form using the reset button!";
                    break;
                }

                tmp = (char) (c + 3 - 5 );
                newcharlist[index] = tmp;
                index = index + 1;
                
            }

            OutputString = new string(newcharlist);
            

            return OutputString;

        }

       
        private string DecodingProcess(string S)
        {
            string OutputString;
            OutputString = "";


            char[] charlist = S.ToCharArray();
            char tmp;
            char[] newcharlist = new char[25];
            int index = 0;
            foreach (char c in charlist)
            {
                if (index >= 25) //stops code from breaking when exceeding 25 characters 
                {
                    break;
                }

                tmp = (char)(c - 3 + 5 );
                newcharlist[index] = tmp;
                index = index + 1;

            }

            OutputString = new string(newcharlist);


            return OutputString;

        }


        private void label2_Click(object sender, EventArgs e)
        {
            // Not Important
        }

        private void ImportBox2_TextChanged(object sender, EventArgs e)
        {
            // Not Important
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ResetButton1_Click(object sender, EventArgs e)
        {
            //Resets values to nothing

            ExportBox1.Text = string.Empty;
            ExportBox2.Text = string.Empty;
            ImportBox1.Text = string.Empty;
            ImportBox2.Text = string.Empty;
            StatusBox1.Text = string.Empty;
        }

        private void StatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void StatusBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
