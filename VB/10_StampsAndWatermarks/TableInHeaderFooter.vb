Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables
Imports System.ComponentModel
Imports System.Text

Namespace TableInHeaderFooter
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../../Data/PDFTemplate_HF.pdf")

			'Draw table in header
			DrawTableInHeaderFooter(doc)

			'Save the document
			doc.SaveToFile("TableInHeaderFooter_out.pdf")

			'Launch the Pdf file
			PDFDocumentViewer("TableInHeaderFooter_out.pdf")
		End Sub
		Private Sub DrawTableInHeaderFooter(ByVal doc As PdfDocument)
			Dim data() As String = { "Column1;Column2", "Spire.PDF for .NET;Spire.PDF for JAVA" }
			Dim y As Single = 20
			Dim brush As PdfBrush = PdfBrushes.Black

			For Each page As PdfPageBase In doc.Pages
				Dim dataSource(data.Length - 1)() As String
				For i As Integer = 0 To data.Length - 1
					dataSource(i) = data(i).Split(";"c)
				Next i
				'Create Pdf table
				Dim table As New PdfTable()
				table.Style.CellPadding = 2
				table.Style.BorderPen = New PdfPen(brush, 0.1f)
				table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
				table.Style.HeaderSource = PdfHeaderSource.Rows
				table.Style.HeaderRowCount = 1
				table.Style.ShowHeader = True
				table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
				table.DataSource = dataSource
				For Each column As PdfColumn In table.Columns
					column.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
				Next column
				'Draw the table on page
				table.Draw(page, New PointF(0, y))
			Next page
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
