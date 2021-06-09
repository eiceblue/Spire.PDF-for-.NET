Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics

Namespace Annotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			'Create one page
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			'Title
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 13f, FontStyle.Bold Or FontStyle.Italic), True)
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Left)
			Dim y As Single = 50
			Dim s As String = "The sample demonstrates how to add annotations in PDF document."

			page.Canvas.DrawString(s, font1, brush1, 0, y-5, format1)
			y = y + font1.MeasureString(s, format1).Height
			y = y + 15


			y = AddDocumentLinkAnnotation(page, y)

			y = y + 6
			y = AddFileLinkAnnotation(page, y)

			y = y + 6
			y = AddFreeTextAnnotation(page, y)

			y = y + 6
			y = AddLineAnnotation(page, y)

			y = y + 6
			y = AddTextMarkupAnnotation(page, y)

			y = y + 6
			y = AddPopupAnnotation(page, y)

			y = y + 6
			y = AddRubberStampAnnotation(page, y)

			'Save pdf file
			doc.SaveToFile("Annotation.pdf")
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer("Annotation.pdf")
		End Sub

		Private Function AddDocumentLinkAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12f))
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True
			Dim prompt As String = "Document Link: "
			Dim size As SizeF = font.MeasureString(prompt)

			page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
			Dim x As Single = font.MeasureString(prompt, format).Width

			Dim dest As New PdfDestination(page)
			dest.Mode = PdfDestinationMode.Location
			dest.Location = New PointF(0, y)
			dest.Zoom = 2f

			Dim label As String = "Click me, Zoom 200%"
			size = font.MeasureString(label)
			Dim bounds As New RectangleF(x, y, size.Width, size.Height)
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
			Dim annotation As New PdfDocumentLinkAnnotation(bounds, dest)
			annotation.Color = Color.Blue
			TryCast(page, PdfNewPage).Annotations.Add(annotation)
			y = bounds.Bottom

			Return y
		End Function

		Private Function AddFileLinkAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12f))
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True
			Dim prompt As String = "Launch File: "
			Dim size As SizeF = font.MeasureString(prompt)

			page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
			Dim x As Single = font.MeasureString(prompt, format).Width

			Dim label As String = "Launch Notepad.exe"
			size = font.MeasureString(label)
			Dim bounds As New RectangleF(x, y, size.Width, size.Height)
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
			Dim annotation As New PdfFileLinkAnnotation(bounds, "C:\Windows\Notepad.exe")
			annotation.Color = Color.Blue
			TryCast(page, PdfNewPage).Annotations.Add(annotation)
			y = bounds.Bottom

			Return y
		End Function

		Private Function AddFreeTextAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12f))
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True
			Dim prompt As String = "Text Markup: "
			Dim size As SizeF = font.MeasureString(prompt)

			page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
			Dim x As Single = font.MeasureString(prompt, format).Width

			Dim label As String = "I'm a text box, not a TV"
			size = font.MeasureString(label)
			Dim bounds As New RectangleF(x, y, size.Width, size.Height)
			page.Canvas.DrawRectangle(New PdfPen(Color.Blue, 0.1f), bounds)
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
			Dim location As New PointF(bounds.Right + 16, bounds.Top - 16)
			Dim annotaionBounds As New RectangleF(location, New SizeF(80, 32))
			Dim annotation As New PdfFreeTextAnnotation(annotaionBounds)
			annotation.AnnotationIntent = PdfAnnotationIntent.FreeTextCallout
			annotation.Border = New PdfAnnotationBorder(0.5f)
			annotation.BorderColor = Color.Red
			location = New PointF(bounds.Right + 16, bounds.Top - 16)
			annotation.CalloutLines = New PointF() { New PointF(bounds.Right, bounds.Top), New PointF(bounds.Right + 8, bounds.Top - 8), location }
			annotation.Color = Color.Yellow
			annotation.Flags = PdfAnnotationFlags.Locked
			annotation.Font = font
			annotation.LineEndingStyle = PdfLineEndingStyle.OpenArrow
			annotation.MarkupText = "Just a joke."
			annotation.Opacity = 0.75f
			annotation.TextMarkupColor = Color.Green

			TryCast(page, PdfNewPage).Annotations.Add(annotation)
			y = bounds.Bottom

			Return y
		End Function

		Private Function AddLineAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12f))
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True
			Dim prompt As String = "Line Annotation: "
			Dim size As SizeF = font.MeasureString(prompt)

			page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
			Dim x As Single = font.MeasureString(prompt, format).Width

			Dim label As String = "Line Anotation"
			size = font.MeasureString(label)
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
			Dim bounds As New RectangleF(x, y, size.Width, size.Height)
			Dim linePoints() As Integer = { CInt(Fix(bounds.Left)), CInt(Fix(bounds.Top)), CInt(Fix(bounds.Right)), CInt(Fix(bounds.Bottom)) }
			Dim annotation As New PdfLineAnnotation(linePoints, "Annotation")
			annotation.BeginLineStyle = PdfLineEndingStyle.ClosedArrow
			annotation.EndLineStyle = PdfLineEndingStyle.ClosedArrow
			annotation.LineCaption = True
			annotation.BackColor = Color.Black
			annotation.CaptionType = PdfLineCaptionType.Inline
			TryCast(page, PdfNewPage).Annotations.Add(annotation)
			y = bounds.Bottom

			Return y
		End Function

		Private Function AddTextMarkupAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12f))
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True
			Dim prompt As String = "Highlight incorrect spelling: "
			Dim size As SizeF = font.MeasureString(prompt, format)
			page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
			Dim x As Single = size.Width

			Dim label As String = "demo of anotation"
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
			size = font.MeasureString("demo of ", format)
			x = x + size.Width
			Dim incorrectWordLocation As New PointF(x, y)
			Dim markupText As String = "Should be 'annotation'"
			Dim annotation As New PdfTextMarkupAnnotation(markupText, "anotation",New RectangleF(x, y, 100f, 100f), font)
			annotation.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight
			annotation.TextMarkupColor = Color.LightSkyBlue
			TryCast(page, PdfNewPage).Annotations.Add(annotation)
			y = y + size.Height

			Return y
		End Function

		Private Function AddPopupAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12f))
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True
			Dim prompt As String = "Markup incorrect spelling: "
			Dim size As SizeF = font.MeasureString(prompt, format)
			page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
			Dim x As Single = size.Width

			Dim label As String = "demo of annotation"
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
			x = x + font.MeasureString(label, format).Width
			Dim markupText As String = "All words were spelled correctly"
			size = font.MeasureString(markupText)
			Dim annotation As New PdfPopupAnnotation(New RectangleF(New PointF(x, y), SizeF.Empty), markupText)
			annotation.Icon = PdfPopupIcon.Paragraph
			annotation.Open = True
			annotation.Color = Color.Yellow
			TryCast(page, PdfNewPage).Annotations.Add(annotation)
			y = y + size.Height

			Return y
		End Function

		Private Function AddRubberStampAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12f))
			Dim format As New PdfStringFormat()
			format.MeasureTrailingSpaces = True
			Dim prompt As String = "Markup incorrect spelling: "
			Dim size As SizeF = font.MeasureString(prompt, format)
			page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
			Dim x As Single = size.Width

			Dim label As String = "demo of annotation"
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
			x = x + font.MeasureString(label, format).Width
			Dim markupText As String = "Just a draft, not checked."
			size = font.MeasureString(markupText)
			Dim annotation As New PdfRubberStampAnnotation(New RectangleF(x, y, font.Height, font.Height), markupText)
			annotation.Icon = PdfRubberStampAnnotationIcon.Draft
			annotation.Color = Color.Plum
			TryCast(page, PdfNewPage).Annotations.Add(annotation)
			y = y + size.Height

			Return y
		End Function

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
