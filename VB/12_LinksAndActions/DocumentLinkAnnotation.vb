Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics

Namespace DocumentLinkAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument
			Dim doc As New PdfDocument()

			' Create a PdfUnitConvertor for unit conversion
			Dim unitCvtr As New PdfUnitConvertor()

			' Create a PdfMargins object for setting margins
			Dim margin As New PdfMargins()

			' Set the top margin using unit conversion
			margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

			' Set the bottom margin equal to the top margin
			margin.Bottom = margin.Top

			' Set the left margin using unit conversion
			margin.Left = unitCvtr.ConvertUnits(2.0F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

			' Set the right margin equal to the left margin
			margin.Right = margin.Left

			' Add a new page with A4 size and specified margins
			Dim page1 As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			' Set the brush for drawing text
			Dim brush1 As PdfBrush = PdfBrushes.Black

			' Set the font for the text
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 12.0F, FontStyle.Bold), True)

			' Set the string format for the text alignment
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Left)

			' Set the initial x and y coordinates for drawing text
			Dim x As Single = 0
			Dim y As Single = 50

			' Specify the specification string
			Dim specification As String = "The sample demonstrates how to create a local document link in PDF document."

			' Draw the specification string on page 1
			page1.Canvas.DrawString(specification, font1, brush1, x, y, format1)

			' Update the y-coordinate for the next content
			y = y + font1.MeasureString(specification, format1).Height + 10

			' Add a new page with A4 size and specified margins
			Dim page2 As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			' Specify the content string for page 2
			Dim PageContent As String = "This is the second page!"

			' Draw the content string on page 2
			page2.Canvas.DrawString(PageContent, font1, brush1, x, y, format1)

			' Add a document link annotation between page 1 and page 2 at the specified y-coordinate
			AddDocumentLinkAnnotation(doc, 0, 1, y)

			' Specify the output file path
			Dim result As String = "DocumentLinkAnnotation_out.pdf"

			' Save the document to the output file
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Shared Sub AddDocumentLinkAnnotation(ByVal pdf As PdfDocument, ByVal AddPage As Integer, ByVal DestinationPage As Integer, ByVal y As Single)
			' Create a TrueType font with Arial, size 12
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F))

			' Create a StringFormat for left alignment
			Dim format As New PdfStringFormat(PdfTextAlignment.Left)

			' Specify the prompt for the local document link
			Dim prompt As String = "Local document Link: "

			' Draw the prompt on the specified page's canvas at position (0, y)
			pdf.Pages(AddPage).Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

			' Calculate the x-coordinate based on the width of the prompt
			Dim x As Single = font.MeasureString(prompt, format).Width

			' Create a destination for the link pointing to the specified page
			Dim dest As New PdfDestination(pdf.Pages(DestinationPage))
			dest.Location = New PointF(0, y)
			dest.Zoom = 0.5F

			' Specify the label text for the link
			Dim label As String = "Click here to link the second page."

			' Measure the size of the label text
			Dim size As SizeF = font.MeasureString(label)

			' Define the bounds for the annotation
			Dim bounds As New RectangleF(x, y, size.Width, size.Height)

			' Draw the label text on the specified page's canvas at position (x, y)
			pdf.Pages(AddPage).Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)

			' Create a document link annotation with the specified bounds and destination
			Dim annotation As New PdfDocumentLinkAnnotation(bounds, dest)

			' Set the color of the annotation
			annotation.Color = Color.Blue

			' Add the annotation to the specified page's annotations collection
			TryCast(pdf.Pages(AddPage), PdfNewPage).Annotations.Add(annotation)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
