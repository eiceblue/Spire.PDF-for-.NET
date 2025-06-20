Imports System.Data.OleDb
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace DataSource
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Create a PdfUnitConvertor object for unit conversion
			Dim unitCvtr As New PdfUnitConvertor()

			' Set the margins of the page using centimeters and convert them to points
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			' Add a new page to the document with A4 size and specified margins
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			' Set the initial y-coordinate position for drawing content on the page
			Dim y As Single = 10

			' Create a brush for text color and a font for text formatting
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))

			' Create a string format for center-aligned text
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)

			' Draw the title "Country List" on the page
			page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)

			' Update the y-coordinate position for the next element
			y = y + font1.MeasureString("Country List", format1).Height
			y = y + 5

			' Create a new PdfTable object for tabular data
			Dim table As New PdfTable()

			' Set various styles for the table
			table.Style.CellPadding = 2
			table.Style.BorderPen = New PdfPen(brush1, 0.75F)
			table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
			table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))
			table.Style.AlternateStyle = New PdfCellStyle()
			table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow
			table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))
			table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
			table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 11.0F, FontStyle.Bold))
			table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
			table.Style.ShowHeader = True

			' Use an OleDbConnection to connect to a data source (database)
			Using conn As New OleDbConnection()
				' Set the connection string for the database
				conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"

				' Create an OleDbCommand object for executing SQL query
				Dim command As New OleDbCommand()
				command.CommandText = "SELECT Name,Capital,Continent,Area,Population FROM country"
				command.Connection = conn

				' Use an OleDbDataAdapter to fill a DataTable with data from the database
				Using dataAdapter As New OleDbDataAdapter(command)
					Dim dataTable As New DataTable()
					dataAdapter.Fill(dataTable)

					' Set the table's data source and type
					table.DataSourceType = PdfTableDataSourceType.TableDirect
					table.DataSource = dataTable
				End Using
			End Using

			' Calculate the width of the table based on the page size and border widths
			Dim width As Single = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width

			' Set the width and string format for each column in the table
			table.Columns(0).Width = width * 0.24F * width
			table.Columns(0).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
			table.Columns(1).Width = width * 0.21F * width
			table.Columns(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
			table.Columns(2).Width = width * 0.24F * width
			table.Columns(2).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
			table.Columns(3).Width = width * 0.13F * width
			table.Columns(3).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
			table.Columns(4).Width = width * 0.18F * width
			table.Columns(4).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)

			' Draw the table on the page and get the layout result
			Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y))
			y = y + result.Bounds.Height + 5

			' Create a brush for text color and a font for text formatting
			Dim brush2 As PdfBrush = PdfBrushes.Gray
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9.0F))

			' Draw the string on the page
			page.Canvas.DrawString(String.Format("* {0} countries in the list.", table.Rows.Count), font2, brush2, 5, y)

			' Save the document
			doc.SaveToFile("DataSource.pdf")

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("DataSource.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
