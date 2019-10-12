using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace DeleteImageFirstApproach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pdf file
            String file = @"..\..\..\..\..\..\Data\DeleteImage.pdf";

            //Open pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(file);

            //Get the first page
            PdfPageBase page = pdf.Pages[0];

            //Delete the first image on the page
            page.DeleteImage(page.ImagesInfo[0].Image);

            String result = "DeleteImage_out.pdf";

            //Save the document
            pdf.SaveToFile(result);
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
