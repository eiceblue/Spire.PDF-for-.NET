Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace Pagination
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PDF document
			Dim doc As New PdfDocument()

			' Set the margin for the document
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			' Draw the cover page using the specified margin
			DrawCover(doc, doc.Sections.Add(), margin)

			' Draw the content pages using the specified margin
			DrawContent(doc, doc.Sections.Add(), margin)

			' Draw the page numbers on the second section of the document
			DrawPageNumber(doc.Sections(1), margin, 1, doc.Sections(1).Pages.Count)

			' Save the document to a file
			doc.SaveToFile("Pagination.pdf")

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("Pagination.pdf")
		End Sub

		Private Sub DrawCover(ByVal pdf As PdfDocument, ByVal section As PdfSection, ByVal margin As PdfMargins)
			' Set the page size of the section to A4
			section.PageSettings.Size = PdfPageSize.A4

			' Set the margins of the section to 0 on all sides
			section.PageSettings.Margins.All = 0

			' Add a new page to the section
			Dim page As PdfPageBase = section.Pages.Add()

			' Create a new instance of PdfPageLabels for the document
			pdf.PageLabels = New PdfPageLabels()

			' Add page labels starting from index 0 with lowercase Roman numerals in the format "cover "
			pdf.PageLabels.AddRange(0, PdfPageLabels.Lowercase_Roman_Numerals_Style, "cover ")

			' Draw the page header and footer on the page using the specified margin
			DrawPageHeaderAndFooter(page, margin, True)

			' Create brushes and fonts for drawing text and images
			Dim brush1 As PdfBrush = PdfBrushes.LightGray
			Dim brush2 As PdfBrush = PdfBrushes.Blue
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 8.0F))
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True

			' Specify the text content for the information section
			Dim text1 As String = "(All text and picture from "
			Dim text2 As String = "Wikipedia"
			Dim text3 As String = ", the free encyclopedia)"

			' Initialize the x and y coordinates for drawing
			Dim x As Single = 0, y As Single = 10

			' Increment the x and y coordinates by the left margin
			x = x + margin.Left
			y = y + margin.Top

			' Draw the first part of the information text
			page.Canvas.DrawString(text1, font1, brush1, x, y, format)

			' Update the x-coordinate for the next part of the text
			x = x + font1.MeasureString(text1, format).Width

			' Draw the second part of the information text
			page.Canvas.DrawString(text2, font1, brush2, x, y, format)

			' Update the x-coordinate for the next part of the text
			x = x + font1.MeasureString(text2, format).Width

			' Draw the third part of the information text
			page.Canvas.DrawString(text3, font1, brush1, x, y, format)

			' Create brushes and pens for drawing an image with description
			Dim brush3 As PdfBrush = PdfBrushes.Black
			Dim brush4 As PdfBrush = New PdfSolidBrush(New PdfRGBColor(&HF9, &HF9, &HF9))
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg")
			Dim text As String = My.Resources.ImageDescription
			Dim r As Single = image.PhysicalDimension.Height / image.Height
			Dim pen As New PdfPen(brush1, r)
			Dim size As SizeF = font1.MeasureString(text, image.PhysicalDimension.Width - 2)

			' Create a template for the image with description
			Dim template As New PdfTemplate(image.PhysicalDimension.Width + 4 * r + 4, image.PhysicalDimension.Height + 4 * r + 7 + size.Height)

			' Draw a rectangle border around the template
			template.Graphics.DrawRectangle(pen, brush4, 0, 0, template.Width, template.Height)

			' Set the initial coordinates for drawing the image and description within the template
			y = r + 2
			x = y

			' Draw a rectangle around the image within the template
			template.Graphics.DrawRectangle(brush1, x, y, image.PhysicalDimension.Width + 2 * r, image.PhysicalDimension.Height + 2 * r)

			' Update the coordinates for drawing the image within the rectangle
			y = x + r
			x = y

			' Draw the image within the rectangle
			template.Graphics.DrawImage(image, x, y)

			' Adjust the coordinates for drawing the description below the image
			x = x - 1
			y = y + image.PhysicalDimension.Height + r + 2

			' Draw the description text within a rectangle below the image
			template.Graphics.DrawString(text, font1, brush3, New RectangleF(New PointF(x, y), size))

			' Calculate the position to draw the template on the page's canvas
			Dim x1 As Single = (page.Canvas.ClientSize.Width - template.Width) / 2
			Dim y1 As Single = (page.Canvas.ClientSize.Height - margin.Top - margin.Bottom) * (1 - 0.618F) - template.Height \ 2 + margin.Top

			' Draw the template on the page's canvas at the specified position
			template.Draw(page.Canvas, x1, y1)

			' Set the alignment for drawing the title text
			format.Alignment = PdfTextAlignment.Center

			' Create font2 for drawing text
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 24.0F, FontStyle.Bold))
			x = page.Canvas.ClientSize.Width / 2
			y = y1 + template.Height + 10

			' Draw text
			page.Canvas.DrawString(My.Resources.Title, font2, brush3, x, y, format)
		End Sub

		Private Sub DrawContent(ByVal pdf As PdfDocument, ByVal section As PdfSection, ByVal margin As PdfMargins)
			' Set the page size of the section to A4
			section.PageSettings.Size = PdfPageSize.A4

			' Set the margins of the section to 0 on all sides
			section.PageSettings.Margins.All = 0

			' Add a new page to the section
			Dim page As PdfPageBase = section.Pages.Add()

			' Add page labels starting from index 1 with decimal Arabic numerals in the format "page "
			pdf.PageLabels.AddRange(1, PdfPageLabels.Decimal_Arabic_Numerals_Style, "page ")

			' Draw the page header and footer on the page using the specified margin
			DrawPageHeaderAndFooter(page, margin, False)

			' Set the initial coordinates and width for drawing text
			Dim x As Single = margin.Left
			Dim y As Single = margin.Top + 8
			Dim width As Single = page.Canvas.ClientSize.Width - margin.Left - margin.Right

			' Create a font and brushes for drawing the title
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16.0F), True)
			Dim brush1 As PdfBrush = PdfBrushes.Black

			' Create a pen for drawing a horizontal line
			Dim pen1 As New PdfPen(brush1, 0.75F)

			' Draw the title text
			page.Canvas.DrawString(My.Resources.Title, font1, brush1, x, y)

			' Update the y-coordinate for the next elements
			y = y + font1.MeasureString(My.Resources.Title).Height + 6

			' Draw a horizontal line below the title
			page.Canvas.DrawLine(pen1, x, y, page.Canvas.ClientSize.Width - margin.Right, y)

			' Update the y-coordinate for the next elements
			y = y + 1.75F

			' Get the content from resources
			Dim content As String = My.Resources.Content

			' Split the content into lines
			Dim lines() As String = content.Split(New Char() {ControlChars.Cr, ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries)

			' Create a font and string format for the content text
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Italic), True)
			Dim format1 As New PdfStringFormat()
			format1.MeasureTrailingSpaces = True
			format1.LineSpacing = font2.Height * 1.5F
			format1.ParagraphIndent = font2.MeasureString(vbTab, format1).Width

			' Update the y-coordinate for the next elements
			y = y + font2.Height * 0.5F

			' Measure and draw the first line of content text
			Dim size As SizeF = font2.MeasureString(lines(0), width, format1)
			page.Canvas.DrawString(lines(0), font2, brush1, New RectangleF(New PointF(x, y), size), format1)

			' Update the y-coordinate for the next elements
			y = y + size.Height

			' Create a font and string format for subsequent lines of content text
			Dim font3 As New PdfTrueTypeFont(New Font("Arial", 10.0F), True)
			Dim format2 As New PdfStringFormat()
			format2.LineSpacing = font3.Height * 1.4F
			format2.MeasureTrailingSpaces = True

			' Measure and draw the second line of content text
			size = font3.MeasureString(lines(1), width, format2)
			page.Canvas.DrawString(lines(1), font3, brush1, New RectangleF(New PointF(x, y), size), format2)

			' Update the y-coordinate for the next elements
			y = y + size.Height

			' Increment the y-coordinate and calculate the indentation for the third line of content text
			y = y + font3.Height * 0.75F
			Dim indent As Single = font3.MeasureString(vbTab & vbTab, format2).Width
			Dim x1 As Single = x + indent

			' Measure and draw the third line of content text with indentation
			size = font3.MeasureString(lines(2), width - indent, format2)
			page.Canvas.DrawString(lines(2), font3, brush1, New RectangleF(New PointF(x1, y), size), format2)

			' Update the y-coordinate for the next elements
			y = y + size.Height + font3.Height * 0.75F

			' Create a StringBuilder to store the remaining lines of content text
			Dim buff As New StringBuilder()
			For i As Integer = 3 To lines.Length - 1
				buff.AppendLine(lines(i))
			Next i
			content = buff.ToString()

			' Create a PdfStringLayouter to lay out the remaining content text
			Dim textLayouter As New PdfStringLayouter()
			Dim result As PdfStringLayoutResult = textLayouter.Layout(content, font3, format2, New SizeF(width, Single.MaxValue))

			' Iterate through each line in the layout result and draw it on the page
			For Each line As LineInfo In result.Lines
				If (line.LineType And LineType.FirstParagraphLine) = LineType.FirstParagraphLine Then
					y = y + font3.Height * 0.75F
				End If
				If y > (page.Canvas.ClientSize.Height - margin.Bottom - result.LineHeight) Then
					page = section.Pages.Add()
					DrawPageHeaderAndFooter(page, margin, False)
					y = margin.Top
				End If
				page.Canvas.DrawString(line.Text, font3, brush1, x, y, format2)
				y = y + result.LineHeight
			Next line
		End Sub

		Private Sub DrawPageHeaderAndFooter(ByVal page As PdfPageBase, ByVal margin As PdfMargins, ByVal isCover As Boolean)
			' Load the header and footer images from file
			Dim headerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Header.png")
			Dim footerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Footer.png")

			' Draw the header image at the top-left corner of the page's canvas
			page.Canvas.DrawImage(headerImage, New PointF(0, 0))

			' Draw the footer image at the bottom-left corner of the page's canvas
			page.Canvas.DrawImage(footerImage, New PointF(0, page.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height))

			' If it is a cover page, set transparency and return
			If isCover Then
				page.Canvas.SetTransparency(1)
				Return
			End If

			' Create brushes, pen, font, and format for drawing text and lines
			Dim brush As PdfBrush = PdfBrushes.Black
			Dim pen As New PdfPen(brush, 0.75F)
			Dim font As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Italic), True)
			Dim format As New PdfStringFormat(PdfTextAlignment.Right)
			format.MeasureTrailingSpaces = True

			' Calculate spacing and coordinates for drawing elements
			Dim space As Single = font.Height * 0.75F
			Dim x As Single = margin.Left
			Dim width As Single = page.Canvas.ClientSize.Width - margin.Left - margin.Right
			Dim y As Single = margin.Top - space

			' Draw a horizontal line at the top of the page
			page.Canvas.DrawLine(pen, x, y, x + width, y)

			' Update the y-coordinate for drawing the text
			y = y - 1 - font.Height

			' Draw the text "Demo of Spire.Pdf" on the right side of the page
			page.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x + width, y, format)

			' Set transparency to fully opaque (1)
			page.Canvas.SetTransparency(1)
		End Sub

		Private Sub DrawPageNumber(ByVal section As PdfSection, ByVal margin As PdfMargins, ByVal startNumber As Integer, ByVal pageCount As Integer)
			' Iterate through each page in the section
			For Each page As PdfPageBase In section.Pages
				' Set transparency to 0.5 (semi-transparent)
				page.Canvas.SetTransparency(0.5F)

				' Create brushes, pen, font, and format for drawing text and lines
				Dim brush As PdfBrush = PdfBrushes.Black
				Dim pen As New PdfPen(brush, 0.75F)
				Dim font As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Italic), True)
				Dim format As New PdfStringFormat(PdfTextAlignment.Right)
				format.MeasureTrailingSpaces = True

				' Calculate spacing and coordinates for drawing elements
				Dim space As Single = font.Height * 0.75F
				Dim x As Single = margin.Left
				Dim width As Single = page.Canvas.ClientSize.Width - margin.Left - margin.Right
				Dim y As Single = page.Canvas.ClientSize.Height - margin.Bottom + space

				' Draw a horizontal line at the bottom of the page
				page.Canvas.DrawLine(pen, x, y, x + width, y)

				' Update the y-coordinate for drawing the text
				y = y + 1

				' Generate the number label for the page
				Dim numberLabel As String = String.Format("{0} of {1}", startNumber, pageCount)

				' Increment the startNumber for the next page
				startNumber += 1

				' Draw the number label on the right side of the page
				page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format)

				' Set transparency to fully opaque (1)
				page.Canvas.SetTransparency(1)
			Next page
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
