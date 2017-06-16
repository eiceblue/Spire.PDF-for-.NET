Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace Transition
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()
			doc.ViewerPreferences.PageMode = PdfPageMode.FullScreen

			'margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			'create section
			Dim section As PdfSection = doc.Sections.Add()
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins = margin
			section.PageSettings.Transition = New PdfPageTransition()
			section.PageSettings.Transition.Duration = 2
			section.PageSettings.Transition.Style = PdfTransitionStyle.Fly
			section.PageSettings.Transition.PageDuration = 1

			Dim page As PdfNewPage = section.Pages.Add()
			page.BackgroundColor = Color.Red
			DrawPage(page)

			page = section.Pages.Add()
			page.BackgroundColor = Color.Green
			DrawPage(page)

			page = section.Pages.Add()
			page.BackgroundColor = Color.Blue
			DrawPage(page)

			section = doc.Sections.Add()
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins = margin
			section.PageSettings.Transition = New PdfPageTransition()
			section.PageSettings.Transition.Duration = 2
			section.PageSettings.Transition.Style = PdfTransitionStyle.Box
			section.PageSettings.Transition.PageDuration = 1

			page = section.Pages.Add()
			page.BackgroundColor = Color.Orange
			DrawPage(page)

			page = section.Pages.Add()
			page.BackgroundColor = Color.Brown
			DrawPage(page)

			page = section.Pages.Add()
			page.BackgroundColor = Color.Navy
			DrawPage(page)

			section = doc.Sections.Add()
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins = margin
			section.PageSettings.Transition = New PdfPageTransition()
			section.PageSettings.Transition.Duration = 2
			section.PageSettings.Transition.Style = PdfTransitionStyle.Split
			section.PageSettings.Transition.Dimension = PdfTransitionDimension.Vertical
			section.PageSettings.Transition.Motion = PdfTransitionMotion.Inward
			section.PageSettings.Transition.PageDuration = 1

			page = section.Pages.Add()
			page.BackgroundColor = Color.Orange
			DrawPage(page)

			page = section.Pages.Add()
			page.BackgroundColor = Color.Brown
			DrawPage(page)

			page = section.Pages.Add()
			page.BackgroundColor = Color.Navy
			DrawPage(page)

			'Save pdf file.
			doc.SaveToFile("Transition.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("Transition.pdf")
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

	End Class
End Namespace
