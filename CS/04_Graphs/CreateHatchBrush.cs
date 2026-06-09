using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace CreateHatchBrush
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
            PdfDocument pdf = new PdfDocument();

            // Iterate through all available hatch styles in the PdfHatchStyle enumeration
            foreach (PdfHatchStyle type in Enum.GetValues(typeof(PdfHatchStyle)))
            {
                // Add a new page to the document
                PdfPageBase page = pdf.Pages.Add();

                // Get the canvas of the page for drawing operations
                PdfCanvas canves = page.Canvas;

                // Define the foreground color for the hatch pattern using ARGB values
                Color foreColor = Color.FromArgb(255, 255, 255, 0);

                // Define the background color for the hatch pattern using ARGB values
                Color backColor = Color.FromArgb(255, 78, 167, 46);

                // Create a new hatch brush with the current style and defined colors
                PdfHatchBrush brush = new PdfHatchBrush(type, foreColor, backColor);

                // Draw a rectangle on the canvas using the hatch brush at specified position and size
                canves.DrawRectangle(brush, 100, 100, 300, 200);
            }

            // Define the output file path for the PDF
            String output = "CreateHatchBrush.pdf";

            // Save the PDF document to the specified file
            pdf.SaveToFile(output);

            // Close the document
            pdf.Close();

            // Release the resources used by the document
            pdf.Dispose();

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
