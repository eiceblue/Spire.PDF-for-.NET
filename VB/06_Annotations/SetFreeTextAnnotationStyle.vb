Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace SetFreeTextAnnotationStyle
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document.
			Dim doc As New PdfDocument()

			'Load the file from disk.
			doc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_4.pdf")

			'Get the first page of PDF file.
			Dim page As PdfPageBase = doc.Pages(0)

			'Initialize a PdfFreeTextAnnotation.
			Dim rect As New RectangleF(150, 120, 150, 30)
			Dim textAnnotation As New PdfFreeTextAnnotation(rect)
			'Specify content.
			textAnnotation.Text = vbLf & "Free Text Annotation Formatting"
			'Set free text annotation formatting and add it to page.
			Dim font As New PdfFont(PdfFontFamily.TimesRoman, 10)
			Dim border As New PdfAnnotationBorder(1f)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Purple
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle
			textAnnotation.Color = Color.Green
			textAnnotation.Opacity = 0.8f
			page.AnnotationsWidget.Add(textAnnotation)

			rect = New RectangleF(150, 200, 150, 40)
			textAnnotation = New PdfFreeTextAnnotation(rect)
			textAnnotation.Text = vbLf & "Free Text Annotation Formatting"
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
			textAnnotation.Text = vbLf & "oHow to Set Free Text Annotation Formatting in Pdf file"
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
			textAnnotation.Text = vbLf & "Free Text Annotation Formatting"
			border = New PdfAnnotationBorder(1f)
			font = New PdfFont(PdfFontFamily.Helvetica, 10)
			textAnnotation.Font = font
			textAnnotation.Border = border
			textAnnotation.BorderColor = Color.Pink
			textAnnotation.LineEndingStyle = PdfLineEndingStyle.RClosedArrow
			textAnnotation.Color = Color.LightGreen
			textAnnotation.Opacity = 0.8f
			page.AnnotationsWidget.Add(textAnnotation)

			Dim result As String = "SetFreeTextAnnotationFormatting_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
