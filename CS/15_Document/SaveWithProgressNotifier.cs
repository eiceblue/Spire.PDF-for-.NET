using Spire.Pdf;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SaveWithProgressNotifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf instance
            PdfDocument doc = new PdfDocument();

            //Load from file and get the first page
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\findText.pdf");

            // Register a custom progress notifier to monitor the save operation's progress
            doc.RegisterProgressNotifier(new CustomProgressNotifier());

            // Save the document to an XPS file
            doc.SaveToFile("SaveWithProgressNotifier_output.xps", FileFormat.XPS);

            // Close the document
            doc.Close();          

            this.Close();

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

public class CustomProgressNotifier : IProgressNotifier
{
    StringBuilder str = new StringBuilder();
    public void Notify(float progress)
    {
        str.AppendLine("==============Progress: " +progress + "%==============");
        File.WriteAllText("SaveWithProgressNotifier_output.txt", str.ToString());
    }
}
