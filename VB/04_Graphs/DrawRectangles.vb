Imports Spire.Pdf
Imports Spire.Pdf.ColorSpace
Imports Spire.Pdf.Graphics

Namespace DrawRectangles
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

			'Draw rectangles
			'Set rectangle display location and size
			Dim x As Integer = 130
			Dim y As Integer = 100
			Dim width As Integer = 300
			Dim height As Integer = 400

			'Create one page
			Dim pen As New PdfPen(Color.Black, 0.1f)
			page.Canvas.DrawRectangle(pen, New Rectangle(New Point(x, y), New Size(width, height)))

			y = y + height - 50
			width = 100
			height = 50
			'Initialize an instance of PdfSeparationColorSpace
			Dim cs As New PdfSeparationColorSpace("MyColor", Color.FromArgb(0, 100, 0, 0))
			Dim pen1 As New PdfPen(Color.Red, 1f)
			'Create a brush with spot color
			Dim brush As PdfBrush = New PdfSolidBrush(New PdfSeparationColor(cs, 0.1f))
			page.Canvas.DrawRectangle(pen1, brush, New Rectangle(New Point(x, y), New Size(width, height)))

			'Restore graphics
			page.Canvas.Restore(state)

			Dim result As String = "DrawRectangles_out.pdf"

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
