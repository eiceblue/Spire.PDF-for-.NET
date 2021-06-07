using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddSVGToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a new PDF document.
            PdfDocument existingPDF = new PdfDocument();

            //Load an existing PDF
            existingPDF.LoadFromFile(@"..\..\..\..\..\..\Data\SampleB_1.pdf");

            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();

            //Load the SVG file
            doc.LoadFromSvg(@"..\..\..\..\..\..\Data\template.svg");

            //Create template
            PdfTemplate template = doc.Pages[0].CreateTemplate();

            //Draw template on existing PDF
            existingPDF.Pages[0].Canvas.DrawTemplate(doc.Pages[0].CreateTemplate(), new PointF(50, 250), new SizeF(200, 200));
            
            //Save the document
            String result = "AddSVGToPDF_out.pdf";
            existingPDF.SaveToFile(result, FileFormat.PDF);

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }

        private void PDFDocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
