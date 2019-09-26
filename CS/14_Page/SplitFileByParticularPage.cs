using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
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

namespace SplitFileByParticularPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument oldPdf = new PdfDocument();

            //Load an existing pdf from disk
            oldPdf.LoadFromFile(@"..\..\..\..\..\..\Data\Sample.pdf");

            //Create a new PDF document
            PdfDocument newPdf = new PdfDocument();

            //Initialize a new instance of PdfPageBase class
            PdfPageBase page;

            //Specify the pages which you want them to be split
            for (int i = 1; i < 3; i++)
            {
                //Add same size page for newPdf
                page = newPdf.Pages.Add(oldPdf.Pages[i].Size, new Spire.Pdf.Graphics.PdfMargins(0));

                //Create template of the oldPdf page and draw into newPdf page
                oldPdf.Pages[i].CreateTemplate().Draw(page, new System.Drawing.PointF(0, 0));
            }

            String result = "SplitFileByParticularPage_out.pdf";

            //Save the document
            newPdf.SaveToFile(result);
            //Launch the Pdf file
            PDFDocumentViewer(result);
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
