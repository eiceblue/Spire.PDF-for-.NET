using Spire.Pdf;
using System;
using System.Windows.Forms;

namespace SetTabOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load old PDF from disk.
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\SetTabOrder.pdf");

            //Set using document structure
            pdf.FileInfo.IncrementalUpdate = false;
            PdfPageBase page = pdf.Pages[0];
            page.SetTabOrder(TabOrder.Structure);

            //Save the file
            String result = "SetTabOrder_output.pdf";
            pdf.SaveToFile(result);

            //Launch the file.
            DocumentViewer(result);
        }
        private void DocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
