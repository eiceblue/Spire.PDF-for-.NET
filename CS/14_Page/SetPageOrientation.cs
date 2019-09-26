using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Spire.Pdf.Graphics;

namespace SetPageOrientation  
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
            PdfDocument doc = new PdfDocument();
            
            //Add a section
            PdfSection section = doc.Sections.Add();
                     
            //Load a image
            PdfImage image = PdfImage.FromFile(@"../../../../../../Data/scenery.jpg");
            
            //Check whether the width of the image file is greater than default page width or not
            if (image.PhysicalDimension.Width > section.PageSettings.Size.Width)

                //Set the orientation as landscape
                section.PageSettings.Orientation = PdfPageOrientation.Landscape;
            
            else
                section.PageSettings.Orientation = PdfPageOrientation.Portrait;

            //Add a new page with orientation Landscape
            PdfPageBase page = section.Pages.Add();

            //Draw the image on the page
            page.Canvas.DrawImage(image,new PointF(0,0));

            string output = "SetPageOrientation-result.pdf";
            //Save to file
            doc.SaveToFile(output);    

              
            //Launch the reuslt file
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
