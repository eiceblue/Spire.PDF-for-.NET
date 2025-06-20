Imports Spire.Pdf

Namespace PDFToMarkdown

	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRun.Click
			Dim file As String = "..\..\..\..\..\..\Data\ToTiff.pdf"
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			Dim output As String = "ToMarkdown.md"
			' Convert the loaded PDF document to a Markdown file.
			doc.SaveToFile(output, FileFormat.Markdown)

			' Close the PDF document.
			doc.Close()

			'Launch the file
			DocumentViewer(output)
		End Sub
		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

		Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
			Close()
		End Sub

	End Class
End Namespace
