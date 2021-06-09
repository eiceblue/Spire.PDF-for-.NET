Imports Spire.Pdf
Imports Spire.Pdf.ColorSpace
Imports Spire.Pdf.Graphics

Namespace DrawDashedLine
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
			Dim x As Single = 150
			Dim y As Single = 200
			Dim width As Single = 300

			'Create pens
			Dim pen As New PdfPen(Color.Red, 3f)
			'Set dash style and pattern
			pen.DashStyle = PdfDashStyle.Dash
			pen.DashPattern = New Single() { 1, 4, 1 }
			'Draw a rectangle
			'Draw two crossed lines
			page.Canvas.DrawLine(pen, x, y, x + width, y)

			'Restore graphics
			page.Canvas.Restore(state)

			Dim result As String = "DrawDashedLine_out.pdf"

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
