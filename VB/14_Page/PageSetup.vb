Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace PageSetup
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Set the margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			' Create one page with A4 size and specified margins
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)
			page.BackgroundColor = Color.Chocolate

			' Draw the content on the page
			DrawPage(page)

			' Create another page with A4 size and specified margins
			page = doc.Pages.Add(PdfPageSize.A4, margin)
			page.BackgroundColor = Color.Coral

			' Draw the content on the page
			DrawPage(page)

			' Create a page with A3 size, rotated 180 degrees (upside down), and landscape orientation
			page = doc.Pages.Add(PdfPageSize.A3, margin, PdfPageRotateAngle.RotateAngle180, PdfPageOrientation.Landscape)
			page.BackgroundColor = Color.LightPink

			' Draw the content on the page
			DrawPage(page)

			' Create a section in the document
			Dim section As PdfSection = doc.Sections.Add()
			page = section.Pages.Add()
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins = margin

			' Draw the content on the page
			DrawPage(page)

			' Set the background color for the next page in the section
			page = section.Pages.Add()
			page.BackgroundColor = Color.LightSkyBlue

			' Draw the content on the page
			DrawPage(page)

			' Create a new section in the document with landscape orientation
			section = doc.Sections.Add()
			section.PageSettings.Orientation = PdfPageOrientation.Landscape
			page = section.Pages.Add()
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins = margin

			' Draw the content on the page
			DrawPage(page)

			' Create a new section in the document with 90-degree clockwise rotation
			section = doc.Sections.Add()
			page = section.Pages.Add()
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins = margin
			section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90

			' Draw the content on the page
			DrawPage(page)

			' Create a new section in the document with 180-degree rotation (upside down)
			section = doc.Sections.Add()
			page = section.Pages.Add()
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins = margin
			section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle180

			' Draw the content on the page
			DrawPage(page)

			' Save the document to a file
			doc.SaveToFile("PageSetup.pdf")

			' Close the document
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer("PageSetup.pdf")
		End Sub

		Private Sub DrawPage(ByVal page As PdfPageBase)
			' Get the width of the page's canvas
			Dim pageWidth As Single = page.Canvas.ClientSize.Width

			' Initialize the vertical position
			Dim y As Single = 0

			' Add 5 to the current value of y
			y = y + 5

			' Create a brush for drawing text
			Dim brush2 As PdfBrush = New PdfSolidBrush(Color.Black)

			' Create a font for the text
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))

			' Create a format for the text alignment and spacing
			Dim format2 As New PdfStringFormat(PdfTextAlignment.Center)
			format2.CharacterSpacing = 1.0F

			' Specify the text content
			Dim text As String = "Summary of Science"

			' Draw the text on the page's canvas
			page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2)

			' Measure the size of the drawn text
			Dim size As SizeF = font2.MeasureString(text, format2)

			' Update the vertical position
			y = y + size.Height + 6

			' Load an image from a file
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Wikipedia_Science.png")

			' Draw the image on the page's canvas
			page.Canvas.DrawImage(image, New PointF(pageWidth - image.PhysicalDimension.Width, y))

			' Calculate the available space for the image on the left
			Dim imageLeftSpace As Single = pageWidth - image.PhysicalDimension.Width - 2

			' Calculate the bottom position of the image
			Dim imageBottom As Single = image.PhysicalDimension.Height + y

			' Create a font for the reference content
			Dim font3 As New PdfTrueTypeFont(New Font("Arial", 9.0F))

			' Create a format for the reference content
			Dim format3 As New PdfStringFormat()
			format3.ParagraphIndent = font3.Size * 2
			format3.MeasureTrailingSpaces = True
			format3.LineSpacing = font3.Size * 1.5F

			' Specify the reference content text
			Dim text1 As String = "(All text and picture from "
			Dim text2 As String = "Wikipedia"
			Dim text3 As String = ", the free encyclopedia)"

			' Draw the first part of the reference text
			page.Canvas.DrawString(text1, font3, brush2, 0, y, format3)

			' Measure the size of the drawn text
			size = font3.MeasureString(text1, format3)

			' Set the x-coordinate for the next part of the reference text
			Dim x1 As Single = size.Width

			' Reset the paragraph indent for the next part
			format3.ParagraphIndent = 0

			' Create a font for the underlined text
			Dim font4 As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Underline))

			' Create a brush for the underlined text
			Dim brush3 As PdfBrush = PdfBrushes.Blue

			' Draw the second part of the reference text with underline
			page.Canvas.DrawString(text2, font4, brush3, x1, y, format3)

			' Measure the size of the drawn text
			size = font4.MeasureString(text2, format3)

			' Update the x-coordinate for the next drawing operation
			x1 = x1 + size.Width

			' Draw the third part of the reference text
			page.Canvas.DrawString(text3, font3, brush2, x1, y, format3)

			' Update the vertical position
			y = y + size.Height

			' Create a format for the content text
			Dim format4 As New PdfStringFormat()

			' Read the content text from a file
			text = System.IO.File.ReadAllText("..\..\..\..\..\..\Data\Summary_of_Science.txt")

			' Create a font for the content text
			Dim font5 As New PdfTrueTypeFont(New Font("Arial", 10.0F))

			' Set the line spacing for the content text
			format4.LineSpacing = font5.Size * 1.5F

			' Create a layouter for the content text
			Dim textLayouter As New PdfStringLayouter()

			' Calculate the available space for the content text on the left
			Dim imageLeftBlockHeight As Single = imageBottom - y

			' Layout the content text within the available space
			Dim result As PdfStringLayoutResult = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))

			' Adjust the available space if the actual size is smaller than expected
			If result.ActualSize.Height < imageBottom - y Then
				imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight
				result = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))
			End If
			' Iterate over each line in the layout result
			For Each line As LineInfo In result.Lines
				' Draw the line of text on the page's canvas
				page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4)

				' Update the vertical position based on the line height
				y = y + result.LineHeight
			Next line

			' Create a text widget with the remaining text
			Dim textWidget As New PdfTextWidget(result.Remainder, font5, brush2)

			' Create a layout for the text widget
			Dim textLayout As New PdfTextLayout()

			' Set the break type to fit the content within the page
			textLayout.Break = PdfLayoutBreakType.FitPage

			' Set the layout type to paginate the content
			textLayout.Layout = PdfLayoutType.Paginate

			' Define the bounds for the text widget
			Dim bounds As New RectangleF(New PointF(0, y), page.Canvas.ClientSize)

			' Set the string format for the text widget
			textWidget.StringFormat = format4

			' Draw the text widget on the page within the specified bounds using the defined layout
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
