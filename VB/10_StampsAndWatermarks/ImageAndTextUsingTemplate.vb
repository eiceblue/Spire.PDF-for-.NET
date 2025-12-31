Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ImageAndTextUsingTemplate
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file
			doc.LoadFromFile("../../../../../../../Data/PDFTemplate_HF.pdf")

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Get the margins of the document's page settings
			Dim margin As PdfMargins = doc.PageSettings.Margins

			' Create a TrueType font object with Impact font, size 14, and regular style
			Dim font As New PdfTrueTypeFont(New Font("Impact", 14.0F, FontStyle.Regular))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font As New PdfTrueTypeFont("Impact", 14.0F, FontStyle.Regular, True)
			' =============================================================================

			' Create a solid brush with gray color
			Dim brush As New PdfSolidBrush(Color.Gray)

			' Load the image for the header/footer section
			Dim image As PdfImage = PdfImage.FromFile("../../../../../../../Data/E-iceblueLogo.png")

			' Calculate the size of the image
			Dim imageSize As New SizeF(image.Width \ 2, image.Height \ 2)

			' Create a new PdfTemplate object for the header section
			Dim headerTemplate As New PdfTemplate(page.ActualSize.Width - margin.Left - margin.Right, imageSize.Height)

			' Draw the image on the header template
			headerTemplate.Graphics.DrawImage(image, New PointF(0, 0), imageSize)

			' Get the bounds of the header template
			Dim rect As RectangleF = headerTemplate.GetBounds()

			' Create a string format for aligning the text in the header template (right-aligned)
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)

			' Draw the header text on the header template
			headerTemplate.Graphics.DrawString("Header", font, brush, rect, format1)

			' Create a new PdfTemplate object for the footer section
			Dim footerTemplate As New PdfTemplate(page.ActualSize.Width - margin.Left - margin.Right, imageSize.Height)

			' Create a string format for aligning the text in the footer template (center-aligned)
			Dim format2 As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

			' Draw the footer text on the footer template
			footerTemplate.Graphics.DrawString("Footer", font, brush, rect, format2)

			' Define initial coordinates for positioning the header/footer templates on the page canvas
			Dim x As Single = margin.Left
			Dim y As Single = 0

			' Draw the header template on the page canvas
			page.Canvas.DrawTemplate(headerTemplate, New PointF(x, y))

			' Update the y-coordinate for positioning the footer template
			y = page.ActualSize.Height - footerTemplate.Height - 10

			' Draw the footer template on the page canvas
			page.Canvas.DrawTemplate(footerTemplate, New PointF(x, y))

			' Save the modified PDF document to a file
			Dim output As String = "ImageAndTextInHeaderFooterUsingTemplate_out.pdf"
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the document
			doc.Close()

			' Launch the Pdf document
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
