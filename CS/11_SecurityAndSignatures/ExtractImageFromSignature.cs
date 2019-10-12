using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using Spire.Pdf.General.Find;
using System.Drawing.Imaging;
using Spire.Pdf.Widget;
namespace ExtractImageFromSignature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String input = "..\\..\\..\\..\\..\\..\\Data\\ExtractImageFromSignature.pdf";
            PdfDocument doc = new PdfDocument();

            // Read a pdf file
            doc.LoadFromFile(input);

            //Get the existing form of the document
            PdfFormWidget form = doc.Form as PdfFormWidget;

            //Extract images from signatures in the existing form
            Image[] images = form.ExtractSignatureAsImages();

            //Save the images to disk
            int i = 0;
            for (int j = 0; j < images.Length; j++)
            {
                images[j].Save(String.Format(@"Image-{0}.png", i), ImageFormat.Png);
                i++;
            }
            MessageBox.Show("Images have been sucessfully extracted.");
        }
    }
}
