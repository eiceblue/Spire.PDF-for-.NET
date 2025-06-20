Imports System.Data.OleDb
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace AddContinuousTables
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Add a new page to the document
			Dim page As PdfPageBase = doc.Pages.Add()

			' Set an initial value for the y coordinate
			Dim y As Single = 20

			' Define the title for Table 1
			Dim title1 As String = "Table 1"

			' Draw Table 1 on the page and get the layout result
			Dim result As PdfLayoutResult = DrawPDFTable(title1, y, page, "parts")

			' Update the y coordinate based on the height of Table 1 and add some spacing
			y = result.Bounds.Height + 10

			' Retrieve the updated page from the layout result
			page = result.Page

			' Define the title for Table 2
			Dim title2 As String = "Table 2"

			' Draw Table 2 on the page below Table 1
			result = DrawPDFTable(title2, y, page, "country")

			' Specify the output file name
			Dim output As String = "AddContinuousTables_out.pdf"

			' Save the document to the output file
			doc.SaveToFile(output)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Function DrawPDFTable(ByVal title As String, ByVal y As Single, ByVal page As PdfPageBase, ByVal dataName As String) As PdfLayoutResult
			' Define a black brush for drawing text
			Dim brush As PdfBrush = PdfBrushes.Black

			' Create a TrueType font with Arial, size 16, and bold style
			Dim font As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))

			' Create a string format for center alignment
			Dim format As New PdfStringFormat(PdfTextAlignment.Center)

			' Assign the value of 'title' to 'title1'
			Dim title1 As String = title

			' Draw the string on the page's canvas using the font, brush, and format
			page.Canvas.DrawString(title1, font, brush, page.Canvas.ClientSize.Width / 2, y, format)

			' Increase the value of 'y' by the height of the rendered text
			y = y + font.MeasureString(title1, format).Height

			' Increase the value of 'y' by 10 units
			y = y + 10

			' Create a new PdfTable instance
			Dim table As New PdfTable()

			' Set the cell padding of the table to 3
			table.Style.CellPadding = 3

			' Set the border pen of the table to a black brush with a thickness of 0.75
			table.Style.BorderPen = New PdfPen(brush, 0.75F)

			' Set the default background brush of the table to sky blue
			table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue

			' Set the default font of the table to Arial with size 10
			table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))

			' Set the default string format of the table to the previously defined format
			table.Style.DefaultStyle.StringFormat = format

			' Create an alternate style for the table
			table.Style.AlternateStyle = New PdfCellStyle()

			' Set the background brush of the alternate style to light yellow
			table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow

			' Set the font of the alternate style to Arial with size 10
			table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))

			' Set the string format of the alternate style to the previously defined format
			table.Style.AlternateStyle.StringFormat = format

			' Set the table's header source to column captions
			table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions

			' Set the background brush of the header style to cadet blue
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue

			' Set the font of the header style to Arial with size 14 and bold style
			table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 14.0F, FontStyle.Bold))

			' Set the string format of the header style to the previously defined format
			table.Style.HeaderStyle.StringFormat = format

			' Enable the display of the table header
			table.Style.ShowHeader = True

			' Get the data source
			table.DataSource = GetData(dataName)

			' Draw the table on the page
			Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y))

			' Return the layout result
			Return result
		End Function
		Private Function GetData(ByVal name As String) As DataTable
			' Create a new OleDbConnection object
			Dim conn As New OleDbConnection()

			' Set the connection string for the OleDbConnection object to connect to a Microsoft Access database (demo.mdb)
			conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"

			' Create a new OleDbCommand object
			Dim command As New OleDbCommand()

			' Set the command text of the OleDbCommand object to retrieve all data from a table specified by the 'name' parameter
			command.CommandText = "SELECT * FROM " & name

			' Assign the OleDbConnection object to the Connection property of the OleDbCommand object
			command.Connection = conn

			' Create a new OleDbDataAdapter object and pass the OleDbCommand object as the command to execute
			Dim dataAdapter As New OleDbDataAdapter(command)

			' Create a new DataTable object to hold the retrieved data
			Dim dataTable As New DataTable()

			' Fill the DataTable with the data obtained from executing the command using the OleDbDataAdapter
			dataAdapter.Fill(dataTable)

			' Return the populated DataTable
			Return dataTable
		End Function
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
