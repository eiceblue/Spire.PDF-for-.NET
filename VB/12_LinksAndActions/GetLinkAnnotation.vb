Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System.IO
Imports System.Text

Namespace GetLinkAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load a PDF file into the document
			doc.LoadFromFile("..\..\..\..\..\..\Data\LinkAnnotation.pdf")

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Get the collection of annotations on the page
            Dim annotations As PdfAnnotationCollection = page.Annotations

			' Create a StringBuilder object to store the results
			Dim content As New StringBuilder()

			' Check if there are any annotations on the page
			If annotations.Count > 0 Then
				' Traverse the PdfAnnotationCollection
				For Each pdfAnnotation As PdfAnnotation In annotations
					' Check if the annotation is of type PdfTextWebLinkAnnotationWidget
					If TypeOf pdfAnnotation Is PdfTextWebLinkAnnotationWidget Then

						' Get the URL from the WebLinkAnnotation
						Dim WebLinkAnnotation As PdfTextWebLinkAnnotationWidget = TryCast(pdfAnnotation, PdfTextWebLinkAnnotationWidget)
						Dim url As String = WebLinkAnnotation.Url

						' Add information about the URL and text to the StringBuilder
						content.AppendLine("The URL of the link annotation is " & url)
						content.AppendLine("The text of the link annotation is " & WebLinkAnnotation.Text)
					End If
				Next pdfAnnotation
			End If

			' Specify the output file name
			Dim result As String = "GetLinkAnnotation_out.txt"

			' Write the content of the StringBuilder to a text file
			File.WriteAllText(result, content.ToString())

			' Close the PDF document
			doc.Close()

			' Launch the file
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