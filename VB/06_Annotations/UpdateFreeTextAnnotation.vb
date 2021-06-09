Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace UpdateFreeTextAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document.
			Dim pdf As New PdfDocument()

			'Load the file from disk.
			pdf.LoadFromFile("..\..\..\..\..\..\Data\UpdateFreeTextAnnotation.pdf")

			'Get the annotation Collection from the document.
			Dim annotations As PdfAnnotationCollection = pdf.Pages(0).AnnotationsWidget

			'Update free text annotation.
			For Each annotaion As PdfFreeTextAnnotationWidget In annotations
				annotaion.Color = Color.YellowGreen

			Next annotaion

			Dim result As String = "UpdateFreeTextAnnotation_out.pdf"

			'Save the document
			pdf.SaveToFile(result)
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
