Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text

Namespace EmbedSVG
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
            Dim file As String = "..\..\..\..\..\..\..\Data\SampleB_1.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			'Set the bool useEmbeddedSvg as true to convert to HTML with embeding SVG
			doc.ConvertOptions.SetPdfToHtmlOptions(True)


			Dim result As String = "ToHTMLWithEmbedingSVG_out.html"

			'Convert to html file
			doc.SaveToFile(result, FileFormat.HTML)
			doc.Close()

			'Launch result file
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
