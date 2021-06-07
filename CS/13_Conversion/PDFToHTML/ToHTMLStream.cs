using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToHTMLStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document.
            PdfDocument pdf = new PdfDocument();
            //Load file from disk
            pdf.LoadFromFile(@"..\..\..\..\..\..\..\Data\SampleB_1.pdf");

            MemoryStream ms = new MemoryStream();
            //Save to HTML stream
            pdf.SaveToStream(ms, FileFormat.HTML);
			File.WriteAllBytes("ToHtml.html", ms.ToArray());
        }
    }
}
