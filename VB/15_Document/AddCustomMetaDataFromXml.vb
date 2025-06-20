Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Interchange.Metadata

Namespace AddCustomMetaDataFromXml
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object and load the PDF file from the specified path
			Dim doc As New PdfDocument("..\..\..\..\..\..\Data\Template_Pdf_4.pdf")

			' Open a file stream to read the XML metadata file
			Dim stream As Stream = New FileStream("..\..\..\..\..\..\Data\MetaData.xml", FileMode.Open)

			' Parse the XML metadata using PdfXmpMetadata.Parse() method and assign it to the document's Metadata property
			doc.Metadata = PdfXmpMetadata.Parse(stream)

			' Specify the path for the resulting PDF file
			Dim resultPath As String = "CustomMetaFromXml_result.pdf"

			' Save the modified document to the specified path
			doc.SaveToFile(resultPath)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(resultPath)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
