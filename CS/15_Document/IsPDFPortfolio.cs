using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IsPDFPortfolio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Load from file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\TextBoxSampleB_1.pdf");

            //Judge whether the document is portfolio or not.
            bool value = doc.IsPortfolio;
            if (value)
            {
                MessageBox.Show("The document is portfolio");
            }
            else
            {
                MessageBox.Show("The document is not portfolio");
            }
        }
    }
}
