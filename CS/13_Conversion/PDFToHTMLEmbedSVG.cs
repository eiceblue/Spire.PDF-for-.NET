using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmbedSVG
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
            String file = @"..\..\..\..\..\..\..\Data\SampleB_1.pdf";

            //Open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //Set the bool useEmbeddedSvg as true to convert to HTML with embeding SVG
            doc.ConvertOptions.SetPdfToHtmlOptions(true);


            String result = "ToHTMLWithEmbedingSVG_out.html";

            //Convert to html file
            doc.SaveToFile(result, FileFormat.HTML);
            doc.Close();

            //Launch result file
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
