﻿using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetPageInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PdfDocument object.
            PdfDocument doc = new PdfDocument();

            // Load an existing PDF document from the specified file path.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\GetPageInfo.pdf");

            // Get the first page of the loaded PDF document.
            PdfPageBase page = doc.Pages[0];

            // Get the size and position of the MediaBox for the page in points.
            float MediaBoxWidth = page.MediaBox.Width;
            float MediaBoxHeight = page.MediaBox.Height;
            float MediaBoxX = page.MediaBox.X;
            float MediaBoxY = page.MediaBox.Y;

            // Get the size and position of the BleedBox for the page in points.
            float BleedBoxWidth = page.BleedBox.Width;
            float BleedBoxHeight = page.BleedBox.Height;
            float BleedBoxX = page.BleedBox.X;
            float BleedBoxY = page.BleedBox.Y;

            // Get the size and position of the CropBox for the page in points.
            float CropBoxWidth = page.CropBox.Width;
            float CropBoxHeight = page.CropBox.Height;
            float CropBoxX = page.CropBox.X;
            float CropBoxY = page.CropBox.Y;

            // Get the size and position of the ArtBox for the page in points.
            float ArtBoxWidth = page.ArtBox.Width;
            float ArtBoxHeight = page.ArtBox.Height;
            float ArtBoxX = page.ArtBox.X;
            float ArtBoxY = page.ArtBox.Y;

            // Get the size and position of the TrimBox for the page in points.
            float TrimBoxWidth = page.TrimBox.Width;
            float TrimBoxHeight = page.TrimBox.Height;
            float TrimBoxX = page.TrimBox.X;
            float TrimBoxY = page.TrimBox.Y;

            // Get the actual width and height of the page in points.
            float actualSizeW = page.ActualSize.Width;
            float actualSizeH = page.ActualSize.Height;

            // Get the rotation angle of the current page.
            PdfPageRotateAngle rotationAngle = page.Rotation;
            string rotation = rotationAngle.ToString();

            // Create a StringBuilder to store the page information.
            StringBuilder content = new StringBuilder();

            // Add the page information strings to the StringBuilder.
            content.AppendLine("MediaBox width: " + MediaBoxWidth + "pt, height: " + MediaBoxHeight + "pt, RectangleF X: " + MediaBoxX + "pt, RectangleF Y: " + MediaBoxY + "pt.");
            content.AppendLine("BleedBox width: " + BleedBoxWidth + "pt,  height: " + BleedBoxHeight + "pt, RectangleF X: " + BleedBoxX + "pt, RectangleF Y: " + BleedBoxY + "pt.");
            content.AppendLine("CropBox width: " + CropBoxWidth + "pt,  height: " + CropBoxHeight + "pt, RectangleF X: " + CropBoxX + "pt, RectangleF Y: " + CropBoxY + "pt.");
            content.AppendLine("ArtBox width: " + ArtBoxWidth + "pt,  height: " + ArtBoxHeight + "pt, RectangleF X: " + ArtBoxX + "pt, RectangleF Y: " + ArtBoxY + "pt.");
            content.AppendLine("TrimBox width: " + TrimBoxWidth + "pt,  height: " + TrimBoxHeight + "pt, RectangleF X: " + TrimBoxX + "pt, RectangleF Y: " + TrimBoxY + "pt.");
            content.AppendLine("The actual size of the current page width: " + actualSizeW);
            content.AppendLine("The actual size of the current page height: " + actualSizeH);
            content.AppendLine("The rotation angle of the current page: " + rotation);

            // Specify the output file name for saving the page information.
            String result = "PageInfo.txt";

            // Save the page information to a text file with the specified file name.
            File.WriteAllText(result, content.ToString());

            //Launch the file
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
