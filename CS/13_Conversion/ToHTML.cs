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
            // Specify the path of the PDF file to be processed.
            String file = @"..\..\..\..\..\..\Data\ToHTML.pdf";

            // Create a new PdfDocument object.
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified file.
            doc.LoadFromFile(file);

            // Convert the loaded PDF document to an HTML file.
            doc.SaveToFile("ToHTML.html", FileFormat.HTML);

            // Close the PDF document.
            doc.Close();

            //Launching the html file
            System.Diagnostics.Process.Start("ToHTML.html");
        }
    }
}
