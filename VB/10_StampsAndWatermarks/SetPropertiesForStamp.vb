Imports Spire.Pdf
Imports Spire.Pdf.Annotations

Namespace SetPropertiesForStamp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load old PDF from disk.
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\TextStamp.pdf")

			'Get the first page
			Dim page As PdfPageBase = pdf.Pages(0)

			'Traverse annotations widget
			For Each annotation As PdfAnnotation In page.AnnotationsWidget.List
				'If it is PdfRubberStampAnnotationWidget
				If TypeOf annotation Is PdfRubberStampAnnotationWidget Then
					Dim stamp As PdfRubberStampAnnotationWidget = TryCast(annotation, PdfRubberStampAnnotationWidget)
					stamp.Author = "TestUser"
					stamp.Subject = "E-iceblue"
					stamp.CreationDate = Date.Now
					stamp.ModifiedDate = Date.Now
				End If
			Next annotation
			'Save to a pdf file
			Dim result As String = "SetPropertiesForStamp.pdf"
			pdf.SaveToFile(result, Spire.Pdf.FileFormat.PDF)

			'Launch the file
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
