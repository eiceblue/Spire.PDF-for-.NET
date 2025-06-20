Imports Spire.Pdf.Conversion
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Namespace ToMarkdownIgnoreImage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the path of the input OFD file
			Dim inputFile As String = "..\..\..\..\..\..\Data\SampleB_1.pdf"

			' Create an instance of the PdfToMarkdownConverter
			Dim converter As New PdfToMarkdownConverter(inputFile)

			' Set the option to ignore images 
			converter.MarkdownOptions.IgnoreImage = True

			' Define the output file name for the converted Markdown
			Dim outputFile As String = "ToMarkdownIgnoreImage.md"

			' Convert the PDF to Markdown
			converter.ConvertToMarkdown(outputFile)

			' Launch the result file
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
