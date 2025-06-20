using Spire.Pdf.Graphics;
using Spire.Additions.Qt;
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
            // Note: You need to download the Plugin from our website: https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/Convert-HTML-to-PDF-with-New-Plugin.html
            HtmlConverter.PluginPath = @"..\..\..\..\..\..\Data\plugins";

            // Convert a URL to PDF
            ConvertURLToPDF();

            // Convert an HTML string to PDF
            ConvertHtmlStringToPDF();

        }

        private void ConvertURLToPDF()
        {
            // Convert a web page (https://www.e-iceblue.com/) to PDF

            // Enable JavaScript execution
            bool enableJavaScript = true;

            // Set the load timeout in milliseconds
            int loadTimeout = 100 * 1000;

            // Set the page size to 612x792 points (8.5x11 inches)
            SizeF pageSize = new SizeF(612, 792);

            // Set the page margins to 0 inch
            PdfMargins margins = new PdfMargins(0, 0);

            // Perform the conversion by calling the Convert method of HtmlConverter
            HtmlConverter.Convert("https://www.e-iceblue.com/", "HTMLtoPDF.pdf", enableJavaScript, loadTimeout, pageSize, margins);
        }

        private void ConvertHtmlStringToPDF()
        {
            // Convert an HTML string to PDF

            // Specify the input HTML string
            string input = @"<strong>This is a test for converting HTML string to PDF </strong>
        <ul><li>Spire.PDF supports converting HTML in URL into PDF</li>
        <li>Spire.PDF supports converting HTML string into PDF</li>
        <li>With the new plugin</li></ul>";

            // Specify the output file name
            string outputFile = "ToPDF.pdf";

            // Enable JavaScript execution
            bool enableJavaScript = true;

            // Set the load timeout in milliseconds
            int loadTimeout = 10 * 1000;

            // Set the page size to 612x792 points (8.5x11 inches)
            SizeF pageSize = new SizeF(612, 792);

            // Set the page margins to 0 inch
            PdfMargins margins = new PdfMargins(0);

            // Specify that the input is provided as HTML source code
            LoadHtmlType htmlSourceType = LoadHtmlType.SourceCode;

            // Perform the conversion by calling the Convert method of HtmlConverter
            HtmlConverter.Convert(input, outputFile, enableJavaScript, loadTimeout, pageSize, margins, htmlSourceType);
        }
    }
}
