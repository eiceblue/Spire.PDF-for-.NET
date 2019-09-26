using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotateExistingPDF 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Load an existing pdf from disk
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Sample.pdf");

            //Get the first page of the loaded PDF file
            PdfPageBase page = doc.Pages[0];

            //Get the original rotation angle
            int rotation = (int)page.Rotation;

            //Set the angle
            rotation += (int)PdfPageRotateAngle.RotateAngle270;

            //Rotate the PDF page based on
            page.Rotation = (PdfPageRotateAngle)rotation;

            String result = "RotateExistingPDF_out.pdf";

            //Save the document
            doc.SaveToFile(result);
            //Launch the Pdf file
            PDFDocumentViewer(result);
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
