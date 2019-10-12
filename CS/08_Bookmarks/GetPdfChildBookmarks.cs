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

namespace GetPdfChildBookmarks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a new Pdf document.
            PdfDocument doc = new PdfDocument();

            //Load the file from disk.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_1.pdf");

            //Get bookmarks collections of the PDF file.
            PdfBookmarkCollection bookmarks = doc.Bookmarks;

            string result = "GetPdfChildBookmarks_out.txt";

            //Get Pdf child Bookmarks.
            GetChildBookmarks(bookmarks, result);

            //Launch the file.
            DocumentViewer(result);
        }

        private void GetChildBookmarks(PdfBookmarkCollection bookmarks, string result)
        {
            //Declare a new StringBuilder content
            StringBuilder content = new StringBuilder();

            //Get Pdf child Bookmarks information.
            foreach (PdfBookmark parentBookmark in bookmarks)
            {
                if (parentBookmark.Count > 0)
                {
                    content.AppendLine("Child Bookmarks:");

                    foreach (PdfBookmark childBookmark in parentBookmark)
                    {
                        //Get the title
                        content.AppendLine(childBookmark.Title);

                        //Get the color.
                        string color = childBookmark.Color.ToString();
                        content.AppendLine(color);

                        //Get the text style.
                        string textStyle = childBookmark.DisplayStyle.ToString();
                        content.AppendLine(textStyle);
                    }
                }

                //Save to file.
                File.WriteAllText(result, content.ToString());
            }
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
