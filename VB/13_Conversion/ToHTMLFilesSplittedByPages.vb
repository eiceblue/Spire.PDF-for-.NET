Imports Spire.Pdf

Namespace ToHTMLFilesSplittedByPages
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path
			Dim file As String = "..\..\..\..\..\..\..\Data\SampleB_3.pdf"

			' Load the PDF document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			' Split the document to HTML files according to pages
			' Here, each page will be converted to a separate HTML file
			doc.ConvertOptions.SetPdfToHtmlOptions(False, True, 1)

			' Specify the output file name for the splitted HTML files
			Dim output As String = "ToHTMLFilesSplittedByPages_out.html"

			' Convert the document to HTML files
			doc.SaveToFile(output, FileFormat.HTML)

			' Close the PDF document
			doc.Close()

			' Launch result file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
