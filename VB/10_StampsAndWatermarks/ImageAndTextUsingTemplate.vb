Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ImageAndTextUsingTemplate
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load Pdf document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../../Data/PDFTemplate_HF.pdf")

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Get the margins of Pdf
			Dim margin As PdfMargins = doc.PageSettings.Margins

			'Define font and brush
			Dim font As New PdfTrueTypeFont(New Font("Impact",14f,FontStyle.Regular))
			Dim brush As New PdfSolidBrush(Color.Gray)

			'Load an image
			Dim image As PdfImage = PdfImage.FromFile("../../../../../../../Data/E-iceblueLogo.png")

			'Specify the image size
			Dim imageSize As New SizeF(image.Width\2,image.Height\2)

			'Create a header template
			Dim headerTemplate As New PdfTemplate(page.ActualSize.Width - margin.Left - margin.Right, imageSize.Height)

			'Draw the image in the template
			headerTemplate.Graphics.DrawImage(image, New PointF(0, 0),imageSize)

			'Create a retangle
			Dim rect As RectangleF = headerTemplate.GetBounds()

			'string format
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Right,PdfVerticalAlignment.Middle)

			'Draw a string in the template
			headerTemplate.Graphics.DrawString("Header", font, brush, rect, format1)

			'Create a footer template and draw a text
			Dim footerTemplate As New PdfTemplate(page.ActualSize.Width - margin.Left - margin.Right, imageSize.Height)
			Dim format2 As New PdfStringFormat(PdfTextAlignment.Center,PdfVerticalAlignment.Middle)
			footerTemplate.Graphics.DrawString("Footer", font, brush, rect, format2)

			Dim x As Single = margin.Left
			Dim y As Single = 0

			'Draw the header template on page at specified location
			page.Canvas.DrawTemplate(headerTemplate, New PointF(x,y))

			'Draw the footer template on page at specified location
			y = page.ActualSize.Height - footerTemplate.Height - 10
			page.Canvas.DrawTemplate(footerTemplate, New PointF(x, y))

			'Save the document
			Dim output As String = "ImageAndTextInHeaderFooterUsingTemplate_out.pdf"
			doc.SaveToFile(output, FileFormat.PDF)

			'Launch the Pdf document
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
