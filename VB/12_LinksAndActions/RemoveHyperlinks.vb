Imports Spire.Pdf
Imports Spire.Pdf.Annotations

Namespace RemoveHyperlinks
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim document As New PdfDocument()

			' Load a PDF file from a specified path
			document.LoadFromFile("..\..\..\..\..\..\Data\RemoveHyperlinks.pdf")

			' Get the first page of the document
			Dim page As PdfPageBase = document.Pages(0)

			' Get the collection of annotations (widgets) on the page
            Dim widgetCollection As PdfAnnotationCollection = page.Annotations

			' Check if there are any annotations in the collection
			If widgetCollection.Count > 0 Then
				' Iterate over the annotations in reverse order
				For i As Integer = widgetCollection.Count - 1 To 0 Step -1
					' Get the current annotation
					Dim annotation As PdfAnnotation = widgetCollection(i)

					' Check if the annotation is a TextWebLink annotation
					If TypeOf annotation Is PdfTextWebLinkAnnotationWidget Then
						' Cast the annotation to PdfTextWebLinkAnnotationWidget
						Dim link As PdfTextWebLinkAnnotationWidget = TryCast(annotation, PdfTextWebLinkAnnotationWidget)

						' Remove the TextWebLink annotation from the collection
						widgetCollection.Remove(link)
					End If
				Next i
			End If

			' Specify the output file name as "RemoveHyperlinks-result.pdf"
			Dim output As String = "RemoveHyperlinks-result.pdf"

			' Save the modified document to a PDF file
			document.SaveToFile(output)

			' Close the PDF document
			document.Close()

			' Launch the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
