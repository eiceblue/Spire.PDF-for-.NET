using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Bookmarks;
namespace UpdateBookmark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load a PDF document
            string input = @"..\..\..\..\..\..\Data\UpdateBookmark.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Get the first bookmark from the document
            PdfBookmark bookmark = doc.Bookmarks[0];

            // Change the title of the bookmark
            bookmark.Title = "Modified BookMark";

            // Set the color of the bookmark to Black
            bookmark.Color = Color.Black;

            // Set the outline text style of the bookmark to Bold
            bookmark.DisplayStyle = PdfTextStyle.Bold;

            // Edit the child bookmarks of the parent bookmark
            EditChildBookmark(bookmark);

            // Save the PDF document
            string output = "UpdateBookmark.pdf";
            doc.SaveToFile(output);

            //Launch the file
            PDFDocumentViewer(output);
        }
        // Function to edit the child bookmarks of a parent bookmark recursively
        private void EditChildBookmark(PdfBookmark parentBookmark)
        {
            // Iterate through each child bookmark of the parent bookmark
            foreach (PdfBookmark childBookmark in parentBookmark)
            {
                // Set the color of the child bookmark to Blue
                childBookmark.Color = Color.Blue;

                // Set the outline text style of the child bookmark to Regular
                childBookmark.DisplayStyle = PdfTextStyle.Regular;

                // Recursively call EditChild2Bookmark to edit the child's child bookmarks
                EditChild2Bookmark(childBookmark);
            }
        }

        // Function to edit the child's child bookmarks recursively
        private void EditChild2Bookmark(PdfBookmark childBookmark)
        {
            // Iterate through each child bookmark of the child bookmark
            foreach (PdfBookmark child2Bookmark in childBookmark)
            {
                // Set the color of the child's child bookmark to LightSalmon
                child2Bookmark.Color = Color.LightSalmon;

                // Set the outline text style of the child's child bookmark to Italic
                child2Bookmark.DisplayStyle = PdfTextStyle.Italic;
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
