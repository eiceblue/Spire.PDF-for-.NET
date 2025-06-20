Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace TableInHeaderFooter
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load an existing PDF file from the specified path
			doc.LoadFromFile("../../../../../../../Data/PDFTemplate_HF.pdf")

			' Call a method to draw a table in the header or footer of each page
			DrawTableInHeaderFooter(doc)

			' Save the modified document to a new file
			doc.SaveToFile("TableInHeaderFooter_out.pdf")

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("TableInHeaderFooter_out.pdf")
		End Sub
		Private Sub DrawTableInHeaderFooter(ByVal doc As PdfDocument)
			' Define an array of strings representing data for the table
			Dim data() As String = {"Column1;Column2", "Spire.PDF for .NET;Spire.PDF for JAVA"}

			' Set the initial Y-coordinate position for drawing the table
			Dim y As Single = 20

			' Create a PdfBrush object for drawing text
			Dim brush As PdfBrush = PdfBrushes.Black

			' Iterate through each page in the document
			For Each page As PdfPageBase In doc.Pages
				' Create a multidimensional array to hold the data source for the table
				Dim dataSource(data.Length - 1)() As String

				' Split each data string by semicolon and assign it to the corresponding element in the array
				For i As Integer = 0 To data.Length - 1
					dataSource(i) = data(i).Split(";"c)
				Next i

				' Create a new PdfTable object
				Dim table As New PdfTable()

				' Set the padding and border properties for the table
				table.Style.CellPadding = 2
				table.Style.BorderPen = New PdfPen(brush, 0.1F)

				' Set the alignment and formatting properties for the table headers
				table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
				table.Style.HeaderSource = PdfHeaderSource.Rows
				table.Style.HeaderRowCount = 1
				table.Style.ShowHeader = True

				' Set the background color for the table headers
				table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue

				' Assign the data source to the table
				table.DataSource = dataSource

				' Set the alignment and formatting properties for each column in the table
				For Each column As PdfColumn In table.Columns
					column.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
				Next column

				' Draw the table on the current page at the specified position
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
