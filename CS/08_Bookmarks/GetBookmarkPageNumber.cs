using Spire.Pdf;
using Spire.Pdf.Bookmarks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetPdfBookmarkPageNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();

            //Load the file from disk.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_1.pdf");

            //Get bookmarks collections of the PDF file.
            PdfBookmarkCollection bookmarks = doc.Bookmarks;

            //Get the page number of the first bookmark.
            PdfBookmark bookmark = bookmarks[0];
            int pageNumber = doc.Pages.IndexOf(bookmark.Destination.Page)+1;

            //Save to file.
            string showPageNumber = pageNumber.ToString();

            String result = "GetPdfBookmarkPageNumber.txt";

            //Save to file.
            File.WriteAllText(result,  "The page number of the first bookmark is: " + showPageNumber);

            //Launch the file.
            DocumentViewer(result);
        }

        private void DocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
