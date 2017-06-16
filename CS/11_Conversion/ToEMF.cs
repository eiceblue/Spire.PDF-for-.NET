using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToEMF
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
            string input = @"..\..\..\..\..\..\Data\Sample4.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument(input);

            //save to emf files
            for (int i = 0; i < doc.Pages.Count; i++)
            {
                String fileName = String.Format("Sample4-img-{0}.emf", i);
                using (Image image = doc.SaveAsImage(i,Spire.Pdf.Graphics.PdfImageType.Metafile, 300, 300))
                {
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Emf);
                    System.Diagnostics.Process.Start(fileName);
                }
            } 
        }
    }
}
