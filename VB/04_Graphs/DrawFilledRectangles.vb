Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawFilledRectangles
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\DrawingTemplate.pdf")
			'Create one page
			Dim page As PdfPageBase = pdf.Pages(0)

			'save graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			'Set rectangle display location and size
			Dim x As Integer = 200
			Dim y As Integer = 300
			Dim width As Integer = 200
			Dim height As Integer = 120
			'Create one page and brush
			Dim pen As New PdfPen(Color.Black, 1f)
			Dim brush As PdfBrush = New PdfSolidBrush(Color.OrangeRed)
			'Draw a filled rectangle
			page.Canvas.DrawRectangle(pen, brush, New Rectangle(New Point(x, y), New Size(width, height)))

			'restore graphics
			page.Canvas.Restore(state)

			Dim result As String = "DrawFilledRectangles_out.pdf"

			'Save the document
			pdf.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
