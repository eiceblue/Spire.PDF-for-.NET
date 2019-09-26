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
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Load the file from disk.
            document.LoadFromFile(@"..\..\..\..\..\..\Data\RemoveBlankPages.pdf");


            for (int i = document.Pages.Count - 1; i >= 0; i--)
            {
                if (document.Pages[i].IsBlank())
                {
                    //Remove blank page
                    document.Pages.RemoveAt(i);
                }
                else
                {
                    //Convert the page to a picture if it is not a blank page.
                    Image image = document.SaveAsImage(i, PdfImageType.Bitmap);

                    //Determine whether a picture is blank or not.
                    if (IsImageBlank(image))
                    {
                        //Delete the corresponding PDF page if the picture is blank.
                        document.Pages.RemoveAt(i);
                    }
                }
            }
            String result = "RemoveBlankPages_out.pdf";

            //Save the document
            document.SaveToFile(result);
            //Launch the Pdf file
            PDFDocumentViewer(result);
        }

        public static bool IsImageBlank(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    if (pixel.R < 240 || pixel.G < 240 || pixel.B < 240)
                    {
                        return false;
                    }
                }
            }
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
