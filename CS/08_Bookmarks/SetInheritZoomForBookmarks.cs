using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Bookmarks;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;


namespace SetInheritZoomForBookmarks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Path to the input PDF file
            string inputFile = @"..\..\..\..\..\..\Data\SetInheritZoomForBookmarks.pdf";

            // Path to the output PDF file
            string outputFile = @"output.pdf";

            // Load the PDF document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(inputFile);

            // Get the bookmarks collection of the PDF file
            PdfBookmarkCollection bookmarks = pdf.Bookmarks;

            // Iterate through each bookmark in the collection
            for (int i = 0; i < bookmarks.Count; i++)
            {
                // Set inherit zoom for the current bookmark
                PdfBookmark bookmark = bookmarks[i];
                SetBookmarkAction(bookmark);
            }

            // Save the resulting PDF document
            pdf.SaveToFile(outputFile, FileFormat.PDF);

            //Launch the file.
            PDFDocumentViewer(outputFile);
        }

        private void SetBookmarkAction(PdfBookmark bookmark)
        {
            // Get the destination of the bookmark
            PdfDestination dest = bookmark.Destination;

            // Set the destination mode to "Location" and the zoom level to 0
            dest.Mode = PdfDestinationMode.Location;
            dest.Zoom = 0;

            // Iterate through each child bookmark recursively
            for (int i = 0; i < bookmark.Count; i++)
            {
                PdfBookmark childbookmark = bookmark[i];
                SetBookmarkAction(childbookmark);
            }
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
