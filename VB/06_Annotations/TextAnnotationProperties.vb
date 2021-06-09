Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace TextAnnotationProperties
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load old PDF from disk.
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\FreeTextAnnotation.pdf")

			'Get the first page.
			Dim firstPage As PdfPageBase = pdf.Pages(0)

			'Create a new PDF document.
			Dim newPdf As New PdfDocument()

			'Traverse the annotations of the first page of old PDF
			For Each annotation As PdfAnnotation In firstPage.AnnotationsWidget.List
				'If it is FreeTextAnnotation
				If TypeOf annotation Is PdfFreeTextAnnotationWidget Then
					Dim textAnnotation As PdfFreeTextAnnotationWidget = TryCast(annotation, PdfFreeTextAnnotationWidget)

					'Get its bounds and text
					Dim rect = textAnnotation.Bounds
					Dim text = textAnnotation.Text

					'Add new page for newPdf
					Dim newPage As PdfPageBase = newPdf.Pages.Add(firstPage.Size)

					'Add annotation with the same settings as the annotation of old PDF
					Dim newAnnotation As New PdfFreeTextAnnotation(rect)
					newAnnotation.Text = text
					newAnnotation.CalloutLines = textAnnotation.CalloutLines
					newAnnotation.LineEndingStyle = textAnnotation.LineEndingStyle
					newAnnotation.AnnotationIntent=PdfAnnotationIntent.FreeTextCallout
					newAnnotation.RectangleDifferences = textAnnotation.RectangularDifferenceArray
					newAnnotation.Color = textAnnotation.Color
					newPage.AnnotationsWidget.Add(newAnnotation)
				End If
			Next annotation
			'Save the file
			Dim result As String = "CopyTextAnnotationProperties.pdf"
			newPdf.SaveToFile(result)

			'Launch the file.
			DocumentViewer(result)
		End Sub

		Private Sub DocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
