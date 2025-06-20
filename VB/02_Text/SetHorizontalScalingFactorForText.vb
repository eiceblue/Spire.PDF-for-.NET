Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SetHorizontalScalingFactorForText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PDF document object
			Dim doc As New PdfDocument()

			' Add a new page to the document
			Dim page As PdfPageBase = doc.Pages.Add()

			' Create a solid brush with black color
			Dim solidBrush As New PdfSolidBrush(New PdfRGBColor(Color.Black))

			' Create a string format object
			Dim format As New PdfStringFormat()

			' Set the horizontal scaling factor to 80%
			format.HorizontalScalingFactor = 80

			' Create a font object
			Dim font As New PdfFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular)

			' Define the text to be displayed
			Dim text As String = "This is test string, The zoom ratio is 80%"

			' Draw the text on the page with the specified font, brush, position, and format
			page.Canvas.DrawString(text, font, solidBrush, 10, 50, format)

			' Define the second text
			Dim text2 As String = "This is test string, The zoom ratio is 100%"

			' Set the horizontal scaling factor to 100%
			format.HorizontalScalingFactor = 100

			' Draw the second text on the page
			page.Canvas.DrawString(text2, font, solidBrush, 10, 80, format)

			' Define the third text
			Dim text3 As String = "This is test string, The zoom ratio is 120%"

			' Set the horizontal scaling factor to 120%
			format.HorizontalScalingFactor = 120

			' Draw the third text on the page
			page.Canvas.DrawString(text3, font, solidBrush, 10, 110, format)

			' Output file path
			Dim outputFile As String = "SetHorizontalScalingFactorForText_result.pdf"

			' Save the document to the output file
			doc.SaveToFile(outputFile)

			' Close the document
			doc.Close()

			' Open the PDF document
			PDFDocumentViewer(outputFile)

		End Sub


		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
