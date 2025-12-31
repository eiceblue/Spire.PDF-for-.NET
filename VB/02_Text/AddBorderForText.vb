Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddBorderForText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a pdf document
			Dim doc As New PdfDocument()

			' Load from file
			doc.LoadFromFile("..\..\..\..\..\..\Data\SampleB_1.pdf")

			' Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			' Define the text to be added to the page
			Dim text As String = "Hello, World!"

			' Define the font for the text
			Dim font As New PdfTrueTypeFont(New Font("Times New Roman", 11, FontStyle.Regular), True)


			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			' Dim font As New PdfTrueTypeFont("Times New Roman", 11, FontStyle.Regular, True)
			' =============================================================================

			' Measure the size of the text
			Dim size As SizeF = font.MeasureString(text)

			' Define the brush for drawing the text
			Dim brush As New PdfSolidBrush(Color.Black)

			' Define the position where the text will be drawn
			Dim x As Integer = 60
			Dim y As Integer = 300

			' Draw the text on the page
			page.Canvas.DrawString(text, font, New PdfSolidBrush(Color.Black), x, y)

			' Draw a rectangle border around the text
			page.Canvas.DrawRectangle(New PdfPen(brush, 0.5F), New Rectangle(x, y, CInt(size.Width), CInt(size.Height)))

			' Specify the file name for the resulting document
			Dim result As String = "AddBorderForText-result.pdf"

			' Save the document to a file
			doc.SaveToFile(result)

			' Launch the Pdf file
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
