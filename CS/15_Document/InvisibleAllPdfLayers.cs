using Spire.Pdf;
using Spire.Pdf.Graphics.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvisibleAllPdfLayers
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
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_5.pdf");

            for (int i = 0; i < doc.Layers.Count; i++)
            {
                //Show all the Pdf layers.
                //doc.Layers[i].Visibility = PdfVisibility.On;

                //Set all the Pdf layers invisible.
                doc.Layers[i].Visibility = PdfVisibility.Off;
            }

            String result = "InvisibleAllPdfLayers_out.pdf";

            //Save the document
            doc.SaveToFile(result);
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
