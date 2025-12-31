Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.AutomaticFields

Namespace ImageAndPageNumber
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument
			Dim doc As New PdfDocument()

			' Set the page size to A4
			doc.PageSettings.Size = PdfPageSize.A4

			' Set the page margins to zero
			doc.PageSettings.Margins = New PdfMargins(0)

			' Define the margins for the header and footer
			Dim margins As New PdfMargins(50, 50, 50, 50)

			' Get the page size from the document's page settings
			Dim pageSize As SizeF = doc.PageSettings.Size

			' Create a header template for the document using the specified margins and page size
			doc.Template.Top = CreateHeaderTemplate(doc, margins, pageSize)

			' Create a footer template for the document using the specified margins and page size
			doc.Template.Bottom = CreateFooterTemplate(doc, margins, pageSize)

			' Create a left template for the document with the specified left margin and full page height
			doc.Template.Left = New PdfPageTemplateElement(margins.Left, doc.PageSettings.Size.Height)

			' Create a right template for the document with the specified right margin and full page height
			doc.Template.Right = New PdfPageTemplateElement(margins.Right, doc.PageSettings.Size.Height)

			' Add a new page to the document
			Dim page As PdfPageBase = doc.Pages.Add()

			' Draw a string on the page as "Hello, World!" using the specified font, brush, and position
			page.Canvas.DrawString("Hello, World!", New PdfFont(PdfFontFamily.Helvetica, 30.0F), New PdfSolidBrush(Color.Black), 10, 10)

			' Specify the output file path
			Dim output As String = "ImageandPageNumberinHeaderFootersection_out.pdf"

			' Save the document to the output file in PDF format
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the document
			doc.Close()

			' Launch the file
			PDFDocumentViewer(output)
		End Sub
		Private Function CreateHeaderTemplate(ByVal doc As PdfDocument, ByVal margins As PdfMargins, ByVal pageSize As SizeF) As PdfPageTemplateElement
			' Create a new PdfPageTemplateElement with the specified width and top margins
			Dim headerSpace As New PdfPageTemplateElement(pageSize.Width, margins.Top)
			headerSpace.Foreground = False

			' Set the initial coordinates for drawing elements
			Dim x As Single = margins.Left
			Dim y As Single = 0

			' Load the header image from file
			Dim headerImage As PdfImage = PdfImage.FromFile("../../../../../../../Data/E-iceblueLogo.png")

			' Calculate the width and height of the header image
			Dim width As Single = headerImage.Width \ 2
			Dim height As Single = headerImage.Height \ 2

			' Draw the header image at the specified position with the calculated size
			headerSpace.Graphics.DrawImage(headerImage, x, margins.Top - height - 5, width, height)

			' Create a pen for drawing lines with light gray color and thickness of 1
			Dim pen As New PdfPen(PdfBrushes.LightGray, 1)

			' Draw a line across the page using the pen
			headerSpace.Graphics.DrawLine(pen, x, y + margins.Top - 2, pageSize.Width - x, y + margins.Top - 2)

			' Return the header template
			Return headerSpace
		End Function

		Private Function CreateFooterTemplate(ByVal doc As PdfDocument, ByVal margins As PdfMargins, ByVal pageSize As SizeF) As PdfPageTemplateElement
			' Create a new PdfPageTemplateElement with the specified width and bottom margins
			Dim footerSpace As New PdfPageTemplateElement(pageSize.Width, margins.Bottom)
			footerSpace.Foreground = False

			' Set the initial coordinates for drawing elements
			Dim x As Single = margins.Left
			Dim y As Single = 0

			' Create a pen for drawing lines with gray color and thickness of 1
			Dim pen As New PdfPen(PdfBrushes.Gray, 1)

			' Draw a line across the page using the pen
			footerSpace.Graphics.DrawLine(pen, x, y, pageSize.Width - x, y)

			' Update the y-coordinate for positioning the next element
			y = y + 5

			' Create a font object with Arial font and size 10
			Dim font As New PdfTrueTypeFont(New Font("Arial", 10.0F), True)
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font As New PdfTrueTypeFont("Arial", 10.0F, FontStyle.Regular, True)
			' =============================================================================

			' Create page number and page count fields
			Dim number As New PdfPageNumberField()
			Dim count As New PdfPageCountField()

			' Create a composite field with the specified font, color, format, and content
			Dim compositeField As New PdfCompositeField(font, PdfBrushes.Black, "Page {0} of {1}", number, count)
			compositeField.StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top)

			' Measure the size of the composite field to calculate its bounds
			Dim size As SizeF = font.MeasureString(compositeField.Text)
			compositeField.Bounds = New RectangleF(x, y, size.Width, size.Height)

			' Draw the composite field on the footer template
			compositeField.Draw(footerSpace.Graphics)

			' Return the footer template
			Return footerSpace
		End Function
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
