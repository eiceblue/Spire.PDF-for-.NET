using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using System.IO;

namespace CustomDocumentProperties
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Define a string variable to store the input file path
            String input = "..\\..\\..\\..\\..\\..\\Data\\CustomDocumentProperties.pdf";

            // Create a new PdfDocument object
            PdfDocument doc = new PdfDocument();

            // Load a PDF file from disk using the input file path
            doc.LoadFromFile(input);

            // Set custom document properties for the PDF document
            doc.DocumentInformation.SetCustomProperty("Company", "E-iceblue");
            doc.DocumentInformation.SetCustomProperty("Component", "Spire.PDF for .NET");
            doc.DocumentInformation.SetCustomProperty("Name", "Daisy");
            doc.DocumentInformation.SetCustomProperty("Team", "SalesTeam");

            // Define a string variable to store the output file path
            String result = "CustomDocumentProperties_out.pdf";

            // Save the modified PDF document to the output file path in PDF format
            doc.SaveToFile(result, FileFormat.PDF);

            //Launch the file
            DocumentViewer(result);
        }

        private void DocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
