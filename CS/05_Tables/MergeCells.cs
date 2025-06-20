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

namespace MergeCells
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
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\MergeCells.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Create a grid
            PdfGrid grid = new PdfGrid();
            grid.Columns.Add(5);

            //Iterate each column of grid
            for (int j = 0; j < grid.Columns.Count; j++)
            {
                //Set width of column
                grid.Columns[j].Width = 100;
            }

            //Add rows
            PdfGridRow row0 = grid.Rows.Add();
            PdfGridRow row1 = grid.Rows.Add();
            float height = 21.0f;

            //Iterate each row of grid
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                //Set the height for row 
                grid.Rows[i].Height = height;
            }

            // Draw the grid on the page at the specified location
            grid.Draw(page, new PointF(50, 410));

            // Set font styles for specific rows and cells
            row0.Style.Font = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold), true);
            row1.Style.Font = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Italic), true);

            row0.Cells[0].Value = "Corporation";

            // Merge two rows
            row0.Cells[0].RowSpan = 2;

            row0.Cells[1].Value = "B&K Undersea Photo";
            row0.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            // Merge two columns
            row0.Cells[1].ColumnSpan = 3;

            // Set value for cell and set style for it
            row0.Cells[4].Value = "World";
            row0.Cells[4].Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold | FontStyle.Italic), true);
            row0.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row0.Cells[4].Style.BackgroundBrush = PdfBrushes.LightGreen;

            row1.Cells[1].Value = "Diving International Unlimited";
            row1.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);

            // Merge four columns
            row1.Cells[1].ColumnSpan = 4;

            // Draw the updated grid on the page at a different location
            grid.Draw(page, new PointF(50, 480));

            // Save the pdf document with merged cells to a file
            doc.SaveToFile("MergeCells.pdf");

            //Launch the document
            PDFDocumentViewer("MergeCells.pdf");
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
