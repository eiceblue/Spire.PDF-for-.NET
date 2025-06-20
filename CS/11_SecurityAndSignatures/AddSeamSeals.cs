using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddSeamSeals
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

            //Load the document from disk.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\AddSeamSeals.pdf");

            PdfUnitConvertor convert = new PdfUnitConvertor();
            PdfPageBase pageBase = null;

            //Get the segmented seal image.
            Image[] images = GetImage(doc.Pages.Count);
            float x = 0;
            float y = 0;

            //Draw the picture to the designated location on the PDF page.
            for (int i = 0; i < doc.Pages.Count; i++)
            {
                pageBase = doc.Pages[i];
                x = pageBase.Size.Width - convert.ConvertToPixels(images[i].Width, PdfGraphicsUnit.Point)+40;
                y = pageBase.Size.Height / 2;
                pageBase.Canvas.DrawImage(PdfImage.FromImage(images[i]), new PointF(x, y));
            }

            String result = "AddSeamSeals_out.pdf";

            //Save the Pdf file.
            doc.SaveToFile(result);

            //Launch the Pdf file.
            PDFDocumentViewer(result); 
        }
        // Define the GetImage method to segment the seal image according to the number of PDF pages.
        static Image[] GetImage(int num)
        {
            // Create a list to store segmented images.
            List<Image> lists = new List<Image>();

            // Load the original seal image from the specified path.
            Image image = Image.FromFile(@"..\..\..\..\..\..\Data\SealImage.jpg");

            // Calculate the width of each segmented image based on the number of pages.
            int w = image.Width / num;

            // Initialize a Bitmap object.
            Bitmap bitmap = null;

            // Iterate through each segment.
            for (int i = 0; i < num; i++)
            {
                // Create a new Bitmap with the calculated width and the height of the original image.
                bitmap = new Bitmap(w, image.Height);

                // Create a Graphics object from the Bitmap to draw on it.
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
                {
                    // Clear the graphics surface with a white background.
                    g.Clear(Color.White);

                    // Define a rectangle to specify the portion of the original image to be drawn on the segment.
                    Rectangle rect = new Rectangle(i * w, 0, w, image.Height);

                    // Draw the portion of the original image onto the segment.
                    g.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), rect, GraphicsUnit.Pixel);
                }

                // Add the segmented image to the list.
                lists.Add(bitmap);
            }

            // Convert the list of segmented images to an array and return it.
            return lists.ToArray();
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
