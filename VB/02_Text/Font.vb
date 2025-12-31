Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace Font
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument.
			Dim doc As New PdfDocument()

			' Load the PDF file from the specified path.
			doc.LoadFromFile("..\..\..\..\..\..\Data\Font.pdf")

			' Get the first page of the document.
			Dim page As PdfPageBase = doc.Pages(0)

			' Calculate the center point and radius for the radial gradient brush.
			Dim l As Single = page.Canvas.ClientSize.Width / 2
			Dim center As New PointF(l, l)
			Dim r As Single = CSng(Math.Sqrt(2 * l * l))
			Dim brush As New PdfRadialGradientBrush(center, 0F, center, r, Color.Blue, Color.Red)

			' Get an array of available PdfFontFamily values.
			Dim fontFamilies() As PdfFontFamily = CType(System.Enum.GetValues(GetType(PdfFontFamily)), PdfFontFamily())

			' Set the initial y-coordinate for drawing text.
			Dim y As Single = 200

			' Iterate through each font family and draw text with different fonts.
			For i As Integer = 0 To fontFamilies.Length - 1
				Dim text As String = String.Format("Font Family: {0}", fontFamilies(i))
				Dim x1 As Single = 40
				y = 200 + i * 16
				Dim font1 As New PdfFont(PdfFontFamily.Courier, 14.0F)
				Dim font2 As New PdfFont(fontFamilies(i), 14.0F)
				Dim x2 As Single = x1 + 10 + font1.MeasureString(text).Width
				page.Canvas.DrawString(text, font1, brush, x1, y)
				page.Canvas.DrawString(text, font2, brush, x2, y)
			Next i

			' Create a TrueType font using Arial with bold style.
			Dim font As New System.Drawing.Font("Arial", 15.0F, FontStyle.Bold)
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			' Dim font As New PdfTrueTypeFont("Arial", 15.0F, FontStyle.Bold, True)
			' =============================================================================


			Dim trueTypeFont As New PdfTrueTypeFont(font)

			' Adjust the y-coordinate for drawing the next line of text.
			y = y + 26.0F

			' Draw a line of text using the TrueType font.
			page.Canvas.DrawString("Font Family: Arial - Embedded", trueTypeFont, brush, 40, y)

			' Create an Arabic text string.
			Dim arabicText As String = ChrW(&H627).ToString() & ChrW(&H644).ToString() & ChrW(&H630).ToString() & ChrW(&H647).ToString() & ChrW(&H627).ToString() & ChrW(&H628).ToString() & ChrW(&H21).ToString() & ChrW(&H20).ToString() & ChrW(&H628).ToString() & ChrW(&H62F).ToString() & ChrW(&H648).ToString() & ChrW(&H631).ToString() & ChrW(&H647).ToString() & ChrW(&H20).ToString() & ChrW(&H62D).ToString() & ChrW(&H648).ToString() & ChrW(&H644).ToString() & ChrW(&H647).ToString() & ChrW(&H627).ToString() & ChrW(&H21).ToString() & ChrW(&H20).ToString() & ChrW(&H627).ToString() & ChrW(&H644).ToString() & ChrW(&H630).ToString() & ChrW(&H647).ToString() & ChrW(&H627).ToString() & ChrW(&H628).ToString() & ChrW(&H21).ToString() & ChrW(&H20).ToString() & ChrW(&H627).ToString() & ChrW(&H644).ToString() & ChrW(&H630).ToString() & ChrW(&H647).ToString() & ChrW(&H627).ToString() & ChrW(&H628).ToString() & ChrW(&H21).ToString() & ChrW(&H20).ToString() & ChrW(&H627).ToString() & ChrW(&H644).ToString() & ChrW(&H630).ToString() & ChrW(&H647).ToString() & ChrW(&H627).ToString() & ChrW(&H628).ToString()
			trueTypeFont = New PdfTrueTypeFont(font, True)

			' Adjust the y-coordinate for drawing the next line of text.
			y = y + 26.0F

			' Define a rectangle and string format for Arabic text.
			Dim rctg As New RectangleF(New PointF(40, y), page.Canvas.ClientSize)
			Dim format As New PdfStringFormat(PdfTextAlignment.Right)
			format.RightToLeft = True

			' Draw Arabic text using the TrueType font with right-to-left alignment.
			page.Canvas.DrawString(arabicText, trueTypeFont, brush, rctg, format)

			' Create a new font with the "Batang" family, size 14, and italic style
			font = New System.Drawing.Font("Batang", 14.0F, FontStyle.Italic)
			' Create a PdfTrueTypeFont object from the font
			trueTypeFont = New PdfTrueTypeFont(font)

			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			' Dim font As New PdfTrueTypeFont("Batang", 14.0F, FontStyle.Italic, True)
			' =============================================================================

			' Increase the value of y by 16
			y = y + 16.0F

			' Draw a string on the page using the "Batang" font
			page.Canvas.DrawString("Font Family: Batang - Not Embedded", trueTypeFont, brush, 40, y)

			' Specify the path to the font file
			Dim fontFileName As String = "..\..\..\..\..\..\Data\PT_Serif-Caption-Web-Regular.ttf"

			' Create a PdfTrueTypeFont object from the font file with size 20
			trueTypeFont = New PdfTrueTypeFont(fontFileName, 20.0F)

			' Increase the value of y by 36
			y = y + 36.0F

			' Draw a string on the page using the PT Serif Caption font
			page.Canvas.DrawString("PT Serif Caption Font", trueTypeFont, brush, 40, y)

			' Increase the value of y by 40
			y = y + 40.0F

			' Draw a string on the page using the Helvetica font with size 8
			page.Canvas.DrawString("PT Serif Caption Font", New PdfFont(PdfFontFamily.Helvetica, 8.0F), brush, 40, y)

			' Create a PdfCjkStandardFont object with the Monotype Hei Medium font family and size 14
			Dim cjkFont As New PdfCjkStandardFont(PdfCjkFontFamily.MonotypeHeiMedium, 14.0F)

			' Increase the value of y by 36
			y = y + 36.0F

			' Draw a string on the page with the Chinese translation of "Font"
			page.Canvas.DrawString("How to say 'Font' in Chinese? " & ChrW(&H5B57).ToString() & ChrW(&H4F53).ToString(), cjkFont, brush, 40, y)

			' Create a PdfCjkStandardFont object with the Hanyang Systems Gothic Medium font family and size 14
			cjkFont = New PdfCjkStandardFont(PdfCjkFontFamily.HanyangSystemsGothicMedium, 14.0F)

			' Increase the value of y by 36
			y = y + 36.0F

			' Draw a string on the page with the Japanese translation of "Font"
			page.Canvas.DrawString("How to say 'Font' in Japanese? " & ChrW(&H30D5).ToString() & ChrW(&H30A9).ToString() & ChrW(&H30F3).ToString() & ChrW(&H30C8).ToString(), cjkFont, brush, 40, y)

			' Create a PdfCjkStandardFont object with the Hanyang Systems Shin Myeong Jo Medium font family and size 14
			cjkFont = New PdfCjkStandardFont(PdfCjkFontFamily.HanyangSystemsShinMyeongJoMedium, 14.0F)

			' Increase the value of y by 36
			y = y + 36.0F

			' Draw a string on the page with the Korean translation of "Font"
			page.Canvas.DrawString("How to say 'Font' in Korean? " & ChrW(&HAE00).ToString() & ChrW(&HAF34).ToString(), cjkFont, brush, 40, y)

			' Save the document to a file named "Font.pdf"
			doc.SaveToFile("Font.pdf")

			' Close the document
			doc.Close()

			'Launch the Pdf file
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
