using Spire.Pdf;
using Spire.Pdf.Conversion;
using System;
using System.Windows.Forms;

namespace ConvertToDocxSettingProperties
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Define the input file path for the PDF document
            string input = @"..\..\..\..\..\..\Data\ConvertToWordSettingProperties.pdf";

            // Define the output file path for the converted Word document
            string output = "ConvertToWordSettingProperties-result.docx";

            // Create an instance of the PdfToDocConverter class with the specified input file path
            PdfToDocConverter converter = new PdfToDocConverter(input);

            // Set various properties for the converted Word document
            // Set the title of the Word document to "PDFTODOCX"
            converter.DocxOptions.Title = "PDFTODOCX";

            // Set the subject of the Word document to "Set document properties."
            converter.DocxOptions.Subject = "Set document properties.";

            // Set the tags of the Word document to "Test Tags"
            converter.DocxOptions.Tags = "Test Tags";

            // Set the categories of the Word document to "PDF"
            converter.DocxOptions.Categories = "PDF";

            // Set the comments of the Word document to "This document is just for testing the properties"
            converter.DocxOptions.Commments = "This document is just for testing the properties";

            // Set the authors of the Word document to "E-iceblue Support Team"
            converter.DocxOptions.Authors = "E-iceblue Support Team";

            // Set the last saved by of the Word document to "E-iceblue Support Team"
            converter.DocxOptions.LastSavedBy = "E-iceblue Support Team";

            // Set the revision version of the Word document to 8
            converter.DocxOptions.Revision = 8;

            // Set the version of the Word document to "csharp V4.0"
            converter.DocxOptions.Version = "csharp V4.0";

            // Set the program name of the Word document to "Spire.Pdf for .NET"
            converter.DocxOptions.ProgramName = "Spire.Pdf for .NET";

            // Set the company of the Word document to "E-iceblue"
            converter.DocxOptions.Company = "E-iceblue";

            // Set the manager of the Word document to "E-iceblue"
            converter.DocxOptions.Manager = "E-iceblue";

            // Convert the PDF document to a Word document using the specified output file path
            converter.SaveToDocx(output);

            //Launch the docx file
            FileViewer(output);
        }
        private void FileViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }        
    }
}
