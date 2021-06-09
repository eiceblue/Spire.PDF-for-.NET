Imports Spire.Pdf

Namespace ToXLSX
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim result As String = "ToXLSX.xlsx"
			'Create a pdf document
			Using doc As New PdfDocument()
				doc.LoadFromFile("..\..\..\..\..\..\Data\ChartSample.pdf")

				'Save to XLSX
				doc.SaveToFile(result, FileFormat.XLSX)

			End Using
			'Launch the result file
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
