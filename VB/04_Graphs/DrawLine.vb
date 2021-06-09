Imports Spire.Pdf
Imports Spire.Pdf.ColorSpace
Imports Spire.Pdf.Graphics

Namespace DrawLine
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

			'Save graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			'Draw line
			'Set location and size
			Dim x As Single = 95
			Dim y As Single = 95
			Dim width As Single = 400
			Dim height As Single = 500

			'Create pens
			Dim pen As New PdfPen(Color.Black, 0.1f)
			Dim pen1 As New PdfPen(Color.Red, 0.1f)
			'Draw a rectangle
			page.Canvas.DrawRectangle(pen, x, y, width, height)
			'Draw two crossed lines
			page.Canvas.DrawLine(pen1, x, y, x + width, y + height)
			page.Canvas.DrawLine(pen1, x + width, y, x, y + height)

			'Restore graphics
			page.Canvas.Restore(state)

			Dim result As String = "DrawLine_out.pdf"

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
