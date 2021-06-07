using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Annotations;
using Spire.Pdf.General.Find;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LaunchFileInNewWindow
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
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\DocumentsLinks.pdf");

            //Define the variables
            PdfTextFind[] finds = null;
            string[] test = { "Spire.PDF" };

            //Traverse the pages
            foreach (PdfPageBase page in pdf.Pages)
            {
                for (int i = 0; i < test.Length; i++)
                {
                    //Find the defined string
                    finds = page.FindText(test[i], TextFindParameter.WholeWord).Finds;

                    //Traverse the finds
                    foreach (PdfTextFind find in finds)
                    {
                        PdfLaunchAction launchAction = new PdfLaunchAction(@"..\..\..\..\..\..\Data\Sample.pdf", PdfFilePathType.Relative);
                        
                        //Set open document in a new window
                        launchAction.IsNewWindow = true;

                        //Add annotation
                        RectangleF rect = new RectangleF(find.Position.X, find.Position.Y, find.Size.Width, find.Size.Height);
                        PdfActionAnnotation annotation = new PdfActionAnnotation(rect, launchAction);
                        (page as PdfPageWidget).AnnotationsWidget.Add(annotation);
                    }
                }
            }
            //Save the file
            String result = "LaunchFileInNewWindow.pdf";
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
