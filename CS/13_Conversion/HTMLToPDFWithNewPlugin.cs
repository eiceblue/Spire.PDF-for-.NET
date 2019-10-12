using Spire.Pdf.Graphics;
using Spire.Pdf.HtmlConverter;
using Spire.Pdf.HtmlConverter.Qt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTMLToPDFWithNewPlugin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Note you need to download Plugin from our website: https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/Convert-HTML-to-PDF-with-New-Plugin.html

            ConvertURLToPDF();
            ConvertHtmlStringToPDF();

        }

        private void ConvertURLToPDF()
        {
            Spire.Pdf.HtmlConverter.Qt.HtmlConverter.Convert("https://www.e-iceblue.com/", "HTMLtoPDF.pdf",

            //enable javascript
            true,

            //load timeout
            100 * 1000,

            //page size
            new SizeF(612, 792),

            //page margins
            new PdfMargins(0, 0));
        }

        private void ConvertHtmlStringToPDF()
        {
            string input = @"<strong>This is a test for converting HTML string to PDF </strong>
                 <ul><li>Spire.PDF supports to convert HTML in URL into PDF</li>
                 <li>Spire.PDF supports to convert HTML string into PDF</li>
                 <li>With the new plugin</li></ul>";

            string outputFile = "ToPDF.pdf";

            Spire.Pdf.HtmlConverter.Qt.HtmlConverter.Convert(input,

            outputFile,
            //enable javascript
            true,
            //load timeout
            10 * 1000,
            //page size
            new SizeF(612, 792),
            //page margins
            new Spire.Pdf.Graphics.PdfMargins(0),
            //load from content type
            LoadHtmlType.SourceCode
            );
        }
    }
}
