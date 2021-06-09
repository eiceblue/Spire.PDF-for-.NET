Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace DocumentLinkAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Create PdfUnitConvertor to convert the unit
			Dim unitCvtr As New PdfUnitConvertor()

			'Setting for page margin
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(2.0f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			'Add the first page
			Dim page1 As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			'Define a PdfBrush
			Dim brush1 As PdfBrush = PdfBrushes.Black

			'Define a font
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Bold), True)

			'Set the string format 
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Left)

			'Set the position for drawing 
			Dim x As Single = 0
			Dim y As Single = 50

			'Text string 
			Dim specification As String = "The sample demonstrates how to create a local document link in PDF document."

			'Draw text string on first page 
			page1.Canvas.DrawString(specification, font1, brush1, x, y, format1)

			'Use MeasureString to get the height of string
			y = y + font1.MeasureString(specification, format1).Height +10

			'Add the second page
			Dim page2 As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			'String text
			Dim PageContent As String = "This is the second page!"

			'Draw text string on second page 
			page2.Canvas.DrawString(PageContent, font1, brush1, x, y, format1)

			'Add DocumentLinkAnnotation on the first page and link to the second page
			AddDocumentLinkAnnotation(doc,0,1, y)


			Dim result As String = "DocumentLinkAnnotation_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Shared Sub AddDocumentLinkAnnotation(ByVal pdf As PdfDocument, ByVal AddPage As Integer, ByVal DestinationPage As Integer, ByVal y As Single)
			'Define a font
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12f))

			'Set the string format
			Dim format As New PdfStringFormat(PdfTextAlignment.Left)

			'Text string
			Dim prompt As String = "Local document Link: "

			'Draw text string on page that
			pdf.Pages(AddPage).Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

			'Use MeasureString to get the width of string
			Dim x As Single = font.MeasureString(prompt, format).Width

			'Create a PdfDestination with specific page
			Dim dest As New PdfDestination(pdf.Pages(DestinationPage))

			'Set the location of destination
			dest.Location = New PointF(0, y)

			'Set 50% zoom factor
			dest.Zoom = 0.5f

			'Label string
			Dim label As String = "Click here to link the second page."

			'Use MeasureString to get the SizeF of string
			Dim size As SizeF = font.MeasureString(label)

			'Create a rectangle
			Dim bounds As New RectangleF(x, y, size.Width, size.Height)

			'Draw label string
			pdf.Pages(AddPage).Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)

			'Create PdfDocumentLinkAnnotation on the rectangle and link to the destination  
			Dim annotation As New PdfDocumentLinkAnnotation(bounds, dest)

			'Set color for annotation
			annotation.Color = Color.Blue

			'Add annotation to the page
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
