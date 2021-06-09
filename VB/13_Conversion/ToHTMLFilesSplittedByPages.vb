Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text


Namespace ToHTMLFilesSplittedByPages
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim file As String = "..\..\..\..\..\..\..\Data\SampleB_3.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			'Split to HTML file according to pages, here one page will convert to a HTML file.
			doc.ConvertOptions.SetPdfToHtmlOptions(False, True, 1)

			Dim output As String = "ToHTMLFilesSplittedByPages_out.html"

			'Convert to html file
			doc.SaveToFile(output, FileFormat.HTML)
			doc.Close()

			'Launch result file
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
