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

namespace RemoveBlankPages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Load the file from disk.
            document.LoadFromFile(@"..\..\..\..\..\..\Data\RemoveBlankPages.pdf");

            // Iterate through all pages in reverse order.
            for (int i = document.Pages.Count - 1; i >= 0; i--)
            {
                // Check if the current page is blank.
                if (document.Pages[i].IsBlank())
                {
                    // Remove the blank page from the document.
                    document.Pages.RemoveAt(i);
                }
                else
                {
                    // Convert the non-blank page to an image.
                    Image image = document.SaveAsImage(i, PdfImageType.Bitmap);

                    // Check if the image is blank.
                    if (IsImageBlank(image))
                    {
                        // If the image is blank, remove the corresponding PDF page.
                        document.Pages.RemoveAt(i);
                    }

                    //////////////////Use the following code for netstandard dlls/////////////////////////
                    /*
                    var image = document.SaveAsImage(i, Spire.Pdf.Graphics.PdfImageType.Bitmap);
                    image.Position = 0;
                    byte[] bytes = new byte[image.Length];
                    image.Read(bytes, 0, bytes.Length);
                    var bmp = SkiaSharp.SKBitmap.Decode(bytes);
                    var resized = bmp.Resize(new SkiaSharp.SKImageInfo(1, 1), SkiaSharp.SKSamplingOptions.Default);
                    var pixel = resized.GetPixel(0, 0);
                    if (pixel == null || (pixel.Red > 240 && pixel.Green > 240 && pixel.Blue > 240))
                    {
                        document.Pages.RemoveAt(i);
                    }
                    */
                }
            }

            // Define the output file name.
            String result = "RemoveBlankPages_out.pdf";

            // Save the modified document to the specified output file.
            document.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }

        public static bool IsImageBlank(Image image)
        {
            // Convert the Image object to a Bitmap object for pixel manipulation.
            Bitmap bitmap = new Bitmap(image);

            // Iterate through each pixel in the image.
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    // Get the color of the current pixel.
                    Color pixel = bitmap.GetPixel(i, j);

                    // Check if any of the RGB values of the pixel are less than 240.
                    // If any of the RGB values are less than 240, it means the pixel is not blank.
                    if (pixel.R < 240 || pixel.G < 240 || pixel.B < 240)
                    {
                        // Return false since a non-blank pixel is found.
                        return false;
                    }
                }
            }

            // If all pixels are blank (i.e., all RGB values are greater than or equal to 240), return true.
            return true;
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
