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
            //pdf file 
            string input = "..\\..\\..\\..\\..\\..\\..\\Data\\Bookmark.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument(input);

            //get the first bookmark
            PdfBookmark bookmark = doc.Bookmarks[0];

            //change the title of the bookmark
            bookmark.Title = "Modified BookMarks";

            //set the color of the bookmark
            bookmark.Color = Color.Black;

            //set the outline text style of the bookmark
            bookmark.DisplayStyle = PdfTextStyle.Bold;

            //edit child bookmarks of parent bookmark
            EditChildBookmark(bookmark);

            string output = "UpdateBookmark.pdf";

            //save pdf document
            doc.SaveToFile(output);

            //Launching the Pdf file
            PDFDocumentViewer(output);
        }
        private void EditChildBookmark(PdfBookmark parentBookmark)
        {
            foreach (PdfBookmark childBookmark in parentBookmark)
            {
                childBookmark.Color = Color.Blue;
                childBookmark.DisplayStyle = PdfTextStyle.Regular;
                EditChild2Bookmark(childBookmark);
            }
        }
        private void EditChild2Bookmark(PdfBookmark childBookmark)
        {
            foreach (PdfBookmark child2Bookmark in childBookmark)
            {
               child2Bookmark.Color = Color.LightSalmon;
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
