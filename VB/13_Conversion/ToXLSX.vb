Imports Spire.Pdf

Namespace ToXLSX
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path for the resulting XLSX file
			Dim result As String = "ToXLSX.xlsx"

			' Create a new instance of PdfDocument
			' Load the PDF document from the specified file path
			Using doc As New PdfDocument()
				doc.LoadFromFile("..\..\..\..\..\..\Data\ChartSample.pdf")

				' Save the PDF document to XLSX format
				doc.SaveToFile(result, FileFormat.XLSX)
			End Using

			' Launch the result file
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
