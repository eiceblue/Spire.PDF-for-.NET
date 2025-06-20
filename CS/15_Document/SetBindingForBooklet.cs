using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Utilities;

namespace SetBindingForBooklet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the input PDF document.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\SetBindingForBooklet.pdf");

            // Set the save path for the result document.
            string outputFile = "SetBindingForBooklet_out.pdf";
            Stream outputstream = File.Open(outputFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);

            // Set the binding mode for the booklet.
            BookletOptions bookletOptions = new BookletOptions();
            bookletOptions.BookletBinding = PdfBookletBindingMode.Left;

            // Set the size for the booklet.
            float width = PdfPageSize.A4.Width * 2;
            float height = PdfPageSize.A4.Height;
            SizeF size = new SizeF(width, height);

            // Generate the booklet file by creating a booklet with the specified options and saving it to the output stream.
            PdfBookletCreator.CreateBooklet(doc, outputstream, size, bookletOptions);
            
            // Close the document and stream
            doc.Close();
            outputstream.Close();

            //Launch the result booklet file
            PDFDocumentViewer(outputFile);
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
