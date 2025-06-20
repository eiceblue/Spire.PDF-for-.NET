using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;


namespace AddCalendarDropdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument pdf = new PdfDocument();

            // Add a new page to the PDF document with A4 size and zero margins
            PdfPageBase page = pdf.Pages.Add(PdfPageSize.A4, new PdfMargins(0));

            // Create a TrueType font using Arial Unicode MS with a font size of 10
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial Unicode MS", 10f), true);

            // Create a new text box field on the page with the field name "date"
            PdfTextBoxField textbox = new PdfTextBoxField(page, "date");

            // Set the position and size of the text box
            textbox.Bounds = new RectangleF(40, 50, 60, 20);

            // Set the font for the text box
            textbox.Font = font;

            // Get the JavaScript keystroke string for date input in the format "mm/dd/yyyy"
            string kjs = PdfJavaScript.GetDateKeystrokeString("mm/dd/yyyy");

            // Get the JavaScript format string for date input in the format "mm/dd/yyyy"
            string fjs = PdfJavaScript.GetDateFormatString("mm/dd/yyyy");

            // Create JavaScript actions for the keystroke and format settings
            PdfJavaScriptAction kjsAction = new PdfJavaScriptAction(kjs);
            PdfJavaScriptAction fjsAction = new PdfJavaScriptAction(fjs);

            // Assign the JavaScript actions to the text box
            textbox.Actions.KeyPressed = kjsAction;
            textbox.Actions.Format = fjsAction;

            // Add the text box field to the form fields collection of the PDF document
            pdf.Form.Fields.Add(textbox);

            // Save the PDF document to a file
            string result = "AddCalendarDropdown_result.pdf";
            pdf.SaveToFile(result);

            // Close the PDF document
            pdf.Close();

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
