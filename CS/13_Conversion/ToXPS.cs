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
            //Pdf file
            String file = @"..\..\..\..\..\..\Data\ToXPS.pdf";

            //Open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //Convert to xps file.
            doc.SaveToFile("ToXPS-result.xps", FileFormat.XPS);
            doc.Close();

            //Launch the xps file.
            System.Diagnostics.Process.Start("ToXPS-result.xps");
        }
    }
}
