using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;

namespace AddInkAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PDF document
            PdfDocument pdf = new PdfDocument();

            // Add a page to the document
            PdfPageBase pdfPage = pdf.Pages.Add();

            // Define the points for the ink annotation
            System.Collections.Generic.List<int[]> inkList = new System.Collections.Generic.List<int[]>();
            int[] intPoints = new int[]
            {
                100, 800,
                200, 800,
                200, 700
            };
            inkList.Add(intPoints);

            // Create an ink annotation using the defined points
            PdfInkAnnotation ia = new PdfInkAnnotation(inkList);

            // Set properties of the ink annotation such as color, border width, opacity, and text
            ia.Color = Color.Pink;
            ia.Border.Width = 12;
            ia.Opacity = 0.3f;
            ia.Text = "e-iceblue";

            // Add the ink annotation to the page's annotation widget collection
            pdfPage.Annotations.Add(ia);

            // Save the document to PDF format
            string result = "AddInkAnnotation_result.pdf";
            pdf.SaveToFile(result);
            pdf.Close();

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
