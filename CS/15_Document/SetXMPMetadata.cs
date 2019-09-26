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

            //Set xmpMetadata 
            XmpMetadata meta = doc.XmpMetaData;
            meta.SetAuthor("E-iceblue");
            meta.SetTitle("Set XMP Metadata in PDF");
            meta.SetSubject("XMP Metadata");
            meta.SetProducer("E-icenlue Co,.Ltd");
            meta.SetCreateDate(System.DateTime.Today);
            meta.SetCreator("Spire.PDF");
            meta.SetKeywords("XMP");
            meta.SetModifyDate(System.DateTime.Today);        
            meta.SetCustomProperty("Field1", "NewValue");

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
