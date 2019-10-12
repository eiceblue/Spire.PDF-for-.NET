using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AssignIconToButtonField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a PDF document       
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();

            //Create a Button
            PdfButtonField btn = new PdfButtonField(page, "button1");
            btn.Bounds = new RectangleF(0, 50, 120, 100);
            btn.HighlightMode = PdfHighlightMode.Push;
            btn.LayoutMode = PdfButtonLayoutMode.CaptionOverlayIcon;

            //Set text and icon for Normal appearance
            btn.Text = "Normal Text";
            btn.Icon = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png");

            //Set text and icon for Click appearance (Can only be set when highlight mode is Push)
            btn.AlternateText = "Alternate Text";
            btn.AlternateIcon = PdfImage.FromFile(@"..\..\..\..\..\..\Data\PdfImage.png");

            //Set text and icon for Rollover appearance (Can only be set when highlight mode is Push)
            btn.RolloverText = "Rollover Text";
            btn.RolloverIcon = PdfImage.FromFile(@"..\..\..\..\..\..\Data\PDFJAVA.png");

            //Set icon layout
            btn.IconLayout.Spaces = new float[] { 0.5f, 0.5f };
            btn.IconLayout.ScaleMode = PdfButtonIconScaleMode.Proportional;
            btn.IconLayout.ScaleReason = PdfButtonIconScaleReason.Always;
            btn.IconLayout.IsFitBounds = false;

            //Add the button to the document
            doc.Form.Fields.Add(btn);

            String result = "AssignIconToButtonField-result.pdf";

            //Save the document
            doc.SaveToFile(result); 
            
            //Launch the Pdf file
            PDFDocumentViewer(result);

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
