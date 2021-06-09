Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Annotations
Imports System.Text
Imports System.IO

Namespace ExtractHighlightedText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load a pdf file
			doc.LoadFromFile("..\..\..\..\..\..\Data\ExtractHighlightedText.pdf")

			Dim page As PdfPageBase = doc.Pages(0)
			Dim textMarkupAnnotation As PdfTextMarkupAnnotationWidget
			Dim stringBuilder As New StringBuilder()
			stringBuilder.AppendLine("Extracted hightlighted text:")
			'Get PdfTextMarkupAnnotationWidget objects
			For i As Integer = 0 To page.AnnotationsWidget.Count - 1
				If TypeOf page.AnnotationsWidget(i) Is PdfTextMarkupAnnotationWidget Then
					textMarkupAnnotation = TryCast(page.AnnotationsWidget(i), PdfTextMarkupAnnotationWidget)
					'Get the highlighted text
					stringBuilder.AppendLine(page.ExtractText(textMarkupAnnotation.Bounds))

					'Get the highlighted color
					Dim color As Color = textMarkupAnnotation.TextMarkupColor
				End If
			Next i
			Dim result As String="ExtractHighlightedText.txt"
			File.WriteAllText(result, stringBuilder.ToString())
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
