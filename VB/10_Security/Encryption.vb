Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security

Namespace Encryption
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()

			' Create one page
			Dim page As PdfPageBase = doc.Pages.Add()

			'Draw the page
			DrawPage(page)

			'encrypt
			doc.Security.KeySize = PdfEncryptionKeySize.Key128Bit
			doc.Security.OwnerPassword = "e-iceblue"
			doc.Security.UserPassword = "test"
			doc.Security.Permissions = PdfPermissionsFlags.Print Or PdfPermissionsFlags.FillFields

			'Save pdf file.
			doc.SaveToFile("Encryption.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("Encryption.pdf")
		End Sub

		Private Sub DrawPage(ByVal page As PdfPageBase)
			Dim pageWidth As Single = page.Canvas.ClientSize.Width
			Dim y As Single = 0

			'page header
			Dim pen1 As New PdfPen(Color.LightGray, 1f)
			Dim brush1 As PdfBrush = New PdfSolidBrush(Color.LightGray)
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 8f, FontStyle.Italic))
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Right)
			Dim text As String = "Demo of Spire.Pdf"
			page.Canvas.DrawString(text, font1, brush1, pageWidth, y, format1)
			Dim size As SizeF = font1.MeasureString(text, format1)
			y = y + size.Height + 1
			page.Canvas.DrawLine(pen1, 0, y, pageWidth, y)

			'title
			y = y + 5
			Dim brush2 As PdfBrush = New PdfSolidBrush(Color.Black)
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
			Dim format2 As New PdfStringFormat(PdfTextAlignment.Center)
			format2.CharacterSpacing = 1f
			text = "Summary of Science"
			page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2)
			size = font2.MeasureString(text, format2)
			y = y + size.Height + 6

			'icon
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Wikipedia_Science.png")
			page.Canvas.DrawImage(image, New PointF(pageWidth - image.PhysicalDimension.Width, y))
			Dim imageLeftSpace As Single = pageWidth - image.PhysicalDimension.Width - 2
			Dim imageBottom As Single = image.PhysicalDimension.Height + y

			'refenrence content
			Dim font3 As New PdfTrueTypeFont(New Font("Arial", 9f))
			Dim format3 As New PdfStringFormat()
			format3.ParagraphIndent = font3.Size * 2
			format3.MeasureTrailingSpaces = True
			format3.LineSpacing = font3.Size * 1.5f
			Dim text1 As String = "(All text and picture from "
			Dim text2 As String = "Wikipedia"
			Dim text3 As String = ", the free encyclopedia)"
			page.Canvas.DrawString(text1, font3, brush2, 0, y, format3)

			size = font3.MeasureString(text1, format3)
			Dim x1 As Single = size.Width
			format3.ParagraphIndent = 0
			Dim font4 As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Underline))
			Dim brush3 As PdfBrush = PdfBrushes.Blue
			page.Canvas.DrawString(text2, font4, brush3, x1, y, format3)
			size = font4.MeasureString(text2, format3)
			x1 = x1 + size.Width

			page.Canvas.DrawString(text3, font3, brush2, x1, y, format3)
			y = y + size.Height

			'content
			Dim format4 As New PdfStringFormat()
			text = System.IO.File.ReadAllText("..\..\..\..\..\..\Data\Summary_of_Science.txt")
			Dim font5 As New PdfTrueTypeFont(New Font("Arial", 10f))
			format4.LineSpacing = font5.Size * 1.5f
			Dim textLayouter As New PdfStringLayouter()
			Dim imageLeftBlockHeight As Single = imageBottom - y
			Dim result As PdfStringLayoutResult = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))
			If result.ActualSize.Height < imageBottom - y Then
				imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight
				result = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))
			End If
			For Each line As LineInfo In result.Lines
				page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4)
				y = y + result.LineHeight
			Next line
			Dim textWidget As New PdfTextWidget(result.Remainder, font5, brush2)
			Dim textLayout As New PdfTextLayout()
			textLayout.Break = PdfLayoutBreakType.FitPage
			textLayout.Layout = PdfLayoutType.Paginate
			Dim bounds As New RectangleF(New PointF(0, y), page.Canvas.ClientSize)
			textWidget.StringFormat = format4
			textWidget.Draw(page, bounds, textLayout)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
