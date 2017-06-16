Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawText
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

			DrawText(page)
			AlignText(page)
			AlignTextInRectangle(page)
			TransformText(page)
			RotateText(page)

			'Save doc file.
			doc.SaveToFile("DrawText.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("DrawText.pdf")

		End Sub

		Private Sub AlignText(ByVal page As PdfPageBase)
			'Draw the text - alignment
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 20f)
			Dim brush As New PdfSolidBrush(Color.Blue)

			Dim leftAlignment As New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
			page.Canvas.DrawString("Left!", font, brush, 0, 20, leftAlignment)
			page.Canvas.DrawString("Left!", font, brush, 0, 50, leftAlignment)

			Dim rightAlignment As New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
			page.Canvas.DrawString("Right!", font, brush, page.Canvas.ClientSize.Width, 30, rightAlignment)
			page.Canvas.DrawString("Right!", font, brush, page.Canvas.ClientSize.Width, 60, rightAlignment)

			Dim centerAlignment As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
            page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, page.Canvas.ClientSize.Width / 2, 40, centerAlignment)

		End Sub

		Private Sub AlignTextInRectangle(ByVal page As PdfPageBase)
			'Draw the text - align in rectangle
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 10f)
			Dim brush As New PdfSolidBrush(Color.Blue)
            Dim rctg1 As New RectangleF(0, 70, page.Canvas.ClientSize.Width / 2, 100)
            Dim rctg2 As New RectangleF(page.Canvas.ClientSize.Width / 2, 70, page.Canvas.ClientSize.Width / 2, 100)
			page.Canvas.DrawRectangle(New PdfSolidBrush(Color.LightBlue), rctg1)
			page.Canvas.DrawRectangle(New PdfSolidBrush(Color.LightSkyBlue), rctg2)

			Dim leftAlignment As New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top)
			page.Canvas.DrawString("Left! Left!", font, brush, rctg1, leftAlignment)
			page.Canvas.DrawString("Left! Left!", font, brush, rctg2, leftAlignment)

			Dim rightAlignment As New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
			page.Canvas.DrawString("Right! Right!", font, brush, rctg1, rightAlignment)
			page.Canvas.DrawString("Right! Right!", font, brush, rctg2, rightAlignment)

			Dim centerAlignment As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Bottom)
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, rctg1, centerAlignment)
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, rctg2, centerAlignment)
		End Sub

		Private Sub RotateText(ByVal page As PdfPageBase)
			'save graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			'Draw the text - transform           
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 10f)
			Dim brush As New PdfSolidBrush(Color.Blue)

			Dim centerAlignment As New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
            Dim x As Single = page.Canvas.ClientSize.Width / 2
			Dim y As Single = 380

			page.Canvas.TranslateTransform(x, y)
			For i As Integer = 0 To 11
				page.Canvas.RotateTransform(30)
				page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, 20, 0, centerAlignment)
			Next i

			'restor graphics
			page.Canvas.Restore(state)
		End Sub

		Private Sub TransformText(ByVal page As PdfPageBase)
			'save graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			'Draw the text - transform           
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 18f)
			Dim brush1 As New PdfSolidBrush(Color.DeepSkyBlue)
			Dim brush2 As New PdfSolidBrush(Color.CadetBlue)

			page.Canvas.TranslateTransform(20, 200)
			page.Canvas.ScaleTransform(1f, 0.6f)
			page.Canvas.SkewTransform(-10, 0)
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush1, 0, 0)

			page.Canvas.SkewTransform(10, 0)
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush2, 0, 0)

			page.Canvas.ScaleTransform(1f, -1f)
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush2, 0, -2 * 18)
			'restor graphics
			page.Canvas.Restore(state)
		End Sub

		Private Sub DrawText(ByVal page As PdfPageBase)
			'save graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			'Draw text - brush
			Dim text As String = "Go! Turn Around! Go! Go! Go!"
			Dim pen As PdfPen = PdfPens.DeepSkyBlue
			Dim brush As New PdfSolidBrush(Color.White)
			Dim format As New PdfStringFormat()
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 18f, PdfFontStyle.Italic)
			Dim size As SizeF = font.MeasureString(text, format)
            Dim rctg As New RectangleF(page.Canvas.ClientSize.Width / 2 + 10, 180, size.Width / 3 * 2, size.Height * 2)
			page.Canvas.DrawString(text, font, pen, brush, rctg, format)

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
