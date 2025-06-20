Imports Spire.Pdf

Namespace SetXMPMetadata
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Load the input PDF file
			Dim input As String = "..\..\..\..\..\..\Data\SetXMPMetadata.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the input file
			doc.LoadFromFile(input)

			' Set the author information in the document properties
			doc.DocumentInformation.Author = "E-iceblue"

			' Set the creator information in the document properties
			doc.DocumentInformation.Creator = "Spire.PDF"

			' Set the keywords information in the document properties
			doc.DocumentInformation.Keywords = "XMP"

			' Set the producer information in the document properties
			doc.DocumentInformation.Producer = "E-icenlue Co,.Ltd"

			' Set the subject information in the document properties
			doc.DocumentInformation.Subject = "XMP Metadata"

			' Set the title information in the document properties
			doc.DocumentInformation.Title = "Set XMP Metadata in PDF"

			' Specify the output file name
			Dim output As String = "SetXMPMetadata.pdf"

			' Save the modified document to the output file
			doc.SaveToFile(output)

			' Close the PDF document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				System.Diagnostics.Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
