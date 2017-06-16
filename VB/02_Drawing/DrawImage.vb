Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace DrawImage
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

			TransformText(page)
			DrawImage(page)
			TransformImage(page)

			'Save pdf file.
			doc.SaveToFile("DrawImage.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("DrawImage.pdf")
		End Sub

		Private Sub TransformText(ByVal page As PdfPageBase)
			'save graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			'Draw the text - transform           
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 18f)
			Dim brush1 As New PdfSolidBrush(Color.Blue)
			Dim brush2 As New PdfSolidBrush(Color.CadetBlue)
			Dim format As New PdfStringFormat(PdfTextAlignment.Center)

            page.Canvas.TranslateTransform(page.Canvas.ClientSize.Width / 2, 20)
			page.Canvas.DrawString("Sales Report Chart", font, brush1, 0, 0, format)

			page.Canvas.ScaleTransform(1f, -0.8f)
			page.Canvas.DrawString("Sales Report Chart", font, brush2, 0, -2 * 18 * 1.2f, format)
			'restor graphics
			page.Canvas.Restore(state)
		End Sub

		Private Sub DrawImage(ByVal page As PdfPageBase)
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\SalesReportChart.png")
			Dim width As Single = image.Width * 0.75f
			Dim height As Single = image.Height * 0.75f
			Dim x As Single = (page.Canvas.ClientSize.Width - width) / 2

			page.Canvas.DrawImage(image, x, 60, width, height)
		End Sub

		Private Sub TransformImage(ByVal page As PdfPageBase)
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\SalesReportChart.png")
			Dim skewX As Integer = 20
			Dim skewY As Integer = 20
			Dim scaleX As Single = 0.2f
			Dim scaleY As Single = 0.6f
            Dim width As Integer = CInt(Fix((image.Width + image.Height * Math.Tan(Math.PI * skewX / 180)) * scaleX))
            Dim height As Integer = CInt(Fix((image.Height + image.Width * Math.Tan(Math.PI * skewY / 180)) * scaleY))
			Dim template As New PdfTemplate(width, height)
			template.Graphics.ScaleTransform(scaleX, scaleY)
			template.Graphics.SkewTransform(skewX, skewY)
			template.Graphics.DrawImage(image, 0, 0)

			'save graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()
			page.Canvas.TranslateTransform(page.Canvas.ClientSize.Width - 50, 260)
			Dim offset As Single = (page.Canvas.ClientSize.Width - 100) / 12
			For i As Integer = 0 To 11
				page.Canvas.TranslateTransform(-offset, 0)
				page.Canvas.SetTransparency(i / 12.0f)
				page.Canvas.DrawTemplate(template, New PointF(0, 0))
			Next i

			'restor graphics
			page.Canvas.Restore(state)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace