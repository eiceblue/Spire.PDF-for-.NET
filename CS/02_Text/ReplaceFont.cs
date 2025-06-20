using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Graphics.Fonts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReplaceFont
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Load the document from disk 
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ReplaceFont.pdf");

            //Get the fonts used in PDF
            PdfUsedFont[] fonts = doc.UsedFonts;

            //Create a new font 
            PdfTrueTypeFont newfont = new PdfTrueTypeFont(new Font("Arial", 13f), true);

            // Iterate through each used fonts
            foreach (PdfUsedFont font in fonts)
            {
                //Replace the font with new font
                font.Replace(newfont);
            }

            //Save the document
            doc.SaveToFile("Output.pdf");

            //View the Pdf doc
            System.Diagnostics.Process.Start("Output.pdf");
        }
    }
}
