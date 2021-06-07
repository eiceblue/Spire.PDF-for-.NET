using Spire.Pdf;
using Spire.Pdf.Bookmarks;
using System;
using System.Windows.Forms;

namespace ExpandSpecificBookmarks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load old PDF from disk.
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\ExpandSpecificBookmarks.pdf");

            //Set BookMarkExpandOrCollapse as "true" for the first bookmarks and "false" for the first level of the second bookmarks  
            pdf.Bookmarks[0].ExpandBookmark = true;
            (pdf.Bookmarks[1] as PdfBookmarkCollection)[0].ExpandBookmark = false;

            //Save the file
            String result = "ExpandSpecificBookmarks_output.pdf";
            pdf.SaveToFile(result);

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
