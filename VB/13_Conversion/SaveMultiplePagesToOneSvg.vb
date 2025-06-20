Imports Spire.Pdf

Namespace SaveMultiplePagesToOneSvg
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim pdfDocument As New PdfDocument()

			' Load an existing PDF document from the specified file path
			pdfDocument.LoadFromFile("..\..\..\..\..\..\Data\GetPageInfo.pdf")

			' Set the conversion options to output as a single SVG file
			pdfDocument.ConvertOptions.OutputToOneSvg = True

			' Specify the file path for the resulting SVG file
			Dim result As String = "output.svg"

			' Save the PDF document
			pdfDocument.SaveToFile(result, FileFormat.SVG)

			' Close the PDF document
			pdfDocument.Close()

			' Launch the Svg file
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
