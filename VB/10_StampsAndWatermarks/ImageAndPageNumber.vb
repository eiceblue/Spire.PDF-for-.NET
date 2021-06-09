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
			'create a PDF document
			Dim doc As New PdfDocument()
			doc.PageSettings.Size = PdfPageSize.A4

			'reset the default margins to 0
			doc.PageSettings.Margins = New PdfMargins(0)

			'create a PdfMargins object, the parameters indicate the page margins you want to set
			Dim margins As New PdfMargins(50, 50, 50, 50)

			'get page size
			Dim pageSize As SizeF = doc.PageSettings.Size

			'create a header template with content and apply it to page template
			doc.Template.Top = CreateHeaderTemplate(doc, margins, pageSize)

			'create a footer template with content and apply it to page template
			doc.Template.Bottom = CreateFooterTemplate(doc, margins, pageSize)

			'apply blank templates to other parts of page template
			doc.Template.Left = New PdfPageTemplateElement(margins.Left, doc.PageSettings.Size.Height)
			doc.Template.Right = New PdfPageTemplateElement(margins.Right, doc.PageSettings.Size.Height)
			
				'Create one page
			Dim page As PdfPageBase = doc.Pages.Add()

			'Draw the text
			page.Canvas.DrawString("Hello, World!", New PdfFont(PdfFontFamily.Helvetica, 30f), New PdfSolidBrush(Color.Black), 10, 10)

			'save the file
			Dim output As String = "ImageandPageNumberinHeaderFootersection_out.pdf"
			doc.SaveToFile(output,FileFormat.PDF)
			PDFDocumentViewer(output)
		End Sub
		Private Function CreateHeaderTemplate(ByVal doc As PdfDocument, ByVal margins As PdfMargins, ByVal pageSize As SizeF) As PdfPageTemplateElement
			'create a PdfPageTemplateElement object as header space
			Dim headerSpace As New PdfPageTemplateElement(pageSize.Width, margins.Top)
			headerSpace.Foreground = False

			'declare two float variables
			Dim x As Single = margins.Left
			Dim y As Single = 0

			'draw image in header space 
			Dim headerImage As PdfImage = PdfImage.FromFile("../../../../../../../Data/E-iceblueLogo.png")
			Dim width As Single = headerImage.Width\2
			Dim height As Single = headerImage.Height\2
			headerSpace.Graphics.DrawImage(headerImage, x, margins.Top - height - 5, width, height)

			'draw line in header space
			Dim pen As New PdfPen(PdfBrushes.LightGray, 1)
			headerSpace.Graphics.DrawLine(pen, x, y + margins.Top - 2, pageSize.Width - x, y + margins.Top - 2)

			'return headerSpace
			Return headerSpace
		End Function

		Private Function CreateFooterTemplate(ByVal doc As PdfDocument, ByVal margins As PdfMargins, ByVal pageSize As SizeF) As PdfPageTemplateElement
			'create a PdfPageTemplateElement object which works as footer space
			Dim footerSpace As New PdfPageTemplateElement(pageSize.Width, margins.Bottom)
			footerSpace.Foreground = False

			'declare two float variables
			Dim x As Single = margins.Left
			Dim y As Single = 0

			'draw line in footer space
			Dim pen As New PdfPen(PdfBrushes.Gray, 1)
			footerSpace.Graphics.DrawLine(pen, x, y, pageSize.Width - x, y)

			'draw text in footer space
			y = y + 5
			Dim font As New PdfTrueTypeFont(New Font("Arial", 10f), True)
			'draw dynamic field in footer space
			Dim number As New PdfPageNumberField()
			Dim count As New PdfPageCountField()
			Dim compositeField As New PdfCompositeField(font, PdfBrushes.Black, "Page {0} of {1}", number, count)
			compositeField.StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top)
			Dim size As SizeF = font.MeasureString(compositeField.Text)
			compositeField.Bounds = New RectangleF(x, y, size.Width, size.Height)
			compositeField.Draw(footerSpace.Graphics)

			'return footerSpace
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
