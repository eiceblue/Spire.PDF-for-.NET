Imports System.ComponentModel
Imports System.Text
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
			'Create a pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\AddFreeTextAnnotation.pdf")

			Dim page As PdfPageBase = doc.Pages(0)

			Dim rect As New RectangleF(0, 300, 100, 80)
			'Add free text annotation
			Dim textAnnotation As New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "  Spire.PDF"
			Dim border As New PdfAnnotationBorder(1f)
			Dim font As New PdfFont(PdfFontFamily.TimesRoman, 20)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Gray
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.Slash
			textAnnotation.Color = Color.LightBlue
			textAnnotation.Opacity = 0.8f
			page.AnnotationsWidget.Add(textAnnotation)

			rect = New RectangleF(150, 200, 150, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "High Fidelity Pdf file Conversion"
			border = New PdfAnnotationBorder(1f)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.LightGoldenrodYellow
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow
			textAnnotation.Color = Color.LightPink
			textAnnotation.Opacity = 0.8f
			page.AnnotationsWidget.Add(textAnnotation)

			rect = New RectangleF(150, 280, 280, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "Easily Manipulate document and Form fields"
			border = New PdfAnnotationBorder(1f)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Gray
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle
			textAnnotation.Color = Color.LightSkyBlue
			textAnnotation.Opacity = 0.8f
			page.AnnotationsWidget.Add(textAnnotation)

			rect = New RectangleF(150, 360, 200, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "Security features"
			border = New PdfAnnotationBorder(1f)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Pink
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow
			textAnnotation.Color = Color.LightGreen
			textAnnotation.Opacity = 0.8f
			page.AnnotationsWidget.Add(textAnnotation)

			rect = New RectangleF(150, 440, 200, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "Extract data from Pdf documents"
			border = New PdfAnnotationBorder(1f)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.OrangeRed
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow
			textAnnotation.Color = Color.LightGoldenrodYellow
			textAnnotation.Opacity = 0.8f
			page.AnnotationsWidget.Add(textAnnotation)

			Dim output As String = "AddFreeTextAnnotation.pdf"
			'Save pdf file
			doc.SaveToFile(output)
			doc.Close()

			'Launch the Pdf file
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
