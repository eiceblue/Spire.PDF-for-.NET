Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace Image
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()

			' Create one page
			Dim page As PdfPageBase = doc.Pages.Add()

			'Draw the text
			page.Canvas.DrawString("Hello, World!", New PdfFont(PdfFontFamily.Helvetica, 30f), New PdfSolidBrush(Color.Black), 10, 10)
			'Draw the image
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\SalesReportChart.png")
			Dim width As Single = image.Width * 0.75f
			Dim height As Single = image.Height * 0.75f
			Dim x As Single = (page.Canvas.ClientSize.Width - width) / 2

			page.Canvas.DrawImage(image, x, 60, width, height)

			'Save pdf file.
			doc.SaveToFile("Image.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("Image.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
