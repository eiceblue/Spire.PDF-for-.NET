Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace GetLinkAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load file from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\LinkAnnotation.pdf")

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Get the annotation collection
			Dim annotations As PdfAnnotationCollection = page.AnnotationsWidget

			'Create StringBuilder to save 
			Dim content As New StringBuilder()

			'Verify whether widgetCollection is not null or not
			If annotations.Count > 0 Then
				'traverse the PdfAnnotationCollection
				For Each pdfAnnotation As PdfAnnotation In annotations
					'if it is PdfTextWebLinkAnnotationWidget
					If TypeOf pdfAnnotation Is PdfTextWebLinkAnnotationWidget Then

						'Get the Url
						Dim WebLinkAnnotation As PdfTextWebLinkAnnotationWidget = TryCast(pdfAnnotation, PdfTextWebLinkAnnotationWidget)
						Dim url As String = WebLinkAnnotation.Url

						'Add strings to StringBuilder
						content.AppendLine("The url of link annotation is " & url)
						content.AppendLine("The text of link annotation is " & WebLinkAnnotation.Text)
					End If
				Next pdfAnnotation
			End If

			Dim result As String = "GetLinkAnnotation_out.txt"

			'Save them to a txt file
			File.WriteAllText(result, content.ToString())

			'Launch the file
			DocumentViewer(result)
		End Sub
		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace