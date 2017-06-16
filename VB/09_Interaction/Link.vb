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

			'margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			' Create one page
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			Dim y As Single = 10
			Dim x As Single = 0
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12))
			Dim label As String = "Simple Link: "
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, 0, y, format)
			x = font.MeasureString(label, format).Width
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 12, FontStyle.Underline))
			Dim url1 As String = "http://www.e-iceblue.com"
			page.Canvas.DrawString(url1, font1, PdfBrushes.Blue, x, y)
			y = y + font1.MeasureString(url1).Height

			label = "Web Link: "
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, 0, y, format)
			x = font.MeasureString(label, format).Width
			Dim text As String = "e-iceblue"
			Dim link2 As New PdfTextWebLink()
			link2.Text = text
			link2.Url = url1
			link2.Font = font1
			link2.Brush = PdfBrushes.Blue
			link2.DrawTextWebLink(page.Canvas, New PointF(x, y))
			y = y + font1.MeasureString(text).Height

			label = "URI Annonationa: "
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, 0, y, format)
			x = font.MeasureString(label, format).Width
			text = "Google"
			Dim location As New PointF(x, y)
			Dim size As SizeF = font1.MeasureString(text)
			Dim linkBounds As New RectangleF(location, size)
			Dim link3 As New PdfUriAnnotation(linkBounds)
			link3.Border = New PdfAnnotationBorder(0)
			link3.Uri = "http://www.google.com"
			TryCast(page, PdfNewPage).Annotations.Add(link3)
			page.Canvas.DrawString(text, font1, PdfBrushes.Blue, x, y)
			y = y + size.Height

			label = "URI Annonationa Action: "
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, 0, y, format)
			x = font.MeasureString(label, format).Width
			text = "JavaScript Action (Click Me)"
			location = New PointF(x, y)
			size = font1.MeasureString(text)
			linkBounds = New RectangleF(location, size)
			Dim link4 As New PdfUriAnnotation(linkBounds)
			link4.Border = New PdfAnnotationBorder(0.75f)
			link4.Color = Color.LightGray
			'script
			Dim script As String = "app.alert({" & "    cMsg: ""Hello.""," & "    nIcon: 3," & "    cTitle: ""JavaScript Action""" & "});"
			Dim action As New PdfJavaScriptAction(script)
			link4.Action = action
			TryCast(page, PdfNewPage).Annotations.Add(link4)
			page.Canvas.DrawString(text, font1, PdfBrushes.Blue, x, y)
			y = y + size.Height

			'Save pdf file.
			doc.SaveToFile("Link.pdf")
			doc.Close()

			'Launching the Pdf file.
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
