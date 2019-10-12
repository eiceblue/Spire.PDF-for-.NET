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
            string filePath="../../../../../../Data/Decryption.pdf";
            String[] passwords = new String[5] { "password1", "password2", "password3", "test", "sample" };
            for (int passwordcount = 0; passwordcount < passwords.Length; passwordcount++)
            {
                try
                {
                    PdfDocument doc = new PdfDocument();
                    doc.LoadFromFile(filePath, passwords[passwordcount]);

                    MessageBox.Show("Password = " + passwords[passwordcount] + "  is correct");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Password = " + passwords[passwordcount] + "  is not correct");
                }
            }
        }
    }
}
