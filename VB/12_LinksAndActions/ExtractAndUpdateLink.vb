Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace ExtractAndUpdateLink
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument
			Dim doc As New PdfDocument()

			' Load an existing PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\LinkAnnotation.pdf")

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Get the collection of annotations on the page
            Dim annotations As PdfAnnotationCollection = page.Annotations

			' Check if there are any annotations
			If annotations.Count > 0 Then
				' Traverse through the PdfAnnotationCollection
				For Each pdfAnnotation As PdfAnnotation In annotations
					' Check if it is a PdfTextWebLinkAnnotationWidget
					If TypeOf pdfAnnotation Is PdfTextWebLinkAnnotationWidget Then

						' Get the link annotation
						Dim annotation As PdfTextWebLinkAnnotationWidget = TryCast(pdfAnnotation, PdfTextWebLinkAnnotationWidget)

						' Change the URL of the link
						annotation.Url = "http://www.e-iceblue.com/Introduce/pdf-for-net-introduce.html"

					End If
				Next pdfAnnotation
			End If

			' Specify the output file path
			Dim result As String = "ExtractAndUpdateLink_out.pdf"

			' Save the modified document to the output file
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace





