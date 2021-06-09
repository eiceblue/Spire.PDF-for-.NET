Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Annotations

Namespace Link
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()

			'Set margins
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			'Create one page
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			Dim y As Single = 100
			Dim x As Single = 10
			Dim font As New PdfTrueTypeFont(New Font("Lucida Sans Unicode", 14))

			Dim label As String = "Simple Text Link: "
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)
			x = font.MeasureString(label, format).Width
			Dim font1 As New PdfTrueTypeFont(New Font("Lucida Sans Unicode", 14, FontStyle.Underline))
			Dim url1 As String = "http://www.e-iceblue.com"
			page.Canvas.DrawString(url1, font1, PdfBrushes.CadetBlue, x, y)
			y = y + font1.MeasureString(url1).Height + 25

			label = "Web Link: "
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)
			x = font.MeasureString(label, format).Width
			Dim text As String = "E-iceblue home"
			Dim link2 As New PdfTextWebLink()
			link2.Text = text
			link2.Url = url1
			link2.Font = font1
			link2.Brush = PdfBrushes.CadetBlue
			link2.DrawTextWebLink(page.Canvas, New PointF(x, y))
			y = y + font1.MeasureString(text).Height + 30

			label = "URI Annonation: "
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)
			x = font.MeasureString(label, format).Width
			text = "Google"
			Dim location As New PointF(x, y)
			Dim size As SizeF = font1.MeasureString(text)
			Dim linkBounds As New RectangleF(location, size)
			Dim link3 As New PdfUriAnnotation(linkBounds)
			link3.Border = New PdfAnnotationBorder(0)
			link3.Uri = "http://www.google.com"
			TryCast(page, PdfNewPage).Annotations.Add(link3)
			page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y)
			y = y + size.Height + 30

			label = "URI Annonation Action: "
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)
			x = font.MeasureString(label, format).Width
			text = "JavaScript Action (Click Me)"
			location = New PointF(x-2, y-2)
			size = font1.MeasureString(text)
			size = New SizeF(size.Width+5,size.Height+5)
			linkBounds = New RectangleF(location,size)
			Dim link4 As New PdfUriAnnotation(linkBounds)
			link4.Border = New PdfAnnotationBorder(0.75f)
			link4.Color = Color.CadetBlue
			'Script
			Dim script As String = "app.alert({" & "    cMsg: ""Hello.""," & "    nIcon: 3," & "    cTitle: ""JavaScript Action""" & "});"
			Dim action As New PdfJavaScriptAction(script)
			link4.Action = action
			TryCast(page, PdfNewPage).Annotations.Add(link4)
			page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y)
			y = y + size.Height + 30

			label = "Need Help:  "
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)
			x = font.MeasureString(label, format).Width
			text = "Go to forum to ask questions"
			link2 = New PdfTextWebLink()
			link2.Text = text
			link2.Url = "https://www.e-iceblue.com/forum/components-f5.html"
			link2.Font = font1
			link2.Brush = PdfBrushes.CadetBlue
			link2.DrawTextWebLink(page.Canvas, New PointF(x, y))
			y = y + font1.MeasureString(text).Height + 30

			label = "Contct us:  "
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)
			x = font.MeasureString(label, format).Width
			text = "Send an email"
			link2 = New PdfTextWebLink()
			link2.Text = text
			link2.Url = "mailto:support@e-iceblue.com"
			link2.Font = font1
			link2.Brush = PdfBrushes.CadetBlue
			link2.DrawTextWebLink(page.Canvas, New PointF(x, y))
			y = y + font1.MeasureString(text).Height + 30

			'Save pdf file.
			doc.SaveToFile("Link.pdf")
			doc.Close()

			'Launch the file.
			PDFDocumentViewer("Link.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
