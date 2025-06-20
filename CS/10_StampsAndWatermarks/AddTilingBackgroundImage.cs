using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace AddTilingBackgroundImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the PDF document from disk
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"../../../../../../Data/PDFTemplate_N.pdf");

            // Load an image to be used as the background
            PdfImage image = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png");

            // Iterate through each page in the PDF document
            foreach (PdfPageBase page in pdf.Pages)
            {
                // Create a PdfTilingBrush with a size relative to the page canvas
                PdfTilingBrush brush = new PdfTilingBrush(new SizeF(page.Canvas.Size.Width / 3, page.Canvas.Size.Height / 5));

                // Set the transparency of the brush graphics
                brush.Graphics.SetTransparency(0.3f);

                // Draw the image onto the brush graphics, centered within the brush
                brush.Graphics.DrawImage(image, new PointF((brush.Size.Width - image.Width) / 2, (brush.Size.Height - image.Height) / 2));

                // Use the brush to draw a rectangle on the page canvas, covering the entire page area
                page.Canvas.DrawRectangle(brush, new RectangleF(new PointF(0, 0), page.Canvas.Size));
            }

            // Save the modified PDF document
            string output = "AddTilingBackgroundImage_out.pdf";
            pdf.SaveToFile(output, FileFormat.PDF);

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
