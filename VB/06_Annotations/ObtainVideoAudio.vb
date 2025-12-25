Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Texts

Namespace ObtainVideoAudio
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a PDF document
			Dim pdf As New PdfDocument()

			' Load the PDF file from disk
			pdf.LoadFromFile("..\..\..\..\..\..\Data\ObtainVideoAudio.pdf")

			' Loop through each page in the PDF document
			For i As Integer = 0 To pdf.Pages.Count - 1
				' Get the current page
				Dim page As PdfPageBase = pdf.Pages(i)

				' Get all annotations on the current page
				Dim annotations As PdfAnnotationCollection = page.Annotations

				' Loop through each annotation on the page
				For j As Integer = 0 To annotations.Count - 1
					' Cast the annotation to a rich media annotation widget
					Dim MediaWidget As PdfRichMediaAnnotationWidget = CType(annotations(j), PdfRichMediaAnnotationWidget)

					' Get the embedded media data (e.g., video, audio)
					Dim data() As Byte = MediaWidget.RichMediaData

					' Get the original file name of the embedded media
					Dim embedFileName As String = MediaWidget.RichMediaName

					' Save the embedded media data to a file
					File.WriteAllBytes(embedFileName, data)
				Next j
			Next i

			' Close the PDF document
			pdf.Close()
		End Sub
	End Class
End Namespace
