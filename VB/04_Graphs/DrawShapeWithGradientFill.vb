Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace DrawShapeWithGradientFill
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Create one page
			Dim page As PdfPageBase = doc.Pages.Add()

			'Create a PdfLinearGradientBrush
			Dim brush1 As New PdfLinearGradientBrush(New Rectangle(New Point(100, 100), New Size(200, 120)), Color.BlueViolet, Color.DarkBlue, PdfLinearGradientMode.Horizontal)
			'Draw a rectangle
			page.Canvas.DrawRectangle(brush1, New Rectangle(New Point(100, 100), New Size(200, 120)))

			'Create a PdfRadialGradientBrush
			Dim brush2 As New PdfRadialGradientBrush(New PointF(200f, 400f), 100f, New PointF(300f, 500f), 100f, Color.SkyBlue, Color.DarkBlue)
			'Draw a ellipse
			page.Canvas.DrawEllipse(brush2, New Rectangle(New Point(100, 300), New Size(200, 200)))

			Dim result As String = "DrawShapeWithGradientFill_out.pdf"
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
