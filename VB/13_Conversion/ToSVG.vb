Imports Spire.Pdf

Namespace ToSVG
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the PDF document to be loaded
			Dim file As String = "..\..\..\..\..\..\Data\ToSVG.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile(file)

			' Convert the PDF document to an SVG file format
			doc.SaveToFile("ToSVG-result.svg", FileFormat.SVG)

			' Close the PDF document
			doc.Close()

			' Launch the file
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
