Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace SetFreeTextAnnotationSubject
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
			textAnnotation.Text = vbLf & "Set free text annotation subject"

			'Set subject.
			textAnnotation.Subject = "SubjectTest"

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

			'Save the document
			Dim result As String = "SetFreeTextAnnotationSubject_out.pdf"
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
