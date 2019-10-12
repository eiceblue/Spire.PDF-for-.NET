using System;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToHTML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pdf file
            String file = @"..\..\..\..\..\..\Data\ToHTML.pdf";

            //Open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //Convert to html file
            doc.SaveToFile("ToHTML.html", FileFormat.HTML);
            doc.Close();

            //Launching the html file
            System.Diagnostics.Process.Start("ToHTML.html");
        }
    }
}
