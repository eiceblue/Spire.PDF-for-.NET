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

namespace SetInheritZoom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a new PDF document
            PdfDocument pdfdoc = new PdfDocument();

            //load the document from disk
            pdfdoc.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_1.pdf");

            //Get bookmarks collections of the PDF file
            PdfBookmarkCollection bookmarks = pdfdoc.Bookmarks;

            //Set Zoom level as 0, which the value is inherit zoom
            foreach (PdfBookmark bookMark in bookmarks)
            {
                bookMark.Destination.Zoom = 0.5f;
            }

            String result = "SetInheritZoom_out.pdf";

            //Save the document
            pdfdoc.SaveToFile(result);
            //Launch the Pdf file
            PDFDocumentViewer(result);
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
