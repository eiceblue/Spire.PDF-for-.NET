using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Annotations.Appearance;

namespace AddImageStamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the file path for the input PDF document
            string input = @"../../../../../../Data/AddImageStamp.pdf";

            // Create a new instance of PdfDocument
            PdfDocument document = new PdfDocument();

            // Load the PDF document from the specified file path
            document.LoadFromFile(input);

            // Get the first page of the document
            PdfPageBase page = document.Pages[0];

            // Create a rubber stamp annotation with a specified rectangle for its size and position
            PdfRubberStampAnnotation loStamp = new PdfRubberStampAnnotation(new RectangleF(new PointF(0, 0), new SizeF(60, 60)));

            // Create an instance of PdfAppearance for the rubber stamp annotation
            PdfAppearance loApprearance = new PdfAppearance(loStamp);

            // Load an image file to be used as the stamp
            PdfImage image = PdfImage.FromFile(@"../../../../../../Data/image stamp.jpg");

            // Create a template with specific dimensions
            PdfTemplate template = new PdfTemplate(210, 210);

            // Draw the loaded image onto the template
            template.Graphics.DrawImage(image, 60, 60);

            // Set the normal appearance of the stamp to use the created template
            loApprearance.Normal = template;

            // Assign the custom appearance to the rubber stamp annotation
            loStamp.Appearance = loApprearance;

            // Add the rubber stamp annotation to the page's annotations widget
            page.Annotations.Add(loStamp);

            // Specify the file name for the modified PDF document
            string output = "AddImageStamp.pdf";

            // Save the modified PDF document
            document.SaveToFile(output);

            //Launch the file
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
