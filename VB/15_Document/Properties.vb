Imports Spire.Pdf

Namespace Properties
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\Properties.pdf")

			' Set the author information of the document
			doc.DocumentInformation.Author = "E-iceblue"

			' Set the creator information of the document
			doc.DocumentInformation.Creator = "E-iceblue"

			' Set the keywords associated with the document
			doc.DocumentInformation.Keywords = "pdf, demo, document information"

			' Set the producer information of the document
			doc.DocumentInformation.Producer = "Spire.Pdf"

			' Set the subject of the document
			doc.DocumentInformation.Subject = "Demo of Spire.Pdf"

			' Set the title of the document
			doc.DocumentInformation.Title = "Document Information"

			' Set the cross-reference type of the document to CrossReferenceStream
			doc.FileInfo.CrossReferenceType = PdfCrossReferenceType.CrossReferenceStream

			' Disable incremental updates for the document
			doc.FileInfo.IncrementalUpdate = False

			' Save the modified document to a file named "Properties_result.pdf"
			doc.SaveToFile("Properties_result.pdf")

			' Close the PDF document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("Properties_result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
