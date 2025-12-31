using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChangeBorderColor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document and load file from disk
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@"..\..\..\..\..\..\Data\ChangeBorderColor.pdf");

            //Get the first page
            PdfPageBase page = document.Pages[0];

            String[] data
               = {
                    "VendorName;Address1;City;State;Country",
                    "Cacor Corporation;161 Southfield Rd;Southfield;OH;U.S.A.",
                    "Underwater;50 N 3rd Street;Indianapolis;IN;U.S.A.",
                    "J.W.  Luscher Mfg.;65 Addams Street;Berkely;MA;U.S.A.",
                    "Scuba Professionals;3105 East Brace;Rancho Dominguez;CA;U.S.A.",
                    "Divers'  Supply Shop;5208 University Dr;Macon;GA;U.S.A.",
                    "Techniques;52 Dolphin Drive;Redwood City;CA;U.S.A.",
                    "Perry Scuba;3443 James Ave;Hapeville;GA;U.S.A.",
                    "Beauchat, Inc.;45900 SW 2nd Ave;Ft Lauderdale;FL;U.S.A.",
                    "Amor Aqua;42 West 29th Street;New York;NY;U.S.A.",
                    "Aqua Research Corp.;P.O. Box 998;Cornish;NH;U.S.A.",
                    "B&K Undersea Photo;116 W 7th Street;New York;NY;U.S.A.",
                    "Diving International Unlimited;1148 David Drive;San Diego;DA;U.S.A.",
                    "Nautical Compressors;65 NW 167 Street;Miami;FL;U.S.A.",
                    "Glen Specialties, Inc.;17663 Campbell Lane;Huntington Beach;CA;U.S.A.",
                    "Dive Time;20 Miramar Ave;Long Beach;CA;U.S.A.",
                    "Undersea Systems, Inc.;18112 Gotham Street;Huntington Beach;CA;U.S.A.",
                    "Felix Diving;310 S Michigan Ave;Chicago;IL;U.S.A.",
                    "Central Valley Skin Divers;160 Jameston Ave;Jamaica;NY;U.S.A.",
                    "Parkway Dive Shop;241 Kelly Street;South Amboy;NJ;U.S.A.",
                    "Marine Camera & Dive;117 South Valley Rd;San Diego;CA;U.S.A.",
                    "Dive Canada;275 W Ninth Ave;Vancouver;British Columbia;Canada",
                    "Dive & Surf;P.O. Box 20210;Indianapolis;IN;U.S.A.",
                    "Fish Research Labs;29 Wilkins Rd Dept. SD;Los Banos;CA;U.S.A."
                 };

            //Create a grid
            PdfGrid grid = new PdfGrid();

            //Add rows
            for (int r = 0; r < data.Length; r++)
            {
                PdfGridRow row = grid.Rows.Add();
            }

            //Add columns
            grid.Columns.Add(5);

            //Set the width for column
            grid.Columns[0].Width = 120;
            grid.Columns[1].Width = 120;
            grid.Columns[2].Width = 120;
            grid.Columns[3].Width = 50;
            grid.Columns[4].Width = 60;


            //set the height of rows
            float height = page.Canvas.ClientSize.Height - (grid.Rows.Count + 1);
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].Height = 12.5f;
            }

            //Insert data to grid
            for (int r = 0; r < data.Length; r++)
            {
                String[] rowData = data[r].Split(';');
                for (int c = 0; c < rowData.Length; c++)
                {
                    grid.Rows[r].Cells[c].Value = rowData[c];
                }
            }

            grid.Rows[0].Style.Font = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Bold), true);


            //////////////////Use the following code for netstandard dlls/////////////////////////
            /*
             grid.Rows[0].Style.Font = new PdfTrueTypeFont("Arial", 8f, PdfFontStyle.Bold, true);
            */

            //Set color of border
            PdfBorders border = new PdfBorders();
            border.All = new PdfPen(Color.LightBlue);

            //Iterate each row of grid
            foreach (PdfGridRow pgr in grid.Rows)
            {
                foreach (PdfGridCell pgc in pgr.Cells)
                {
                    pgc.Style.Borders = border;
                }
            }

            //Draw the grid
            grid.Draw(page, new PointF(50, 330));

            //Save the pdf document
            document.SaveToFile("BorderColor.pdf");

            //Launch the pdf file
            PDFDocumentViewer("BorderColor.pdf");
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
