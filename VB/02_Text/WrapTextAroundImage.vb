Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Namespace WrapTextAroundImage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Creates a pdf document
			Dim doc As New PdfDocument()

			' Creates a page 
			Dim page As PdfPageBase = doc.Pages.Add()

			'Gets page width
			Dim pageWidth As Single = page.Canvas.ClientSize.Width
			Dim y As Single = 0

			y = y + 8

			' Creates a brush
			Dim brush As PdfBrush = New PdfSolidBrush(Color.Black)

			' Defines a font
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 20f, FontStyle.Bold))

			' Defines a text center alignment format
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
			format1.CharacterSpacing = 1f

			Dim text As String = "Spire.PDF for .NET"
			' Draws text at the specified position
			page.Canvas.DrawString(text, font1, brush, pageWidth / 2, y, format1)
			' Get the size of text
			Dim size As SizeF = font1.MeasureString(text, format1)
			y = y + size.Height + 6

			' Loads an image 
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\PdfImage.png")

			' Draws image at the specified position
			page.Canvas.DrawImage(image, New PointF(pageWidth - image.PhysicalDimension.Width, y))
			Dim imageLeftSpace As Single = pageWidth - image.PhysicalDimension.Width - 2
			Dim imageBottom As Single = image.PhysicalDimension.Height + y

			Dim format2 As New PdfStringFormat()
			' Loads the text around the image
			text = System.IO.File.ReadAllText("..\..\..\..\..\..\Data\text.txt")

			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 16f))

			'Set line spacing
			format2.LineSpacing = font2.Size * 1.5f

			Dim textLayouter As New PdfStringLayouter()
			Dim imageLeftBlockHeight As Single = imageBottom - y
			' Splits the text around into multiple lines based on the draw area
			Dim result As PdfStringLayoutResult = textLayouter.Layout(text, font2, format2, New SizeF(imageLeftSpace, imageLeftBlockHeight))
			If result.ActualSize.Height < imageLeftBlockHeight Then
				imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight
				result = textLayouter.Layout(text, font2, format2, New SizeF(imageLeftSpace, imageLeftBlockHeight))
			End If
			' Draws all the lines onto the page
			For Each line As LineInfo In result.Lines
				page.Canvas.DrawString(line.Text, font2, brush, 0, y, format2)
				y = y + result.LineHeight
			Next line

			' Draw the rest of the text onto the page
			Dim textWidget As New PdfTextWidget(result.Remainder, font2, brush)
			Dim textLayout As New PdfTextLayout()
			textLayout.Break = PdfLayoutBreakType.FitPage
			textLayout.Layout = PdfLayoutType.Paginate
			Dim bounds As New RectangleF(New PointF(0, y), page.Canvas.ClientSize)
			textWidget.StringFormat = format2
			textWidget.Draw(page, bounds, textLayout)

			Dim output As String = "PlaceTextAroundImage_out.pdf"

			'Save the document
			doc.SaveToFile(output)
			'Launch the Pdf file
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
