using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetermineCorrectPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "../../../../../../Data/Decryption.pdf";

            // Define an array of passwords to be tested
            String[] passwords = new String[5] { "password1", "password2", "password3", "test", "sample" };

            // Iterate through each password in the array
            for (int passwordcount = 0; passwordcount < passwords.Length; passwordcount++)
            {
                try
                {
                    // Create a new PdfDocument object
                    PdfDocument doc = new PdfDocument();

                    // Load the PDF document from the file using the current password from the array
                    doc.LoadFromFile(filePath, passwords[passwordcount]);

                    // Print a message indicating that the password is correct
                    MessageBox.Show("Password = " + passwords[passwordcount] + "  is correct");
                }
                catch (Exception ex)
                {
                    // Print a message indicating that the password is not correct
                    MessageBox.Show("Password = " + passwords[passwordcount] + "  is not correct");
                }
            }
        }
    }
}
