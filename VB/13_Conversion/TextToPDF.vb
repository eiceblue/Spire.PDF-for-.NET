Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.IO

Namespace TextToPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Read the text content from a file
			Dim text As String = File.ReadAllText("..\..\..\..\..\..\Data\TextToPdf.txt")

			' Create a new instance of PdfDocument class
			Dim doc As New PdfDocument()

			' Add a section to the document and create a page
			Dim section As PdfSection = doc.Sections.Add()
			Dim page As PdfPageBase = section.Pages.Add()

			' Create a PdfFont using the Helvetica font family and font size 11
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 11)

			' Set up the string format for text rendering
			Dim format As New PdfStringFormat()
			format.LineSpacing = 20.0F

			' Define the brush (color) for the text
			Dim brush As PdfBrush = PdfBrushes.Black

			' Set up the layout options for text rendering
			Dim textLayout As New PdfTextLayout()
			textLayout.Break = PdfLayoutBreakType.FitPage
			textLayout.Layout = PdfLayoutType.Paginate

			' Define the bounds for the text widget on the page
			Dim bounds As New RectangleF(New PointF(10, 20), page.Canvas.ClientSize)

			' Create a PdfTextWidget with the specified text, font, and brush
			Dim textWidget As New PdfTextWidget(text, font, brush)
			textWidget.StringFormat = format

			' Draw the text widget on the page within the specified bounds using the assigned layout options
			textWidget.Draw(page, bounds, textLayout)

			' Specify the output file name for the resulting PDF
			Dim output As String = "TextToPdf.pdf"

			' Save the document as a PDF file
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the PdfDocument object
			doc.Close()

			' Launch the result file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
