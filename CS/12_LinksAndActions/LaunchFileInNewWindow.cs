using Spire.Pdf;
using Spire.Pdf.Texts;
using Spire.Pdf.Actions;
using Spire.Pdf.Annotations;
using System;
using System.Collections.Generic;
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
            // Load an existing PDF document from disk.
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\DocumentsLinks.pdf");

            List<PdfTextFragment> collection = null;
            string[] test = { "Spire.PDF" };

            // Iterate through each page of the PDF document.
            foreach (PdfPageBase page in pdf.Pages)
            {
                // Iterate through each keyword in the 'test' array.
                for (int i = 0; i < test.Length; i++)
                {
                    // Create a PdfTextFinder to search for the keyword in the current page.
                    PdfTextFinder finder = new PdfTextFinder(page);
                    finder.Options.Parameter = TextFindParameter.WholeWord;

                    // Find all occurrences of the keyword on the current page.
                    collection = finder.Find(test[i]);

                    // Iterate through each found text fragment.
                    foreach (PdfTextFragment find in collection)
                    {
                        // Create a PdfLaunchAction to launch a file when the annotation is clicked.
                        PdfLaunchAction launchAction = new PdfLaunchAction(@"..\..\..\..\..\..\Data\Sample.pdf", PdfFilePathType.Relative);

                        // Set the launch action to open the file in a new window.
                        launchAction.IsNewWindow = true;

                        // Get the position and size of the found text fragment.
                        RectangleF rect = new RectangleF(find.Positions[0].X, find.Positions[0].Y, find.Sizes[0].Width, find.Sizes[0].Height);

                        // Create a PdfActionAnnotation with the launch action and the annotation rectangle.
                        PdfActionAnnotation annotation = new PdfActionAnnotation(rect, launchAction);

                        // Add the annotation to the current page.
                        (page as PdfPageWidget).Annotations.Add(annotation);
                    }
                }
            }

            // Save the modified PDF document to a new file.
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
