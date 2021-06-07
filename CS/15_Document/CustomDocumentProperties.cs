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
            String input = "..\\..\\..\\..\\..\\..\\Data\\CustomDocumentProperties.pdf";
            PdfDocument doc = new PdfDocument();
            //Load a pdf file from disk
            doc.LoadFromFile(input);

            //Custom document properties
            doc.DocumentInformation.SetCustomerDefined("Company", "E-iceblue");
            doc.DocumentInformation.SetCustomerDefined("Component", "Spire.PDF for .NET");
            doc.DocumentInformation.SetCustomerDefined("Name", "Daisy");
            doc.DocumentInformation.SetCustomerDefined("Team", "SalesTeam");
            
            //Save to file
            String result = "CustomDocumentProperties_out.pdf";
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
