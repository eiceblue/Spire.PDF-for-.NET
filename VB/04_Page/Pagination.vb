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
			'Create a pdf document.
			Dim doc As New PdfDocument()

			'margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			DrawCover(doc.Sections.Add(), margin)
			DrawContent(doc.Sections.Add(), margin)
			DrawPageNumber(doc.Sections(1), margin, 1, doc.Sections(1).Pages.Count)

			'Save pdf file.
			doc.SaveToFile("Pagination.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("Pagination.pdf")
		End Sub

		Private Sub DrawCover(ByVal section As PdfSection, ByVal margin As PdfMargins)
			section.PageNumber = New PdfPageNumber()
			section.PageNumber.NumberStyle = PdfNumberStyle.LowerRoman
			section.PageNumber.Prefix = "cover "
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins.All = 0
			Dim page As PdfPageBase = section.Pages.Add()
			DrawPageHeaderAndFooter(page, margin, True)

			'refenrence content
			Dim brush1 As PdfBrush = PdfBrushes.LightGray
			Dim brush2 As PdfBrush = PdfBrushes.Blue
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 8f))
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True
			Dim text1 As String = "(All text and picture from "
			Dim text2 As String = "Wikipedia"
			Dim text3 As String = ", the free encyclopedia)"
			Dim x As Single = 0, y As Single = 10
			x = x + margin.Left
			y = y + margin.Top
			page.Canvas.DrawString(text1, font1, brush1, x, y, format)
			x = x + font1.MeasureString(text1, format).Width
			page.Canvas.DrawString(text2, font1, brush2, x, y, format)
			x = x + font1.MeasureString(text2, format).Width
			page.Canvas.DrawString(text3, font1, brush1, x, y, format)

			'cover
			Dim brush3 As PdfBrush = PdfBrushes.Black
			Dim brush4 As PdfBrush = New PdfSolidBrush(New PdfRGBColor(&Hf9, &Hf9, &Hf9))
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg")
			Dim text As String = My.Resources.ImageDescription
            Dim r As Single = image.PhysicalDimension.Height / image.Height
			Dim pen As New PdfPen(brush1, r)
			Dim size As SizeF = font1.MeasureString(text, image.PhysicalDimension.Width - 2)
			Dim template As New PdfTemplate(image.PhysicalDimension.Width + 4 * r + 4, image.PhysicalDimension.Height + 4 * r + 7 + size.Height)
			template.Graphics.DrawRectangle(pen, brush4, 0, 0, template.Width, template.Height)
			y = r + 2
			x = y
			template.Graphics.DrawRectangle(brush1, x, y, image.PhysicalDimension.Width + 2 * r, image.PhysicalDimension.Height + 2 * r)
			y = x + r
			x = y
			template.Graphics.DrawImage(image, x, y)

			x = x - 1
			y = y + image.PhysicalDimension.Height + r + 2
			template.Graphics.DrawString(text, font1, brush3, New RectangleF(New PointF(x, y), size))

			Dim x1 As Single = (page.Canvas.ClientSize.Width - template.Width) / 2
            Dim y1 As Single = (page.Canvas.ClientSize.Height - margin.Top - margin.Bottom) * (1 - 0.618F) - template.Height / 2 + margin.Top
			template.Draw(page.Canvas, x1, y1)

			'title
			format.Alignment = PdfTextAlignment.Center
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 24f, FontStyle.Bold))
            x = page.Canvas.ClientSize.Width / 2
			y = y1 + template.Height + 10
			page.Canvas.DrawString(My.Resources.Title, font2, brush3, x, y, format)
		End Sub

		Private Sub DrawContent(ByVal section As PdfSection, ByVal margin As PdfMargins)
			section.PageNumber = New PdfPageNumber()
			section.PageNumber.NumberStyle = PdfNumberStyle.Numeric
			section.PageNumber.Prefix = "page "
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins.All = 0
			Dim page As PdfPageBase = section.Pages.Add()
			DrawPageHeaderAndFooter(page, margin, False)

			Dim x As Single = margin.Left
			Dim y As Single = margin.Top + 8
			Dim width As Single = page.Canvas.ClientSize.Width - margin.Left - margin.Right
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f), True)
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim pen1 As New PdfPen(brush1, 0.75f)
			page.Canvas.DrawString(My.Resources.Title, font1, brush1, x, y)
			y = y + font1.MeasureString(My.Resources.Title).Height + 6
			page.Canvas.DrawLine(pen1, x, y, page.Canvas.ClientSize.Width - margin.Right, y)
			y = y + 1.75f

			Dim content As String = My.Resources.Content
			Dim lines() As String = content.Split(New Char() { ControlChars.Cr, ControlChars.Lf }, StringSplitOptions.RemoveEmptyEntries)
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Italic), True)
			Dim format1 As New PdfStringFormat()
			format1.MeasureTrailingSpaces = True
			format1.LineSpacing = font2.Height * 1.5f
			format1.ParagraphIndent = font2.MeasureString(vbTab, format1).Width
			y = y + font2.Height * 0.5f
			Dim size As SizeF = font2.MeasureString(lines(0), width, format1)
			page.Canvas.DrawString(lines(0), font2, brush1, New RectangleF(New PointF(x, y), size), format1)
			y = y + size.Height

			Dim font3 As New PdfTrueTypeFont(New Font("Arial", 10f), True)
			Dim format2 As New PdfStringFormat()
			format2.LineSpacing = font3.Height * 1.4f
			format2.MeasureTrailingSpaces = True
			size = font3.MeasureString(lines(1), width, format2)
			page.Canvas.DrawString(lines(1), font3, brush1, New RectangleF(New PointF(x, y), size), format2)
			y = y + size.Height

			y = y + font3.Height * 0.75f
			Dim indent As Single = font3.MeasureString(vbTab & vbTab, format2).Width
			Dim x1 As Single = x + indent
			size = font3.MeasureString(lines(2), width - indent, format2)
			page.Canvas.DrawString(lines(2), font3, brush1, New RectangleF(New PointF(x1, y), size), format2)
			y = y + size.Height + font3.Height * 0.75f

			Dim buff As New StringBuilder()
			For i As Integer = 3 To lines.Length - 1
				buff.AppendLine(lines(i))
			Next i
			content = buff.ToString()

			Dim textLayouter As New PdfStringLayouter()
			Dim result As PdfStringLayoutResult = textLayouter.Layout(content, font3, format2, New SizeF(width, Single.MaxValue))
			For Each line As LineInfo In result.Lines
				If (line.LineType And LineType.FirstParagraphLine) = LineType.FirstParagraphLine Then
					y = y + font3.Height * 0.75f
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
			page.Canvas.SetTransparency(0.5f)
			Dim headerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Header.png")
			Dim footerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Footer.png")
			page.Canvas.DrawImage(headerImage, New PointF(0, 0))
			page.Canvas.DrawImage(footerImage, New PointF(0, page.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height))
			If isCover Then
				page.Canvas.SetTransparency(1)
				Return
			End If

			Dim brush As PdfBrush = PdfBrushes.Black
			Dim pen As New PdfPen(brush, 0.75f)
			Dim font As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Italic), True)
			Dim format As New PdfStringFormat(PdfTextAlignment.Right)
			format.MeasureTrailingSpaces = True
			Dim space As Single = font.Height * 0.75f
			Dim x As Single = margin.Left
			Dim width As Single = page.Canvas.ClientSize.Width - margin.Left - margin.Right
			Dim y As Single = margin.Top - space
			page.Canvas.DrawLine(pen, x, y, x + width, y)
			y = y - 1 - font.Height
			page.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x + width, y, format)
			page.Canvas.SetTransparency(1)
		End Sub

		Private Sub DrawPageNumber(ByVal section As PdfSection, ByVal margin As PdfMargins, ByVal startNumber As Integer, ByVal pageCount As Integer)
			For Each page As PdfPageBase In section.Pages
				page.Canvas.SetTransparency(0.5f)
				Dim brush As PdfBrush = PdfBrushes.Black
				Dim pen As New PdfPen(brush, 0.75f)
				Dim font As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Italic), True)
				Dim format As New PdfStringFormat(PdfTextAlignment.Right)
				format.MeasureTrailingSpaces = True
				Dim space As Single = font.Height * 0.75f
				Dim x As Single = margin.Left
				Dim width As Single = page.Canvas.ClientSize.Width - margin.Left - margin.Right
				Dim y As Single = page.Canvas.ClientSize.Height - margin.Bottom + space
				page.Canvas.DrawLine(pen, x, y, x + width, y)
				y = y + 1
				Dim numberLabel As String = String.Format("{0} of {1}", startNumber, pageCount)
				startNumber += 1
				page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format)
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
