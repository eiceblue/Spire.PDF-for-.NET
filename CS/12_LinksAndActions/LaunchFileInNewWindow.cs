using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Interactive.Annotations;
using Spire.Pdf.Texts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            // Load an existing PDF document from disk.
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\DocumentsLinks.pdf");

            //Define the variables
            // PdfTextFinder[] finds = null;
            string[] test = { "Spire.PDF" };

            //Traverse the pages
            foreach (PdfPageBase page in pdf.Pages)
            {
                PdfTextFinder finds = new PdfTextFinder(page);
                for (int i = 0; i < test.Length; i++)
                {
                    //Find the defined string
                    finds.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.WholeWord;
                    List<PdfTextFragment> result = finds.Find(test[i]);

                    //Traverse the finds
                    foreach (PdfTextFragment find in result)
                    {
                        PdfLaunchAction launchAction = new PdfLaunchAction(@"..\..\..\..\..\..\Data\Sample.pdf", PdfFilePathType.Relative);

                        //Set open document in a new window
                        launchAction.NewWindow = true;

                        //Add annotation
                        RectangleF rect = new RectangleF(result.First().Positions[0].X, result.First().Positions[0].Y, result.First().Sizes[0].Width, result.First().Sizes[0].Height);
                        PdfLinkAnnotation annotation = new PdfLinkAnnotation(page, rect, launchAction);
                        PdfAnnotationCollection.Create(page).Add(annotation);
                    }
                }
            }

            // Save the modified PDF document to a new file.
            String outputFile = "LaunchFileInNewWindow.pdf";
            pdf.SaveToFile(outputFile);

            //Launch the file.
            DocumentViewer(outputFile);
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
