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

            // Specify the path of the input PDF file
            // The file is located using a relative path
            doc.LoadFromFile(input);

            // Get the existing form from the document
            PdfFormWidget form = doc.Form as PdfFormWidget;

            // Extract images from the signatures in the existing form
            // The extracted images will be stored in an array
            Image[] images = form.ExtractSignatureAsImages();

            // Save the extracted images to disk
            int i = 0;
            for (int j = 0; j < images.Length; j++)
            {
                // Save each image with a unique name using the index value
                // The images are saved in PNG format
                images[j].Save(String.Format(@"Image-{0}.png", i), ImageFormat.Png);
                i++;
            }
            MessageBox.Show("Images have been sucessfully extracted.");
        }
    }
}
