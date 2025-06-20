using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;

namespace GetNumberOfPages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF document (*.pdf)|*.pdf";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string pdfFile = dialog.FileName;
                  
                    //Open a pdf document and get its page count
                    using (PdfDocument pdf = new PdfDocument())
                    {
                        // Load the PDF document from the specified file path.
                        pdf.LoadFromFile(pdfFile);

                        // Get the number of pages in the PDF document.
                        int count = pdf.Pages.Count;

                        MessageBox.Show("The page count of the pdf document is " + count);
                    }
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message, "Spire.Pdf Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
