Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace InvisibleFreeTextAnnotation
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

			'Add a free text annotation to the page and set it invisible.
			Dim rect As New RectangleF(100, 120, 150, 30)
			Dim FreetextAnnotation As New PdfFreeTextAnnotation(rect)
			FreetextAnnotation.Text = "Invisible Free Text Annotation"
			Dim font As New PdfFont(PdfFontFamily.TimesRoman, 10)
			Dim border As New PdfAnnotationBorder(1f)
			FreetextAnnotation.Font = font
			FreetextAnnotation.Border = border
			FreetextAnnotation.BorderColor = Color.Purple
			FreetextAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle
			FreetextAnnotation.Color = Color.Green
			FreetextAnnotation.Opacity = 0.8f
			'Invisible free text annotation.
			FreetextAnnotation.Flags = PdfAnnotationFlags.Print Or PdfAnnotationFlags.NoView
			page.AnnotationsWidget.Add(FreetextAnnotation)

			'Add a free text annotation show it on the page.
			rect = New RectangleF(100, 180, 150, 30)
			FreetextAnnotation = New PdfFreeTextAnnotation(rect)
			FreetextAnnotation.Text = "Show Free Text Annotation"
			FreetextAnnotation.Font = font
			FreetextAnnotation.Border = border
			FreetextAnnotation.BorderColor = Color.LightPink
			FreetextAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle
			FreetextAnnotation.Color = Color.LightGreen
			FreetextAnnotation.Opacity = 0.8f
			page.AnnotationsWidget.Add(FreetextAnnotation)

			Dim result As String = "InvisibleFreeTextAnnotation_out.pdf"

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
