Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace CreatePdfLineAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a PDF document.
			Dim document As New PdfDocument()

			'Add a new page.
			Dim page As PdfPageBase = document.Pages.Add()

			'Create a line annotation.
			Dim linePoints() As Integer = { 100, 650, 180, 650 }
			Dim lineAnnotation As New PdfLineAnnotation(linePoints, "This is the first line annotation")

			'Set the line border.
			lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Solid
			lineAnnotation.lineBorder.BorderWidth = 1

			'Set the line intent.
			lineAnnotation.LineIntent = PdfLineIntent.LineDimension

			'Set the line style.
			lineAnnotation.BeginLineStyle = PdfLineEndingStyle.Butt
			lineAnnotation.EndLineStyle = PdfLineEndingStyle.Diamond

			'Set the line flag.
			lineAnnotation.Flags = PdfAnnotationFlags.Default

			'Set the line color.
			lineAnnotation.InnerLineColor = New PdfRGBColor(Color.Green)
			lineAnnotation.BackColor = New PdfRGBColor(Color.Green)

			'Set the leader line.
			lineAnnotation.LeaderLineExt = 0
			lineAnnotation.LeaderLine = 0

			'Add the line annotation to the page.
			page.AnnotationsWidget.Add(lineAnnotation)

			linePoints = New Integer() { 100, 550, 280, 550 }
			lineAnnotation = New PdfLineAnnotation(linePoints, "This is the second line annotation")
			lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Underline
			lineAnnotation.lineBorder.BorderWidth =2
			lineAnnotation.LineIntent = PdfLineIntent.LineArrow
			lineAnnotation.BeginLineStyle = PdfLineEndingStyle.Circle
			lineAnnotation.EndLineStyle = PdfLineEndingStyle.Diamond
			lineAnnotation.Flags = PdfAnnotationFlags.Default
			lineAnnotation.InnerLineColor = New PdfRGBColor(Color.Pink)
			lineAnnotation.BackColor = New PdfRGBColor(Color.Pink)
			lineAnnotation.LeaderLineExt = 0
			lineAnnotation.LeaderLine = 0
			page.AnnotationsWidget.Add(lineAnnotation)

			linePoints = New Integer() { 100, 450, 280, 450 }
			lineAnnotation = New PdfLineAnnotation(linePoints, "This is the third line annotation")
			lineAnnotation.lineBorder.BorderStyle = PdfBorderStyle.Beveled
			lineAnnotation.lineBorder.BorderWidth = 2
			lineAnnotation.LineIntent = PdfLineIntent.LineDimension
			lineAnnotation.BeginLineStyle = PdfLineEndingStyle.None
			lineAnnotation.EndLineStyle = PdfLineEndingStyle.None
			lineAnnotation.Flags = PdfAnnotationFlags.Default
			lineAnnotation.InnerLineColor = New PdfRGBColor(Color.Blue)
			lineAnnotation.BackColor = New PdfRGBColor(Color.Blue)
			lineAnnotation.LeaderLineExt = 1
			lineAnnotation.LeaderLine = 1
			page.AnnotationsWidget.Add(lineAnnotation)

			Dim result As String = "CreatePdfLineAnnotation_out.pdf"

			'Save the document
			document.SaveToFile(result)
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
