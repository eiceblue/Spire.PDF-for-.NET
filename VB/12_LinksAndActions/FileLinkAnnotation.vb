Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics

Namespace FileLinkAnnotation
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
			margin.Left = unitCvtr.ConvertUnits(3.0F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

			' Set the right margin equal to the left margin
			margin.Right = margin.Left

			' Add a new page with A4 size and specified margins
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			' Set the brush for drawing text
			Dim brush1 As PdfBrush = PdfBrushes.Black

			' Set the font for the text
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 13.0F, FontStyle.Bold), True)
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font1 As New PdfTrueTypeFont("Arial", 13.0F, FontStyle.Bold, True)
			' =============================================================================

			' Set the string format for the text alignment
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Left)

			' Set the initial x and y coordinates for drawing text
			Dim x As Single = 0
			Dim y As Single = 50

			' Specify the specification string
			Dim specification As String = "The sample demonstrates how to create a file link in PDF document."

			' Draw the specification string on the page
			page.Canvas.DrawString(specification, font1, brush1, x, y, format1)

			' Update the y-coordinate for the next content
			y = y + font1.MeasureString(specification, format1).Height + 10

			' Add a file link annotation at the specified y-coordinate
			AddFileLinkAnnotation(page, y)

			' Specify the output file path
			Dim result As String = "FileLinkAnnotation_out.pdf"

			' Save the document to the output file
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Shared Sub AddFileLinkAnnotation(ByVal page As PdfPageBase, ByVal y As Single)
			' Declare and initialize a new PdfTrueTypeFont object with Arial font and size 12
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font As New PdfTrueTypeFont("Arial", 12.0F, FontStyle.Regular, True)
			' =============================================================================

			' Declare and initialize a new PdfStringFormat object with left alignment
			Dim format As New PdfStringFormat(PdfTextAlignment.Left)

			' Declare and initialize a string variable
			Dim prompt As String = "Launch a File: "

			' Draw the prompt string on the page's canvas using the specified font, color, and coordinates
			page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

			' Calculate the width of the prompt string using the specified font and format
			Dim x As Single = font.MeasureString(prompt, format).Width

			' Declare and initialize a label string variable
			Dim label As String = "Sample.pdf"

			' Measure the size of the label string using the specified font
			Dim size As SizeF = font.MeasureString(label)

			' Create a rectangle that represents the bounds of the label text using the calculated x coordinate, y coordinate, width, and height
			Dim bounds As New RectangleF(x, y, size.Width, size.Height)

			' Draw the label string on the page's canvas using the specified font, color, and coordinates
			page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)

			' Create a new PdfFileLinkAnnotation object with the specified bounds and file path
			Dim annotation As New PdfFileLinkAnnotation(bounds, "..\..\..\..\..\..\Data\Sample.pdf")

			' Set the color of the annotation to blue
			annotation.Color = Color.Blue

			' Add the annotation to the page's annotations collection
			TryCast(page, PdfNewPage).Annotations.Add(annotation)

		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
