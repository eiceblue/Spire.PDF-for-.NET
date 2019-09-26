using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Fields;
namespace AddTooltipToText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Create one page
            PdfPageBase page = doc.Pages.Add();

            page.Canvas.DrawString("Move the mouse cursor over the following text to display a tooltip", new PdfTrueTypeFont(new Font("Arial", 15), true), PdfBrushes.Black, new PointF(10, 20));

            //Define the text and its style
            String text1 = "Your Office Development Master";
            PdfTrueTypeFont font1 =new PdfTrueTypeFont(new Font("Arial",18),true);
            SizeF sizeF1= font1.MeasureString(text1);
            RectangleF rec1 = new RectangleF(new Point(100,100), sizeF1);
            //Draw text 
            page.Canvas.DrawString(text1, font1, new PdfSolidBrush(Color.Blue), rec1);

            //Create invisible button on text position
            PdfButtonField field1 = new PdfButtonField(page, "field1");
            //Set the bounds and size of field
            field1.Bounds = rec1;
            //Set tooltip content
            field1.ToolTip = "E-iceblue Co. Ltd., a vendor of .NET, Java and WPF development components";
            //Set no border for field
            field1.BorderWidth = 0;
            //Set backcolor and forcolor for field
            field1.BackColor = Color.Transparent;
            field1.ForeColor = Color.Transparent;
            field1.LayoutMode = PdfButtonLayoutMode.IconOnly;
            field1.IconLayout.IsFitBounds = true;

            //Define the text and its style 
            String text2 = "Spire.PDF";
            PdfFont font2 = new PdfFont(PdfFontFamily.TimesRoman, 20);
            SizeF sizeF2 = font2.MeasureString(text2);
            RectangleF rec2 = new RectangleF(new Point(100, 160), sizeF2);
            //Draw text 
            page.Canvas.DrawString(text2, font2, PdfBrushes.DarkOrange, rec2);

            //Create invisible button on text position
            PdfButtonField field2 = new PdfButtonField(page, "field2");
            field2.Bounds = rec2;
            field2.ToolTip = "A professional PDF library applied to creating," +
                             "writing, editing, handling and reading PDF files" +
                             "without any external dependencies within .NET" +
                             "( C#, VB.NET, ASP.NET, .NET Core) application.";
            field2.BorderWidth = 0;
            field2.BackColor = Color.Transparent;
            field2.ForeColor = Color.Transparent;
            field2.LayoutMode = PdfButtonLayoutMode.IconOnly;
            field2.IconLayout.IsFitBounds = true;

            //Add the buttons to pdf form
            doc.AllowCreateForm = true;
            doc.Form.Fields.Add(field1);
            doc.Form.Fields.Add(field2);

            String result = "AddTooltipToText_out.pdf";

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
