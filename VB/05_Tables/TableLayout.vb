Imports System.Data.OleDb
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace TableLayout
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

			' Create a PdfMargins object to set the margins of the page
			Dim margin As New PdfMargins()

			' Set the top margin using centimeters and convert it to points
			margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

			' Set the bottom margin equal to the top margin
			margin.Bottom = margin.Top

			' Set the left margin using centimeters and convert it to points
			margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

			' Set the right margin equal to the left margin
			margin.Right = margin.Left

			' Add a new page to the document with the specified size and margins
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			' Set the initial y-coordinate position on the page
			Dim y As Single = 10

			' Set the brush color for drawing
			Dim brush1 As PdfBrush = PdfBrushes.Black

			' Create a font object for text formatting
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))

			' Create a string format object for text alignment
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)

			' Draw the title "Part List" on the page
			page.Canvas.DrawString("Part List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)

			' Update the y-coordinate position based on the height of the title
			y = y + font1.MeasureString("Part List", format1).Height

			' Add some spacing after the title
			y = y + 5

			' Create a new PdfTable object for displaying tabular data
			Dim table As New PdfTable()

			' Set the cell padding and border style for the table
			table.Style.CellPadding = 1
			table.Style.BorderPen = New PdfPen(brush1, 0.75F)

			' Set the default background brush and font for table cells
			table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
			table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F), True)

			' Set the header source to use column captions
			table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions

			' Set the background brush and font for table headers
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
			table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 11.0F, FontStyle.Bold), True)

			' Set the string format for table headers
			table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)

			' Enable showing and repeating the table header
			table.Style.ShowHeader = True
			table.Style.RepeatHeader = True

			' Create a new OleDbConnection object for database connection
			Using conn As New OleDbConnection()
				' Set the connection string for the database
				conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"

				' Create a new OleDbCommand object for executing SQL commands
				Dim command As New OleDbCommand()

				' Set the SQL command to select all records from the "parts" table
				command.CommandText = "SELECT * FROM parts"

				' Set the connection for the command
				command.Connection = conn

				' Create a new OleDbDataAdapter object for filling a DataTable with data from the database
				Using dataAdapter As New OleDbDataAdapter(command)
					' Create a new DataTable object
					Dim dataTable As New DataTable()

					' Fill the DataTable with data from the database
					dataAdapter.Fill(dataTable)

					' Remove the second column from the DataTable
					dataTable.Columns.RemoveAt(1)

					' Set the data source type and data source for the table
					table.DataSourceType = PdfTableDataSourceType.TableDirect
					table.DataSource = dataTable
				End Using
			End Using

			' Calculate the width of the table based on the page width and border widths
			Dim width As Single = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width

			' Set the column widths and string formats for the table
			For i As Integer = 0 To table.Columns.Count - 1
				If i = 1 Then
					' Set the width and string format for column
					table.Columns(i).Width = width * 0.4F * width
					table.Columns(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
				Else
					' Set the width and string format for column
					table.Columns(i).Width = width * 0.12F * width
					table.Columns(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
				End If
			Next i

			' Register the event handler for the BeginRowLayout event of the table
			AddHandler table.BeginRowLayout, AddressOf table_BeginRowLayout

			' Create a new PdfTableLayoutFormat object for controlling the layout of the table
			Dim tableLayout As New PdfTableLayoutFormat()

			' Set the break type to FitElement, which means the table will be split if it doesn't fit on the current page
			tableLayout.Break = PdfLayoutBreakType.FitElement

			' Set the layout type to Paginate, which paginates the table across multiple pages if needed
			tableLayout.Layout = PdfLayoutType.Paginate

			' Draw the table on the page at position (0, y) with the specified layout format
			Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y), tableLayout)

			' Update the y-coordinate position based on the bottom bounds of the table plus some additional spacing
			y = result.Bounds.Bottom + 5

			' Set the brush color for drawing
			Dim brush2 As PdfBrush = PdfBrushes.Gray

			' Create a font object for text formatting
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9.0F))

			' Draw a string below the table indicating the number of parts in the list
			result.Page.Canvas.DrawString(String.Format("* All {0} parts in the list", table.Rows.Count), font2, brush2, 5, y)

			' Save the document to a PDF file
			doc.SaveToFile("TableLayout.pdf")

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("TableLayout.pdf")
		End Sub
		Private Sub table_BeginRowLayout(ByVal sender As Object, ByVal args As BeginRowLayoutEventArgs)
			' Check if the row index is less than 0 (header row)
			If args.RowIndex < 0 Then
				' Skip further processing and return
				Return
			End If

			' Check if the row index is a multiple of 3
			If args.RowIndex Mod 3 = 0 Then
				' Set the background color of the cell to LightYellow
				args.CellStyle.BackgroundBrush = PdfBrushes.LightYellow
			Else
				' Set the background color of the cell to SkyBlue
				args.CellStyle.BackgroundBrush = PdfBrushes.SkyBlue
			End If
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
