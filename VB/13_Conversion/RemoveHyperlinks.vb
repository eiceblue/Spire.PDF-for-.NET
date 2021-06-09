Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System.ComponentModel
Imports System.Text

Namespace RemoveHyperlinks
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load an existing PDF file
			Dim document As New PdfDocument()
			document.LoadFromFile("..\..\..\..\..\..\Data\RemoveHyperlinks.pdf")

			'Get the first page
			Dim page As PdfPageBase = document.Pages(0)

			'Get the annotation collection
			Dim widgetCollection As PdfAnnotationCollection = page.AnnotationsWidget

			'Verify whether widgetCollection is null or not
			If widgetCollection.Count > 0 Then
				For i As Integer = widgetCollection.Count - 1 To 0 Step -1
					Dim annotation As PdfAnnotation = widgetCollection(i)
					'Get the TextWebLink Annotation
					If TypeOf annotation Is PdfTextWebLinkAnnotationWidget Then
						Dim link As PdfTextWebLinkAnnotationWidget = TryCast(annotation, PdfTextWebLinkAnnotationWidget)
						'Remove the TextWebLink annotation
						widgetCollection.Remove(link)
					End If
				Next i
			End If

			Dim output As String = "RemoveHyperlinks-result.pdf"

			document.SaveToFile(output)

			'Launch the Pdf file
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
