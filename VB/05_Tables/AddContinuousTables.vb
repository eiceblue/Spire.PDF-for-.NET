Imports System.Data.OleDb
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid
Imports Spire.Pdf.Tables

Namespace AddContinuousTables
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a Pdf document
			Dim doc As New PdfDocument()

			'Add a Pdf page
			Dim page As PdfPageBase = doc.Pages.Add()

			Dim y As Single = 20

			'Draw the table 1
			Dim title1 As String = "Table 1"
			Dim result As PdfLayoutResult = DrawPDFTable(title1, y, page, "parts")

			'Get the current Y coordinate and page
			y = result.Bounds.Height+10
			page = result.Page

			'Draw the table 2
			Dim title2 As String = "Table 2"
			result = DrawPDFTable(title2, y, page, "country")

			'Save the Pdf document
			Dim output As String = "AddContinuousTables_out.pdf"
			doc.SaveToFile(output)
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Function DrawPDFTable(ByVal title As String, ByVal y As Single, ByVal page As PdfPageBase, ByVal dataName As String) As PdfLayoutResult
			'Draw Title
			Dim brush As PdfBrush = PdfBrushes.Black
			Dim font As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
			Dim format As New PdfStringFormat(PdfTextAlignment.Center)
			Dim title1 As String = title
			page.Canvas.DrawString(title1, font, brush, page.Canvas.ClientSize.Width \ 2, y, format)
			y = y + font.MeasureString(title1, format).Height
			y = y + 10

			'Create PDF table and define table style
			Dim table As New PdfTable()
			table.Style.CellPadding = 3
			table.Style.BorderPen = New PdfPen(brush, 0.75f)
			table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
			table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10f))
			table.Style.DefaultStyle.StringFormat = format
			table.Style.AlternateStyle = New PdfCellStyle()
			table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow
			table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10f))
			table.Style.AlternateStyle.StringFormat = format
			table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
			table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 14f, FontStyle.Bold))
			table.Style.HeaderStyle.StringFormat = format
			table.Style.ShowHeader = True

			'Fill data in table
			table.DataSource = GetData(dataName)

			'Draw the table on Pdf page
			Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y))

			Return result
		End Function
		Private Function GetData(ByVal name As String) As DataTable
			Dim conn As New OleDbConnection()

			conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"
			Dim command As New OleDbCommand()
			command.CommandText = " select * from " & name
			command.Connection = conn
			Dim dataAdapter As New OleDbDataAdapter(command)

			Dim dataTable As New DataTable()
			dataAdapter.Fill(dataTable)

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
