Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace InlineImageAndPageNumber
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load Pdf from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../../Data/PDFTemplate_HF.pdf")

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			Dim text1 As String = "Spire.Pdf is a robust component by"
			Dim text2 As String = "Technology Co., Ltd."
			Dim image As PdfImage = PdfImage.FromFile("../../../../../../../Data/Top-logo.png")

			'Define font and bursh
			Dim font As New PdfTrueTypeFont(New Font("Impact", 10f))
			Dim bursh As PdfBrush=PdfBrushes.DarkGray

			'Get the size of text
			Dim s1 As SizeF = font.MeasureString(text1)
			Dim s2 As SizeF = font.MeasureString(text2)

			Dim x As Single = 10
			Dim y As Single = 10

			'Define image size
			Dim imgSize As New SizeF(image.Width\2, image.Height \ 2)

			'Define rectangle and string format
			Dim size As New SizeF(s1.Width, imgSize.Width)
			Dim rect1 As New RectangleF(New PointF(x, y), size)
			Dim format As New PdfStringFormat(PdfTextAlignment.Left,PdfVerticalAlignment.Middle)

			'Draw the text1
			page.Canvas.DrawString(text1, font, bursh, rect1, format)

			'Draw the image
			x += s1.Width
			page.Canvas.DrawImage(image, New PointF(x, y), imgSize)


			'Draw the text2
			x += imgSize.Width
			size = New SizeF(s2.Width, imgSize.Height)
			rect1 = New RectangleF(New PointF(x, y), size)
			page.Canvas.DrawString(text2, font, bursh, rect1, format)

			'Save the document
			Dim output As String = "ImageandPageNumberinHeaderFootersectionInline_out.pdf"
			doc.SaveToFile(output)
			doc.Close()

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
