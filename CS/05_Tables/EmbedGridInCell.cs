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

namespace EmbedGridInCell
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
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\EmbedGridInCell.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Create a pdf grid
            PdfGrid grid = new PdfGrid();

            //Add a row 
            PdfGridRow row = grid.Rows.Add();

            //Add two columns
            grid.Columns.Add(2);

            //Set the width of the first column
            grid.Columns[0].Width = 120;
            grid.Columns[1].Width = 300;

            SizeF imageSize = new SizeF(70, 70);
            float LR = (grid.Columns[0].Width - imageSize.Width) / 2;

            //Set the cell padding
            grid.Style.CellPadding = new PdfPaddings(LR, LR, 1, 1);

            //Add an image
            PdfGridCellContentList list = new PdfGridCellContentList();
            PdfGridCellContent textAndStyle = new PdfGridCellContent();
            textAndStyle.Image = PdfImage.FromFile(@"..\..\..\..\..\..\Data\E-iceblueLogo.png");


            //Set the size of image
            textAndStyle.ImageSize = imageSize;
            list.List.Add(textAndStyle);

            //Add an image into the first cell 
            row.Cells[0].Value = list;

            //Create another grid
            PdfGrid grid2 = new PdfGrid();
            grid2.Columns.Add(2);
            PdfGridRow newrow = grid2.Rows.Add();
            grid2.Columns[0].Width = 120;
            grid2.Columns[1].Width = 120;

            //Set value for newrow and set string format for it
            newrow.Cells[0].Value = "Embeded grid";
            newrow.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            newrow.Cells[1].Value = "Embeded grid";
            newrow.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            //Assign grid2 to the cell
            row.Cells[1].Value = grid2;
            row.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            String[] data
                = {
                    "VendorName;Address1 & City & State & Country",
                    "Cacor Corporation;161 Southfield Rd  & Southfield & OH & U.S.A.",
                    "Underwater; 50 N 3rd Street & Indianapolis & IN & U.S.A.",
                    "J.W.  Luscher;65 Addams Street & Berkely & MA & U.S.A.",
                    "Scuba;3105 East Brace & Rancho Dominguez & CA & U.S.A.",
                    "Divers Supply;5208 University Dr & Macon & GA & U.S.A.",
                    "Techniques;52 Dolphin Drive & Redwood City & CA & U.S.A.",
                    "Perry Scuba; 3443 James Ave & Hapeville & GA & U.S.A.",
                    "Beauchat, Inc.;45900 SW 2nd Ave & Ft Lauderdale & FL & U.S.A.",
                    "Amor Aqua;42 West 29th Street & New York & NY & U.S.A.",
                    "Aqua Research;P.O. Box 998 & Cornish & NH & U.S.A.",
                    "B&K Undersea;116 W 7th Street & New York & NY & U.S.A.",
                    "Diving;1148 David Drive & San Diego & DA & U.S.A.",
                    "Nautical;65 NW 167 Street & Miami & FL & U.S.A.",
                    "Glen Specialties;17663 Campbell Lane & Huntington Beach & CA & U.S.A.",
                    "Dive Time;20 Miramar Ave & Long Beach & CA & U.S.A.",
                    "Undersea Systems;18112 Gotham Street & Huntington Beach & C & U.S.A.",
                  };

            //Insert data to grid
            for (int r = 0; r < data.Length; r++)
            {
                PdfGridRow row1 = grid.Rows.Add();
                String[] rowData = data[r].Split(';');
                for (int c = 0; c < rowData.Length; c++)
                {
                    row1.Cells[c].Value = rowData[c];

                    //Set string format for row
                    row1.Cells[c].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                }
            }


            //Draw pdf grid into page at a specific location
            grid.Draw(page, new PointF(50, 330));

            //Save the pdf document
            doc.SaveToFile("EmbedGridInCell.pdf");

            //Launch the document
            PDFDocumentViewer("EmbedGridInCell.pdf");
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
