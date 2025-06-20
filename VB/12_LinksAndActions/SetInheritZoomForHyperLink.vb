Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.General


Namespace SetInheritZoomForHyperLink
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Declare and initialize the input file path
			Dim inputFile As String = "..\..\..\..\..\..\Data\SetInheritZoomForHyperLink.pdf"

			' Specify the output file path
			Dim outputFile As String = "output.pdf"

			' Create a new instance of PdfDocument
			Dim pdf As New PdfDocument()

			' Load the PDF document from the input file
			pdf.LoadFromFile(inputFile)

			' Get the collection of annotations for the first page of the PDF
            Dim annotations As PdfAnnotationCollection = pdf.Pages(0).Annotations

			' Iterate through each annotation in the collection
			For i As Integer = 0 To annotations.Count - 1

				' Convert the annotation to a PdfDocumentLinkAnnotationWidget
				Dim anno As PdfDocumentLinkAnnotationWidget = TryCast(annotations(i), PdfDocumentLinkAnnotationWidget)

				' Get the destination of the annotation
				Dim dest As PdfDestination = anno.Destination

				' Set the destination mode to Location
				dest.Mode = PdfDestinationMode.Location

				' Set the zoom level to 0 (inherit zoom)
				dest.Zoom = 0

				' Update the annotation's destination with the modified values
				anno.Destination = dest

			Next i

			' Save the modified PDF document to the output file
			pdf.SaveToFile(outputFile, FileFormat.PDF)

			' Close the PDF document
			pdf.Close()

			' Launch the Pdf file
			PDFDocumentViewer(outputFile)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
