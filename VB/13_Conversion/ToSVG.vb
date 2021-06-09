Imports Spire.Pdf

Namespace ToSVG
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim file As String = "..\..\..\..\..\..\Data\ToSVG.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			'Convert to svg file
			doc.SaveToFile("ToSVG-result.svg", FileFormat.SVG)
			doc.Close()
			PDFDocumentViewer("ToSVG-result.svg")
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
