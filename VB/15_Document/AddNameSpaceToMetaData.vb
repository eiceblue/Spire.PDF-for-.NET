Imports Spire.Pdf
Imports Spire.Pdf.Interchange.Metadata

Namespace AddNameSpaceToMetaData
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of the PdfDocument class
			Dim pdfDocument As New PdfDocument()

			' Load an existing PDF document from a specified file path
			pdfDocument.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_4.pdf")

			' Register a custom XMP namespace with a specific URI and prefix
			PdfXmpNamespace.RegisterNamespace("http://myRandomNamespace", "zf")

			' Set a string property in the metadata of the PDF document using the registered namespace
			pdfDocument.Metadata.SetPropertyString("http://myRandomNamespace", "test1", "my test")

			' Reset all registered XMP namespaces
			PdfXmpNamespace.ResetNamespaces()

			' Specify the file path for the resulting PDF document after adding the namespace to metadata
			Dim result_path As String = "AddNameSpaceToMetaData.pdf"

			' Save the modified PDF document to the specified file path
			pdfDocument.SaveToFile(result_path)

			' Close the PdfDocument
			pdfDocument.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result_path)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
