Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddDifferentHeaders
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file
			doc.LoadFromFile("../../../../../../../Data/MultipagePDF.pdf")

			' Define the first header text
			Dim header1 As String = "Header 1"

			' Define the second header text
			Dim header2 As String = "Header 2"

			' Define the font for the headers
			Dim font As New PdfTrueTypeFont(New Font("Arial", 15.0F, FontStyle.Bold))

			' Define the brush (color) for the headers
			Dim brush As PdfBrush = PdfBrushes.Red

			' Define the rectangle to position the header on the page
			Dim rect As New RectangleF(New PointF(0, 20), New SizeF(doc.PageSettings.Size.Width, 50.0F))

			' Define the string format for the headers (alignment)
			Dim format As New PdfStringFormat()

			' Set the alignment of the text to be centered
			format.Alignment = PdfTextAlignment.Center

			' Draw the first header on the first page of the document
			doc.Pages(0).Canvas.DrawString(header1, font, brush, rect, format)

			' Change the font and brush for the second header
			font = New PdfTrueTypeFont(New Font("Aleo", 15.0F, FontStyle.Regular))
			brush = PdfBrushes.Black

			' Change the alignment of the text to be left-aligned
			format.Alignment = PdfTextAlignment.Left

			' Draw the second header on the second page of the document
			doc.Pages(1).Canvas.DrawString(header2, font, brush, rect, format)

			' Specify the output file path
			Dim output As String = "AddingDifferentHeaders_result.pdf"

			' Save the modified PDF document to the output file in PDF format
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the document
			doc.Close()

			' Launch the Pdf
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
