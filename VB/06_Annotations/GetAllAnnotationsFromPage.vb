Imports Spire.Pdf
Imports System.IO
Imports System.Text
Imports Spire.Pdf.Annotations

Namespace GetAllAnnotationsFromPage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click

			'Create a new PDF document.
			Dim pdf As New PdfDocument()

			'Load the file from disk.
			pdf.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_3.pdf")

			'Get all annotations from the first page.
			Dim annotations As PdfAnnotationCollection = pdf.Pages(0).AnnotationsWidget

			Dim content As New StringBuilder()

			For i As Integer = 0 To annotations.Count - 1
				'A text annotation will attach a popup annotation since they are father-son relationship. 
				'The annotation information exists in the text annotation, so here we mask the blank popup annotation.
				If TypeOf annotations(i) Is PdfPopupAnnotationWidget Then
					Continue For
				End If
				content.AppendLine("Annotation information: ")
				content.AppendLine("Text: " & annotations(i).Text)
				Dim modifiedDate As String = annotations(i).ModifiedDate.ToString()
				content.AppendLine("ModifiedDate: " & modifiedDate)
			Next i

			Dim result As String = "Result-GetAllAnnotationsFromPage.txt"

			'Save to file.
			File.WriteAllText(result, content.ToString())

			'Launch the file.
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
