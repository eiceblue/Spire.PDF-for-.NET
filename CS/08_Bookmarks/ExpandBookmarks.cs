using Spire.Pdf;
using Spire.Pdf.Bookmarks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpandBookmarks
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

            // Load the file from disk
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_1.pdf");

            // Set true to expand the bookmarks
            ForeachBookmark(doc.Bookmarks, true);
            String result = "ExpandBookmarks_out.pdf";

            // Save the document
            doc.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }
        // Function to iterate through the bookmarks and expand or collapse them based on the specified flag
        private void ForeachBookmark(PdfBookmarkCollection collections, bool expand)
        {
            // Check if the collection is empty, and return if it is
            if (collections.Count == 0)
                return;

            // Iterate through each bookmark in the collection
            foreach (PdfBookmark bookmark in collections)
            {
                // Check if the current bookmark has child bookmarks
                if ((bookmark as PdfBookmarkCollection).Count > 0)
                {
                    // Recursively call the function to process child bookmarks
                    ForeachBookmark(bookmark as PdfBookmarkCollection, expand);

                    // Set the ExpandBookmark property of the current bookmark to the specified flag
                    bookmark.ExpandBookmark = expand;
                }
            }
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
