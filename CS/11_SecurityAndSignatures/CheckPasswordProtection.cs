
using Spire.Pdf;
using System;
using System.Windows.Forms;

namespace CheckPasswordProtection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Check whether the input pdf document is password protected.
            bool isProtected =PdfDocument.IsPasswordProtected(@"..\..\..\..\..\..\Data\CheckPasswordProtection.pdf");
           
            //Show the result by message box
            MessageBox.Show("The pdf is " + (isProtected ? "password " : "not password ") +"protected!");
        }  
    }
}
