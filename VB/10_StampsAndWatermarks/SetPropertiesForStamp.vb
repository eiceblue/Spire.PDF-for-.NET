Imports Spire.Pdf
Imports Spire.Pdf.Annotations

Namespace SetPropertiesForStamp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument
			Dim pdf As New PdfDocument()

			' Load the PDF file from a specified path
			pdf.LoadFromFile("..\..\..\..\..\..\Data\TextStamp.pdf")

			' Get the first page of the PDF document
			Dim page As PdfPageBase = pdf.Pages(0)

			' Iterate through each annotation in the page's annotation list
			For Each annotation As PdfAnnotation In page.AnnotationsWidget.List

				' Check if the annotation is a rubber stamp annotation
				If TypeOf annotation Is PdfRubberStampAnnotationWidget Then

					' Convert the annotation to a PdfRubberStampAnnotationWidget object
					Dim stamp As PdfRubberStampAnnotationWidget = TryCast(annotation, PdfRubberStampAnnotationWidget)

					' Set the author, subject, creation date, and modified date properties of the rubber stamp annotation
					stamp.Author = "TestUser"
					stamp.Subject = "E-iceblue"
					stamp.CreationDate = Date.Now
					stamp.ModifiedDate = Date.Now
				End If
			Next annotation

			' Specify the output file name for the modified PDF document
			Dim result As String = "SetPropertiesForStamp.pdf"

			' Save the modified PDF document to the specified output file using Spire.Pdf library
			pdf.SaveToFile(result, Spire.Pdf.FileFormat.PDF)

			' Close the PDF document
			pdf.Close()

			' Launch the file
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
