Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace GetParticularAnnotationInfo
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

			'Get the annotation collection from the document.
			Dim annotations As PdfAnnotationCollection = pdf.Pages(0).AnnotationsWidget

			'Get particular annotation information from the document.
			Dim content As New StringBuilder()
			If TypeOf annotations(0) Is PdfTextAnnotationWidget Then
				Dim textAnnotation As PdfTextAnnotationWidget = TryCast(annotations(0), PdfTextAnnotationWidget)
				content.AppendLine("Annotation text: " & textAnnotation.Text)
				content.AppendLine("Annotation ModifiedDate: " & textAnnotation.ModifiedDate.ToString())
				content.AppendLine("Annotation author: " & textAnnotation.Author)
				content.AppendLine("Annotation Name: " & textAnnotation.Name)
			End If


			Dim result As String = "GetParticularAnnotationInfo_out.txt"


			'Save to file.
			File.WriteAllText(result, content.ToString())

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
