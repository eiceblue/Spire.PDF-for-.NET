Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.AutomaticFields

Namespace Template
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()
			doc.ViewerPreferences.PageLayout = PdfPageLayout.TwoColumnLeft

			'margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			SetDocumentTemplate(doc, PdfPageSize.A4, margin)

			'create section
			Dim section As PdfSection = doc.Sections.Add()
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins = New PdfMargins(0)
			SetSectionTemplate(section, PdfPageSize.A4, margin, "Section 1")

			' Create one page
			Dim page As PdfNewPage = section.Pages.Add()

			'Draw page
			DrawPage(page)

			page = section.Pages.Add()
			DrawPage(page)

			page = section.Pages.Add()
			DrawPage(page)

			page = section.Pages.Add()
			DrawPage(page)

			page = section.Pages.Add()
			DrawPage(page)

			'Save pdf file.
			doc.SaveToFile("Template.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("Template.pdf")
		End Sub

		Private Sub SetSectionTemplate(ByVal section As PdfSection, ByVal pageSize As SizeF, ByVal margin As PdfMargins, ByVal label As String)
			Dim leftSpace As New PdfPageTemplateElement(margin.Left, pageSize.Height)
			leftSpace.Foreground = True
			section.Template.OddLeft = leftSpace

			Dim font As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Italic))
			Dim format As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			Dim y As Single = (pageSize.Height - margin.Top - margin.Bottom) * (1 - 0.618f)
			Dim bounds As New RectangleF(10, y, margin.Left - 20, font.Height + 6)
			leftSpace.Graphics.DrawRectangle(PdfBrushes.OrangeRed, bounds)
			leftSpace.Graphics.DrawString(label, font, PdfBrushes.White, bounds, format)

			Dim rightSpace As New PdfPageTemplateElement(margin.Right, pageSize.Height)
			rightSpace.Foreground = True
			section.Template.EvenRight = rightSpace
			bounds = New RectangleF(10, y, margin.Right - 20, font.Height + 6)
			rightSpace.Graphics.DrawRectangle(PdfBrushes.SaddleBrown, bounds)
			rightSpace.Graphics.DrawString(label, font, PdfBrushes.White, bounds, format)
		End Sub

		Private Sub SetDocumentTemplate(ByVal doc As PdfDocument, ByVal pageSize As SizeF, ByVal margin As PdfMargins)
			Dim leftSpace As New PdfPageTemplateElement(margin.Left, pageSize.Height)
			doc.Template.Left = leftSpace

			Dim topSpace As New PdfPageTemplateElement(pageSize.Width, margin.Top)
			topSpace.Foreground = True
			doc.Template.Top = topSpace

			'draw header label
			Dim font As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Italic))
			Dim format As New PdfStringFormat(PdfTextAlignment.Right)
			Dim label As String = "Demo of Spire.Pdf"
			Dim size As SizeF = font.MeasureString(label, format)
			Dim y As Single = topSpace.Height - font.Height - 1
			Dim pen As New PdfPen(Color.Black, 0.75f)
			topSpace.Graphics.SetTransparency(0.5f)
			topSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y)
			y = y - 1 - size.Height
			topSpace.Graphics.DrawString(label, font, PdfBrushes.Black, pageSize.Width - margin.Right, y, format)

			Dim rightSpace As New PdfPageTemplateElement(margin.Right, pageSize.Height)
			doc.Template.Right = rightSpace

			Dim bottomSpace As New PdfPageTemplateElement(pageSize.Width, margin.Bottom)
			bottomSpace.Foreground = True
			doc.Template.Bottom = bottomSpace

			'draw footer label
			y = font.Height + 1
			bottomSpace.Graphics.SetTransparency(0.5f)
			bottomSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y)
			y = y + 1
			Dim pageNumber As New PdfPageNumberField()
			Dim pageCount As New PdfPageCountField()
			Dim pageNumberLabel As New PdfCompositeField()
			pageNumberLabel.AutomaticFields = New PdfAutomaticField() { pageNumber, pageCount }
			pageNumberLabel.Brush = PdfBrushes.Black
			pageNumberLabel.Font = font
			pageNumberLabel.StringFormat = format
			pageNumberLabel.Text = "page {0} of {1}"
			pageNumberLabel.Draw(bottomSpace.Graphics, pageSize.Width - margin.Right, y)

			Dim headerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Header.png")
			Dim pageLeftTop As New PointF(-margin.Left, -margin.Top)
			Dim header As New PdfPageTemplateElement(pageLeftTop, headerImage.PhysicalDimension)
			header.Foreground = False
			header.Graphics.SetTransparency(0.5f)
			header.Graphics.DrawImage(headerImage, 0, 0)
			doc.Template.Stamps.Add(header)

			Dim footerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Footer.png")
			y = pageSize.Height - footerImage.PhysicalDimension.Height
			Dim footerLocation As New PointF(-margin.Left, y)
			Dim footer As New PdfPageTemplateElement(footerLocation, footerImage.PhysicalDimension)
			footer.Foreground = False
			footer.Graphics.SetTransparency(0.5f)
			footer.Graphics.DrawImage(footerImage, 0, 0)
			doc.Template.Stamps.Add(footer)
		End Sub

		Private Sub DrawPage(ByVal page As PdfPageBase)
			Dim pageWidth As Single = page.Canvas.ClientSize.Width
			Dim y As Single = 0

			'title
			y = y + 5
			Dim brush2 As PdfBrush = New PdfSolidBrush(Color.Black)
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
			Dim format2 As New PdfStringFormat(PdfTextAlignment.Center)
			format2.CharacterSpacing = 1f
			Dim text As String = "Summary of Science"
			page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2)
			Dim size As SizeF = font2.MeasureString(text, format2)
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

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub

	End Class
End Namespace
