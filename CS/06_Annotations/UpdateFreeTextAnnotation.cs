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

namespace UpdateFreeTextAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document.
            PdfDocument pdf = new PdfDocument();

            // Load an existing PDF document from a file.
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\UpdateFreeTextAnnotation.pdf");

            // Get the collection of annotations from the first page of the PDF document.
            PdfAnnotationCollection annotations = pdf.Pages[0].Annotations;

            // Iterate through each free text annotation in the collection.
            foreach (PdfFreeTextAnnotationWidget annotation in annotations)
            {
                // Change the color of the annotation to YellowGreen.
                annotation.Color = Color.YellowGreen;
            }

            String result = "UpdateFreeTextAnnotation_out.pdf";

            // Save the modified PDF document to a file with the specified filename.
            pdf.SaveToFile(result);

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
