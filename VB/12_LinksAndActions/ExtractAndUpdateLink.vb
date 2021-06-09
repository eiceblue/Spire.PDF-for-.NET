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
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load file from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\LinkAnnotation.pdf")

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Get the annotation collection
			Dim annotations As PdfAnnotationCollection = page.AnnotationsWidget

			'Verify whether widgetCollection is not null or not
			If annotations.Count > 0 Then
				'traverse the PdfAnnotationCollection
				For Each pdfAnnotation As PdfAnnotation In annotations
					'if it is PdfTextWebLinkAnnotationWidget
					If TypeOf pdfAnnotation Is PdfTextWebLinkAnnotationWidget Then

						'Get the link annotation
						Dim annotation As PdfTextWebLinkAnnotationWidget = TryCast(pdfAnnotation, PdfTextWebLinkAnnotationWidget)

						'Change the url
						annotation.Url = "http://www.e-iceblue.com/Introduce/pdf-for-net-introduce.html"

					End If
				Next pdfAnnotation
			End If
			Dim result As String = "ExtractAndUpdateLink_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
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





