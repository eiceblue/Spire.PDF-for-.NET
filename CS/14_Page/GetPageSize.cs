using Spire.Pdf;
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

namespace GetPageSize 
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

            //Load an existing pdf from disk
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Sample.pdf");

            //Get the first page of the loaded PDF file
            PdfPageBase page = doc.Pages[0];

            //Get the width of page based on "point"
            float pointWidth = page.Size.Width;

            //Get the height of page
            float pointHeight = page.Size.Height;

            //Create PdfUnitConvertor to convert the unit
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();

            //Convert the size with "pixel"
            float pixelWidth = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Pixel);
            float pixelHeight = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Pixel);

            //Convert the size with "inch"
            float inchWidth = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Inch);
            float inchHeight = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Inch);

            //Convert the size with "centimeter"
            float centimeterWidth = unitCvtr.ConvertUnits(pointWidth, PdfGraphicsUnit.Point, PdfGraphicsUnit.Centimeter);
            float centimeterHeight = unitCvtr.ConvertUnits(pointHeight, PdfGraphicsUnit.Point, PdfGraphicsUnit.Centimeter);

            //Create StringBuilder to save 
            StringBuilder content = new StringBuilder();


            //Add pointSize string to StringBuilder
            content.AppendLine("The page size of the file is (width: " + pointWidth + "pt, height: " + pointHeight + "pt).");
            content.AppendLine("The page size of the file is (width: "+ pixelWidth + "pixel, height: "+ pixelHeight + "pixel).");
            content.AppendLine( "The page size of the file is (width: "+ inchWidth + "inch, height: " + inchHeight + "inch)." );
            content.AppendLine("The page size of the file is (width: " + centimeterWidth + "cm, height: " + centimeterHeight + "cm.)");

            String output = "GetPageSize_out.txt";

            //Save them to a txt file
            File.WriteAllText(output, content.ToString());

            //Launch the file
            DocumentViewer(output);
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
