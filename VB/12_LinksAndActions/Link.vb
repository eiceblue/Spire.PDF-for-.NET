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
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Create a PdfUnitConvertor object
			Dim unitCvtr As New PdfUnitConvertor()

			' Create a PdfMargins object
			Dim margin As New PdfMargins()

			' Set the top margin using converted units
			margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

			' Set the bottom margin equal to the top margin
			margin.Bottom = margin.Top

			' Set the left margin using converted units
			margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

			' Set the right margin equal to the left margin
			margin.Right = margin.Left

			' Add a new page to the document with specified size and margins
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			' Set initial coordinates for drawing text on the page
			Dim y As Single = 100
			Dim x As Single = 10

			' Create a PdfTrueTypeFont object with specified font name and size
			Dim font As New PdfTrueTypeFont(New Font("Lucida Sans Unicode", 14))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font As New PdfTrueTypeFont("Lucida Sans Unicode", 14.0F, FontStyle.Regular, True)
			' =============================================================================

			' Define a label for simple text link
			Dim label As String = "Simple Text Link: "

			' Create a PdfStringFormat object
			Dim format As New PdfStringFormat()

			' Enable measurement of trailing spaces in the text
			format.MeasureTrailingSpaces = True

			' Draw the label on the page at specified coordinates with specified font and format
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)

			' Update the x-coordinate based on the width of the drawn label
			x = font.MeasureString(label, format).Width

			' Create a new PdfTrueTypeFont object for underlined text
			Dim font1 As New PdfTrueTypeFont(New Font("Lucida Sans Unicode", 14, FontStyle.Underline))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font1 As New PdfTrueTypeFont("Lucida Sans Unicode", 14.0F, FontStyl.Underline, True)
			' =============================================================================

			' Define a URL for the web link
			Dim url1 As String = "http://www.e-iceblue.com"

			' Draw the URL on the page at specified coordinates with specified font
			page.Canvas.DrawString(url1, font1, PdfBrushes.CadetBlue, x, y)

			' Update the y-coordinate based on the height of the drawn text and add additional spacing
			y = y + font1.MeasureString(url1).Height + 25

			' Define a label for a web link
			label = "Web Link: "

			' Draw the label on the page at specified coordinates with specified font and format
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)

			' Update the x-coordinate based on the width of the drawn label
			x = font.MeasureString(label, format).Width

			' Define the text for the web link
			Dim text As String = "E-iceblue home"

			' Create a new PdfTextWebLink object
			Dim link2 As New PdfTextWebLink()

			' Set the properties of the web link
			link2.Text = text
			link2.Url = url1
			link2.Font = font1
			link2.Brush = PdfBrushes.CadetBlue

			' Draw the web link on the page at specified coordinates
			link2.DrawTextWebLink(page.Canvas, New PointF(x, y))

			' Update the y-coordinate based on the height of the drawn text and add additional spacing
			y = y + font1.MeasureString(text).Height + 30

			' Define a label for a URI annotation
			label = "URI Annotation: "

			' Draw the label on the page at specified coordinates with specified font and format
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)

			' Update the x-coordinate based on the width of the drawn label
			x = font.MeasureString(label, format).Width

			' Define the text for the URI annotation
			text = "Google"

			' Specify the location and size of the link bounds
			Dim location As New PointF(x, y)
			Dim size As SizeF = font1.MeasureString(text)
			Dim linkBounds As New RectangleF(location, size)

			' Create a new PdfUriAnnotation object with the link bounds
			Dim link3 As New PdfUriAnnotation(linkBounds)

			' Set the properties of the URI annotation
			link3.Border = New PdfAnnotationBorder(0)
			link3.Uri = "http://www.google.com"

			' Add the URI annotation to the page's annotations collection
			TryCast(page, PdfNewPage).Annotations.Add(link3)

			' Draw the text on the page at specified coordinates with specified font
			page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y)

			' Update the y-coordinate based on the height of the drawn text and add additional spacing
			y = y + size.Height + 30

			' Define a label for a URI annotation action
			label = "URI Annotation Action: "

			' Draw the label on the page at specified coordinates with specified font and format
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)

			' Update the x-coordinate based on the width of the drawn label
			x = font.MeasureString(label, format).Width

			' Define the text for the JavaScript action
			text = "JavaScript Action (Click Me)"

			' Specify the location and size of the link bounds
			location = New PointF(x - 2, y - 2)
			size = font1.MeasureString(text)
			size = New SizeF(size.Width + 5, size.Height + 5)
			linkBounds = New RectangleF(location, size)

			' Create a new PdfUriAnnotation object with the link bounds
			Dim link4 As New PdfUriAnnotation(linkBounds)

			' Set the properties of the URI annotation
			link4.Border = New PdfAnnotationBorder(0.75F)
			link4.Color = Color.CadetBlue

			' Define the JavaScript script
			Dim script As String = "app.alert({" & "    cMsg: ""Hello.""," & "    nIcon: 3," & "    cTitle: ""JavaScript Action""" & "});"

			' Create a new PdfJavaScriptAction object with the script
			Dim action As New PdfJavaScriptAction(script)

			' Set the action for the URI annotation
			link4.Action = action

			' Add the URI annotation to the page's annotations collection
			TryCast(page, PdfNewPage).Annotations.Add(link4)

			' Draw the text on the page at specified coordinates with specified font
			page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y)

			' Update the y-coordinate based on the height of the drawn text and add additional spacing
			y = y + size.Height + 30

			' Define a label for "Need Help"
			label = "Need Help:  "

			' Draw the label on the page at specified coordinates with specified font and format
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)

			' Update the x-coordinate based on the width of the drawn label
			x = font.MeasureString(label, format).Width

			' Define the text for the web link
			text = "Go to forum to ask questions"

			' Create a new PdfTextWebLink object
			link2 = New PdfTextWebLink()

			' Set the properties of the web link
			link2.Text = text
			link2.Url = "https://www.e-iceblue.com/forum/components-f5.html"
			link2.Font = font1
			link2.Brush = PdfBrushes.CadetBlue

			' Draw the web link on the page at specified coordinates
			link2.DrawTextWebLink(page.Canvas, New PointF(x, y))

			' Update the y-coordinate based on the height of the drawn text and add additional spacing
			y = y + font1.MeasureString(text).Height + 30

			' Define a label for "Contact us"
			label = "Contact us:  "

			' Draw the label on the page at specified coordinates with specified font and format
			page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)

			' Update the x-coordinate based on the width of the drawn label
			x = font.MeasureString(label, format).Width

			' Define the text for the email link
			text = "Send an email"

			' Create a new PdfTextWebLink object
			link2 = New PdfTextWebLink()

			' Set the properties of the text link
			link2.Text = text
			link2.Url = "mailto:support@e-iceblue.com"
			link2.Font = font1
			link2.Brush = PdfBrushes.CadetBlue

			' Draw the text link on the page at specified coordinates
			link2.DrawTextWebLink(page.Canvas, New PointF(x, y))

			' Update the y-coordinate based on the height of the drawn text and add additional spacing
			y = y + font1.MeasureString(text).Height + 30

			' Save the document to a file
			doc.SaveToFile("Link.pdf")

			' Close the document
			doc.Close()

			' Launch the file
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
