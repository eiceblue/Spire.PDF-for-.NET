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
			'create a pdf document
			Dim doc As New PdfDocument()

			'add a new page
			Dim page As PdfPageBase = doc.Pages.Add()

			Dim rect As New RectangleF(0, 40, 100, 50)

			'add free text annotations
			Dim textAnnotation As New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = "Spire.PDF"
			Dim border As New PdfAnnotationBorder(1f)
			Dim font As New PdfFont(PdfFontFamily.TimesRoman, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.LightGreen
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle
			textAnnotation.Color = Color.LightPink
			textAnnotation.Opacity = 0.8f
			page.AnnotationsWidget.Add(textAnnotation)

			rect = New RectangleF(50, 100, 150, 50)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = "Spire.Office"
			border = New PdfAnnotationBorder(1f)
			font = New PdfFont(PdfFontFamily.Courier, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Pink
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow
			textAnnotation.Color = Color.LightGreen
			textAnnotation.Opacity = 0.8f
			page.AnnotationsWidget.Add(textAnnotation)

			Dim output As String = "AddFreeTextAnnotation.pdf"
			'Save pdf file.
			doc.SaveToFile(output)
			doc.Close()

			'Launching the Pdf file.
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
