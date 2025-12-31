Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace RotateNewPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PDF document
			Dim doc As New PdfDocument()

			' Create a PdfUnitConvertor to convert units
			Dim unitCvtr As New PdfUnitConvertor()

			' Set the page margins
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(2.0F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			' Create a new section in the document
			Dim section As PdfSection = doc.Sections.Add()

			' Set the page size to "A4"
			section.PageSettings.Size = PdfPageSize.A4

			' Set the page margins
			section.PageSettings.Margins = margin

			' Set the rotation angle of the page to 90 degrees clockwise
			section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90

			' Add a new page to the section
			Dim page As PdfPageBase = section.Pages.Add()

			' Define a brush for drawing
			Dim brush As PdfBrush = PdfBrushes.Black

			' Define a font for text
			Dim font As New PdfTrueTypeFont(New Font("Arial", 13.0F, FontStyle.Bold), True)
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font As New PdfTrueTypeFont("Arial", 13.0F, FontStyle.Bold, True)
			' =============================================================================

			' Set the string format for text
			Dim format As New PdfStringFormat(PdfTextAlignment.Left)

			' Set the position for drawing text
			Dim x As Single = 0
			Dim y As Single = 50

			' Specify the text string
			Dim specification As String = "The sample demonstrates how to rotate a page when creating a PDF document."

			' Draw the text string on the page canvas
			page.Canvas.DrawString(specification, font, brush, x, y, format)

			' Specify the output file name
			Dim result As String = "RotateNewPDF_out.pdf"

			' Save the document to the output file
			doc.SaveToFile(result)

			' Close the PDF document
			doc.Close()

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
