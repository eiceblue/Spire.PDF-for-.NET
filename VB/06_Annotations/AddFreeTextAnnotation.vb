Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics

Namespace AddFreeTextAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load an existing PDF document from file
			doc.LoadFromFile("..\..\..\..\..\..\Data\AddFreeTextAnnotation.pdf")

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Define the rectangle for the free text annotation
			Dim rect As New RectangleF(0, 300, 100, 80)

			' Create a new PdfFreeTextAnnotation object with the specified rectangle
			Dim textAnnotation As New PdfFreeTextAnnotation(rect)

			' Set the text content of the annotation
			textAnnotation.Text = vbLf & "  Spire.PDF"

			' Set the border properties of the annotation
			Dim border As New PdfAnnotationBorder(1.0F)
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Gray

			' Set the font and font size for the text annotation
			Dim font As New PdfFont(PdfFontFamily.TimesRoman, 20)
			textAnnotation.Font = font

			' Set the line ending style of the annotation
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.Slash

			' Set the color and opacity of the annotation
			textAnnotation.Color = Color.LightBlue
			textAnnotation.Opacity = 0.8F

			' Add the text annotation to the page's collection of annotations
            page.Annotations.Add(textAnnotation)

			' Repeat the above steps for additional text annotations with different properties
			rect = New RectangleF(150, 200, 150, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "High Fidelity Pdf file Conversion"
			border = New PdfAnnotationBorder(1.0F)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.LightGoldenrodYellow
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow
			textAnnotation.Color = Color.LightPink
			textAnnotation.Opacity = 0.8F
            page.Annotations.Add(textAnnotation)

			rect = New RectangleF(150, 280, 280, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "Easily Manipulate document and Form fields"
			border = New PdfAnnotationBorder(1.0F)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Gray
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle
			textAnnotation.Color = Color.LightSkyBlue
			textAnnotation.Opacity = 0.8F
            page.Annotations.Add(textAnnotation)

			rect = New RectangleF(150, 360, 200, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "Security features"
			border = New PdfAnnotationBorder(1.0F)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Pink
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow
			textAnnotation.Color = Color.LightGreen
			textAnnotation.Opacity = 0.8F
            page.Annotations.Add(textAnnotation)

			rect = New RectangleF(150, 440, 200, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "Extract data from Pdf documents"
			border = New PdfAnnotationBorder(1.0F)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.OrangeRed
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow
			textAnnotation.Color = Color.LightGoldenrodYellow
			textAnnotation.Opacity = 0.8F
            page.Annotations.Add(textAnnotation)

			' Save the modified document to a new file
			Dim output As String = "AddFreeTextAnnotation.pdf"
			doc.SaveToFile(output)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
