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
            String input = "..\\..\\..\\..\\..\\..\\Data\\PDFTemplate-Az.pdf";
            PdfDocument doc = new PdfDocument();
            // Read a pdf file
            doc.LoadFromFile(input);

            PdfViewerPreferences viewer = doc.ViewerPreferences;

            // Create a StringBuilder object to put the details
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Whether the documents window position is in the center: ");
            builder.AppendLine("CenterWindow: " + viewer.CenterWindow.ToString());
            builder.AppendLine("Document displaying mode, i.e. show thumbnails, full-screen, show attachment panel: ");
            builder.AppendLine("PageMode: " + viewer.PageMode.ToString());
            builder.AppendLine("The page layout, i.e. single page, one column: ");
            builder.AppendLine("PageLayout: " + viewer.PageLayout.ToString());
            builder.AppendLine("Whether window's title bar should display document title: ");
            builder.AppendLine("DisplayTitle: " + viewer.DisplayTitle.ToString());  
            builder.AppendLine("Whether to resize the document's window to fit the size of the firstdisplayed page: ");
            builder.AppendLine("FitWindow:" + viewer.FitWindow.ToString());
            builder.AppendLine("Whether to hide menu bar of the viewer application: ");
            builder.AppendLine("HideMenubar: " + viewer.HideMenubar.ToString());
            builder.AppendLine("Whether to hide tool bar of the viewer application: ");
            builder.AppendLine("HideToolbar: " + viewer.HideToolbar.ToString());
            builder.AppendLine("Whether to hide UI elements like scroll bars and leave only the page contents displayed: ");
            builder.AppendLine("HideWindowUI: " + viewer.HideWindowUI.ToString());
       
            String result = "GetViewerPreference_out.txt";

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
