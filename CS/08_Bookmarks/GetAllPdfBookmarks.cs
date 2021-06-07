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

namespace GetAllPdfBookmarks
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

            //Get bookmarks collection of the Pdf file.
            PdfBookmarkCollection bookmarks = doc.Bookmarks;

            String result = "GetPdfBookmarks.txt";

            //Get Pdf Bookmarks.
            GetBookmarks(bookmarks, result);

            //Launch the file.
            DocumentViewer(result);
        }

        private void GetBookmarks(PdfBookmarkCollection bookmarks, string result)
        {
            //Declare a new StringBuilder content
            StringBuilder content = new StringBuilder();

            //Get Pdf bookmarks information.
            if (bookmarks.Count > 0)
            {
                content.AppendLine("Pdf bookmarks:");
                foreach (PdfBookmark parentBookmark in bookmarks)
                {
                    //Get the title.
                    content.AppendLine(parentBookmark.Title);
            
                    //Get the text style.
                    string textStyle = parentBookmark.DisplayStyle.ToString();
                    content.AppendLine(textStyle);
                    GetChildBookmark(parentBookmark,content);
                }
            }

            //Save to file.
            File.WriteAllText(result, content.ToString());
        }

        private void GetChildBookmark(PdfBookmark parentBookmark, StringBuilder content)
        {
            if (parentBookmark.Count > 0)
            {
                foreach (PdfBookmark childBookmark in parentBookmark)
                {
                    //Get the title.
                    content.AppendLine(childBookmark.Title);

                    //Get the text style.
                    string textStyle = childBookmark.DisplayStyle.ToString();
                    content.AppendLine(textStyle);
                    GetChildBookmark(childBookmark, content);
                }
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
