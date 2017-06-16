Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace Font
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
            Dim l As Single = page.Canvas.ClientSize.Width / 2
			Dim center As New PointF(l, l)
			Dim r As Single = CSng(Math.Sqrt(2 * l * l))
			Dim brush As New PdfRadialGradientBrush(center, 0f, center, r, Color.Blue, Color.Red)
			Dim fontFamilies() As PdfFontFamily = CType(System.Enum.GetValues(GetType(PdfFontFamily)), PdfFontFamily())
			Dim y As Single = 10
			For i As Integer = 0 To fontFamilies.Length - 1
				Dim text As String = String.Format("Font Family: {0}", fontFamilies(i))
				Dim x1 As Single = 0
				y = 10 + i * 16
				Dim font1 As New PdfFont(PdfFontFamily.Courier, 14f)
				Dim font2 As New PdfFont(fontFamilies(i), 14f)
				Dim x2 As Single = x1 + 10 + font1.MeasureString(text).Width
				page.Canvas.DrawString(text, font1, brush, x1, y)
				page.Canvas.DrawString(text, font2, brush, x2, y)
			Next i

			'true type font - embedded.
            Dim font As New System.Drawing.Font("Arial", 14.0F, FontStyle.Bold)
            Dim trueTypeFont As New PdfTrueTypeFont(font)
            y = y + 16.0F
            page.Canvas.DrawString("Font Family: Arial - Embedded", trueTypeFont, brush, 0, y)


			'right to left
			Dim arabicText As String = ChrW(&H0627).ToString() & ChrW(&H0644).ToString() & ChrW(&H0630).ToString() & ChrW(&H0647).ToString() & ChrW(&H0627).ToString() & ChrW(&H0628).ToString() & ChrW(&H0021).ToString() & ChrW(&H0020).ToString() & ChrW(&H0628).ToString() & ChrW(&H062F).ToString() & ChrW(&H0648).ToString() & ChrW(&H0631).ToString() & ChrW(&H0647).ToString() & ChrW(&H0020).ToString() & ChrW(&H062D).ToString() & ChrW(&H0648).ToString() & ChrW(&H0644).ToString() & ChrW(&H0647).ToString() & ChrW(&H0627).ToString() & ChrW(&H0021).ToString() & ChrW(&H0020).ToString() & ChrW(&H0627).ToString() & ChrW(&H0644).ToString() & ChrW(&H0630).ToString() & ChrW(&H0647).ToString() & ChrW(&H0627).ToString() & ChrW(&H0628).ToString() & ChrW(&H0021).ToString() & ChrW(&H0020).ToString() & ChrW(&H0627).ToString() & ChrW(&H0644).ToString() & ChrW(&H0630).ToString() & ChrW(&H0647).ToString() & ChrW(&H0627).ToString() & ChrW(&H0628).ToString() & ChrW(&H0021).ToString() & ChrW(&H0020).ToString() & ChrW(&H0627).ToString() & ChrW(&H0644).ToString() & ChrW(&H0630).ToString() & ChrW(&H0647).ToString() & ChrW(&H0627).ToString() & ChrW(&H0628).ToString() & ChrW(&H0021).ToString()
            trueTypeFont = New PdfTrueTypeFont(font, True)
            y = y + 16.0F
            Dim rctg As New RectangleF(New PointF(0, y), page.Canvas.ClientSize)
			Dim format As New PdfStringFormat(PdfTextAlignment.Right)
			format.RightToLeft = True
			page.Canvas.DrawString(arabicText, trueTypeFont, brush, rctg, format)

			'true type font - not embedded
            font = New System.Drawing.Font("Batang", 14.0F, FontStyle.Italic)
            trueTypeFont = New PdfTrueTypeFont(font)
            y = y + 16.0F
            page.Canvas.DrawString("Font Family: Batang - Not Embedded", trueTypeFont, brush, 0, y)
			'font file
			Dim fontFileName As String = "..\..\..\..\..\..\Data\Hawaii_Killer.ttf"
            trueTypeFont = New PdfTrueTypeFont(fontFileName, 20.0F)
            y = y + 16.0F
            page.Canvas.DrawString("Hawaii Killer Font", trueTypeFont, brush, 0, y)
            y = y + 20.0F
            page.Canvas.DrawString("Hawaii Killer Font, from http://www.1001freefonts.com", New PdfFont(PdfFontFamily.Helvetica, 8.0F), brush, 10, y)

			'cjk font
            Dim cjkFont As New PdfCjkStandardFont(PdfCjkFontFamily.MonotypeHeiMedium, 14.0F)
            y = y + 16.0F
            page.Canvas.DrawString("How to say 'Font' in Chinese? " & ChrW(&H5B57).ToString() & ChrW(&H4F53).ToString(), cjkFont, brush, 0, y)

            cjkFont = New PdfCjkStandardFont(PdfCjkFontFamily.HanyangSystemsGothicMedium, 14.0F)
            y = y + 16.0F
            page.Canvas.DrawString("How to say 'Font' in Japanese? " & ChrW(&H30D5).ToString() & ChrW(&H30A9).ToString() & ChrW(&H30F3).ToString() & ChrW(&H30C8).ToString(), cjkFont, brush, 0, y)

            cjkFont = New PdfCjkStandardFont(PdfCjkFontFamily.HanyangSystemsShinMyeongJoMedium, 14.0F)
            y = y + 16.0F
            page.Canvas.DrawString("How to say 'Font' in Korean? " & ChrW(&HAE00).ToString() & ChrW(&HAF34).ToString(), cjkFont, brush, 0, y)

			'Save pdf file.
			doc.SaveToFile("Font.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("Font.pdf")

		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
