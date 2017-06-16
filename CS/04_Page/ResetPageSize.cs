using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace ResetPageSize
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
            string input = "..\\..\\..\\..\\..\\..\\Data\\Sample5.pdf";

            string output = "ResetPageSize.pdf";

            //open pdf document
            PdfDocument originalDoc = new PdfDocument(input);

            //set margins
            PdfMargins margins = new PdfMargins(0);

            //create a new pdf document
            using (PdfDocument newDoc = new PdfDocument())
            {
                float scale = 0.8f;
                for (int i = 0; i < originalDoc.Pages.Count; i++)
                {
                    PdfPageBase page = originalDoc.Pages[i];

                    //use same scale to set width and height
                    float width = page.Size.Width * scale;
                    float height = page.Size.Height * scale;

                    //add new page with expected width and height
                    PdfPageBase newPage = newDoc.Pages.Add(new SizeF(width, height), margins);
                    newPage.Canvas.ScaleTransform(scale, scale);

                    //copy content of original page into new page
                    newPage.Canvas.DrawTemplate(page.CreateTemplate(), PointF.Empty);
                }
                //save pdf document
                newDoc.SaveToFile(output);
            }

            //Launch the Pdf file.
            PDFDocumentViewer(output);

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
