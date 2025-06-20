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
            // Create a new PDF document
            PdfDocument doc = new PdfDocument();

            // Load an existing PDF from disk
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Sample.pdf");

            // Get the first page of the loaded PDF file
            PdfPageBase page = doc.Pages[0];

            // Get the original rotation angle of the page
            int rotation = (int)page.Rotation;

            // Set the desired rotation angle (in this case, rotate 270 degrees clockwise)
            rotation += (int)PdfPageRotateAngle.RotateAngle270;

            // Apply the rotation to the PDF page
            page.Rotation = (PdfPageRotateAngle)rotation;

            // Specify the output file name for the rotated PDF
            String result = "RotateExistingPDF_out.pdf";

            // Save the modified document with the rotated page to disk
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
