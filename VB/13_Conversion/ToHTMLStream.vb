Imports Spire.Pdf
Imports System.IO

Namespace ToHTMLStream
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim pdf As New PdfDocument()

			' Load the PDF file from the specified path
			pdf.LoadFromFile("..\..\..\..\..\..\..\Data\SampleB_1.pdf")

			' Create a new MemoryStream object
			Dim ms As New MemoryStream()

			' Save the PDF document to HTML format and write it to the MemoryStream object
			pdf.SaveToStream(ms, FileFormat.HTML)
			
			' Write the content of the memory stream to an HTML file
			File.WriteAllBytes("ToHtml.html",ms.ToArray())

			' Close the PDF document
			pdf.Close()
			
			PDFDocumentViewer("ToHtml.html")
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
