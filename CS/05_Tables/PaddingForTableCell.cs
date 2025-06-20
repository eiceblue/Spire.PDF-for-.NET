﻿using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaddingForTableCell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load a PDF document from disk
            PdfDocument doc = new PdfDocument();

            // Add a page to the document with A4 size and 5 unit margins
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(5));

            // Create a new grid
            PdfGrid grid = new PdfGrid();

            // Set the cell padding for the grid
            grid.Style.CellPadding = new PdfPaddings(10, 10, 10, 10);

            // Fill the grid with data from a data source
            grid.DataSource = GetData();

            // Set text alignment and vertical alignment for each cell in the grid
            foreach (PdfGridRow row in grid.Rows)
            {
                foreach (PdfGridCell cell in row.Cells)
                {
                    cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                }
            }

            // Draw the grid on the page at position (0, 0)
            grid.Draw(page, new PointF(0, 0));

            // Specify the output file name
            String result = "PaddingForTableCell_out.pdf";

            // Save the PDF document to the output file
            doc.SaveToFile(result);

            //Launch the document
            PDFDocumentViewer(result);
        }
        private String[][] GetData()
        {
            // Raw data for populating the grid
            String[] data = {
                    "Name;Capital;Continent;Area;Population",
                    "Argentina;Buenos Aires;South America;2777815;32300003",
                    "Bolivia;La Paz;South America;1098575;7300000",
                    "Brazil;Brasilia;South America;8511196;150400000",
                    "Canada;Ottawa;North America;9976147;26500000",
                    "Chile;Santiago;South America;756943;13200000",
                    "Colombia;Bagota;South America;1138907;33000000",
                    "Cuba;Havana;North America;114524;10600000",
                    "Ecuador;Quito;South America;455502;10600000",
                    "El Salvador;San Salvador;North America;20865;5300000",
                    "Guyana;Georgetown;South America;214969;800000",
                    "Jamaica;Kingston;North America;11424;2500000",
                    "Mexico;Mexico City;North America;1967180;88600000",
                    "Nicaragua;Managua;North America;139000;3900000",
                    "Paraguay;Asuncion;South America;406576;4660000",
                    "Peru;Lima;South America;1285215;21600000",
                    "United States of America;Washington;North America;9363130;249200000",
                    "Uruguay;Montevideo;South America;176140;3002000",
                    "Venezuela;Caracas;South America;912047;19700000"
                };

            // Process the raw data and convert it into a 2D array
            String[][] dataSource = new String[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                dataSource[i] = data[i].Split(';');
            }
            return dataSource;
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
