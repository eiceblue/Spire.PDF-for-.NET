using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
namespace DeletePage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the PDF document from the specified file path.
            string input = "..\\..\\..\\..\\..\\..\\Data\\DeletePage.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Delete the fifth page from the document.
            doc.Pages.RemoveAt(4);

            // Specify the output file name for saving the modified document.
            string output = "DeletePage.pdf";

            // Save the modified document to a file with the specified output file name.
            doc.SaveToFile(output);

            // Close the PDF document.
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer(output);
        }
        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
