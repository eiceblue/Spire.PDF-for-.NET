using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using System.IO;
namespace ExtractTextFromSpecificArea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         private void button1_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Data\ExtractTextFromSpecificArea.pdf";

            //Load the PDF file
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(input);

            //Get the first page
            PdfPageBase page = pdf.Pages[0];

            //Extract text from a specific rectangular area within the page
            string text = page.ExtractText(new RectangleF(80, 180, 500, 200));

            //Save the text to a .txt file
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(text);
           string result ="ExtractText_result.txt";
           File.WriteAllText(result, sb.ToString());

           Viewer(result);
        }
        private void Viewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
