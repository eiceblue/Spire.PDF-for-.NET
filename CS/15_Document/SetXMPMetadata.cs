using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Xmp;

namespace SetXMPMetadata
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
            string input = "..\\..\\..\\..\\..\\..\\Data\\SetXMPMetadata.pdf";

            //Open a pdf document
            PdfDocument doc = new PdfDocument();
 	    doc.LoadFromFile(input);

           //Set  XMP Metadata 
            doc.DocumentInformation.Author = "E-iceblue";
            doc.DocumentInformation.Creator = "Spire.PDF";
            doc.DocumentInformation.SetCustomProperty("Field1", "NewValue");
            doc.DocumentInformation.Keywords = "XMP";
            doc.DocumentInformation.Producer = "E-icenlue Co,.Ltd";
            doc.DocumentInformation.Subject = "XMP Metadata";
            doc.DocumentInformation.Title = "Set XMP Metadata in PDF"; 

            string output = "SetXMPMetadata.pdf";

            //Save pdf document
            doc.SaveToFile(output);

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
