using System;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToXPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pdf file
            String file = @"..\..\..\..\..\..\Data\Sample4.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //convert to xps file.
            doc.SaveToFile("Sample4.xps", FileFormat.XPS);
            doc.Close();

            //Launching the xps file.
            System.Diagnostics.Process.Start("Sample4.xps");
        }
    }
}
