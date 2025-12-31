Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace InlineImageAndPageNumber
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

			' Define text strings and an image for the header/footer section
			Dim text1 As String = "Spire.Pdf is a robust component by"
			Dim text2 As String = "Technology Co., Ltd."
			Dim image As PdfImage = PdfImage.FromFile("../../../../../../../Data/Top-logo.png")

			' Create a TrueType font object with Impact font and size 10
			Dim font As New PdfTrueTypeFont(New Font("Impact", 10.0F))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font As New PdfTrueTypeFont("Impact", 10.0F, FontStyle.Regular, True)
			' =============================================================================

			' Define the brush for text rendering
			Dim bursh As PdfBrush = PdfBrushes.DarkGray

			' Measure the sizes of text strings
			Dim s1 As SizeF = font.MeasureString(text1)
			Dim s2 As SizeF = font.MeasureString(text2)

			' Define initial coordinates for positioning elements
			Dim x As Single = 10
			Dim y As Single = 10

			' Calculate the size of the image
			Dim imgSize As New SizeF(image.Width \ 2, image.Height \ 2)

			' Calculate the size of the first text string and create a rectangle for rendering
			Dim size As New SizeF(s1.Width, imgSize.Width)
			Dim rect1 As New RectangleF(New PointF(x, y), size)

			' Create a string format for aligning the text
			Dim format As New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)

			' Draw the first text string on the page canvas
			page.Canvas.DrawString(text1, font, bursh, rect1, format)

			' Update the x-coordinate for positioning the next element
			x += s1.Width

			' Draw the image on the page canvas
			page.Canvas.DrawImage(image, New PointF(x, y), imgSize)

			' Update the x-coordinate for positioning the next element
			x += imgSize.Width

			' Calculate the size of the second text string and create a rectangle for rendering
			size = New SizeF(s2.Width, imgSize.Height)
			rect1 = New RectangleF(New PointF(x, y), size)

			' Draw the second text string on the page canvas
			page.Canvas.DrawString(text2, font, bursh, rect1, format)

			' Save the modified PDF document to a file
			Dim output As String = "ImageandPageNumberinHeaderFootersectionInline_out.pdf"
			doc.SaveToFile(output)

			' Close the PDF document
			doc.Close()

			' Launch the Pdf file 
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
