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
            // Specify the file path of the PDF document.
            String file = @"..\..\..\..\..\..\Data\ToXPS.pdf";

            // Create a new PdfDocument object.
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified file path.
            doc.LoadFromFile(file);

            // Convert the PDF document to an XPS file and save it with the specified output file name and format (XPS).
            doc.SaveToFile("ToXPS-result.xps", FileFormat.XPS);

            // Close the PDF document.
            doc.Close();

            //Launch the xps file.
            System.Diagnostics.Process.Start("ToXPS-result.xps");
        }
    }
}
