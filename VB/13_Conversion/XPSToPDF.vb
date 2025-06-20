Imports Spire.Pdf

Namespace XPSToPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the XPS file to be loaded
			Dim file As String = "..\..\..\..\..\..\Data\XPStoPDF.xps"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the XPS document from the specified file path
			doc.LoadFromXPS(file)

			' Convert the XPS document to PDF file format
			doc.SaveToFile("XPStoPDF-result.pdf")

			' Close the PDF document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("XPStoPDF-result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
