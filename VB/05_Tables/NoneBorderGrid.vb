Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid

Namespace NoneBorderGrid
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create the PDF document
			Dim doc As New PdfDocument()
			'Add the first page
			Dim page As PdfPageBase = doc.Pages.Add()
			'Create grid
			Dim grid As New PdfGrid()
			'Add a row
			Dim row1 As PdfGridRow = grid.Rows.Add()
			grid.Columns.Add(2)

			'Set none border grid
			row1.Cells(0).Style.Borders.Bottom.DashStyle = PdfDashStyle.None
			row1.Cells(0).Style.Borders.Top.DashStyle = PdfDashStyle.None
			row1.Cells(0).Style.Borders.Right.DashStyle = PdfDashStyle.None
			row1.Cells(0).Style.Borders.Left.DashStyle = PdfDashStyle.None

			'Fill data
			Dim str As String = "Hello Word!"
			For i As Integer = 0 To grid.Columns.Count - 1
				row1.Cells(i).Value = str
			Next i

			'Draw the grid on page
			grid.Draw(page, New PointF(0, 50))

			'Save pdf file
			Dim result As String = "PDFNoneBorderGrid.pdf"
			doc.SaveToFile(result, FileFormat.PDF)

			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
