Imports Spire.Pdf

Namespace EmbedSVG
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path
			Dim file As String = "..\..\..\..\..\..\..\Data\SampleB_1.pdf"

			' Open the PDF document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			' Set the "useEmbeddedSvg" boolean flag to true to convert to HTML with embedding SVG
			doc.ConvertOptions.SetPdfToHtmlOptions(True)

			' Specify the output file name for the converted HTML
			Dim result As String = "ToHTMLWithEmbeddingSVG_out.html"

			' Convert the document to an HTML file
			doc.SaveToFile(result, FileFormat.HTML)

			' Close the PDF document
			doc.Close()

			' Launch result file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
