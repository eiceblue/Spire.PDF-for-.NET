using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf.Graphics;


namespace GetTextSizeBasedOnFont
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder stringB = new StringBuilder();
            string text = "Spire.PDF for .NET";

            //Create an instance for PdfFont
            PdfFont font1 = new PdfFont(PdfFontFamily.TimesRoman, 12f);

            //Get text size based on font name and size
            SizeF sizeF1 = font1.MeasureString(text);
            stringB.AppendLine("1. The width is: " + sizeF1.Width + ", the height is: " + sizeF1.Height);

            //Create an instance for PdfTrueTypeFont
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Regular), true);

            //Get text size based on font name and size
            SizeF sizeF2 = font2.MeasureString(text);
            stringB.AppendLine("2. The width is: " + sizeF2.Width + ", the height is: " + sizeF2.Height);

            //Save the result txt file
            string result = "GetTextSizeBasedOnFont_out.txt";
            File.WriteAllText(result, stringB.ToString());

            //Launch the Txt file
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
