using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToDoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load a PDF document from the specified file path.
            String file = @"..\..\..\..\..\..\Data\ToDoc.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            // Convert the loaded PDF document to a DOC file.
            doc.SaveToFile("ToDoc.doc", FileFormat.DOC);

            // Close the PDF document.
            doc.Close();

            //Launch the file.
            System.Diagnostics.Process.Start("ToDoc.doc");
        }
    }
}
