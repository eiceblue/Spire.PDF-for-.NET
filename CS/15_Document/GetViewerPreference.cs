using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.IO;

namespace GetViewerPreference
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Define the input file path for the PDF document
            String input = "..\\..\\..\\..\\..\\..\\Data\\PDFTemplate-Az.pdf";

            // Create a new PdfDocument object to load the PDF file
            PdfDocument doc = new PdfDocument();

            // Read the PDF file from the specified input file path
            doc.LoadFromFile(input);

            // Get the viewer preferences for the loaded PDF document
            PdfViewerPreferences viewer = doc.ViewerPreferences;

            // Create a StringBuilder object to store the details of the viewer preferences
            StringBuilder builder = new StringBuilder();

            // Append a line to the StringBuilder object with the title of the section
            builder.AppendLine("Whether the documents window position is in the center: ");

            // Append a line to the StringBuilder object with the value of the CenterWindow property
            builder.AppendLine("CenterWindow: " + viewer.CenterWindow.ToString());

            // Append a line to the StringBuilder object with the title of the section
            builder.AppendLine("Document displaying mode, i.e. show thumbnails, full-screen, show attachment panel: ");

            // Append a line to the StringBuilder object with the value of the PageMode property
            builder.AppendLine("PageMode: " + viewer.PageMode.ToString());

            // Append a line to the StringBuilder object with the title of the section
            builder.AppendLine("The page layout, i.e. single page, one column: ");

            // Append a line to the StringBuilder object with the value of the PageLayout property
            builder.AppendLine("PageLayout: " + viewer.PageLayout.ToString());

            // Append a line to the StringBuilder object with the title of the section
            builder.AppendLine("Whether window's title bar should display document title: ");

            // Append a line to the StringBuilder object with the value of the DisplayTitle property
            builder.AppendLine("DisplayTitle: " + viewer.DisplayTitle.ToString());

            // Append a line to the StringBuilder object with the title of the section
            builder.AppendLine("Whether to resize the document's window to fit the size of the first displayed page: ");

            // Append a line to the StringBuilder object with the value of the FitWindow property
            builder.AppendLine("FitWindow:" + viewer.FitWindow.ToString());

            // Append a line to the StringBuilder object with the title of the section
            builder.AppendLine("Whether to hide menu bar of the viewer application: ");

            // Append a line to the StringBuilder object with the value of the HideMenubar property
            builder.AppendLine("HideMenubar: " + viewer.HideMenubar.ToString());

            // Append a line to the StringBuilder object with the title of the section
            builder.AppendLine("Whether to hide tool bar of the viewer application: ");

            // Append a line to the StringBuilder object with the value of the HideToolbar property
            builder.AppendLine("HideToolbar: " + viewer.HideToolbar.ToString());

            // Append a line to the StringBuilder object with the title of the section
            builder.AppendLine("Whether to hide UI elements like scroll bars and leave only the page contents displayed: ");

            // Append a line to the StringBuilder object with the value of the HideWindowUI property
            builder.AppendLine("HideWindowUI: " + viewer.HideWindowUI.ToString());

            // Define the output file path for the text file containing the viewer preferences details
            String result = "GetViewerPreference_out.txt";

            // Write the contents of the StringBuilder object to a text file at the specified output file path
            File.WriteAllText(result, builder.ToString());

            //Launch the result file
            DocumentViewer(result);
        }

        private void DocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
