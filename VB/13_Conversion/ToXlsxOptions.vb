Imports Spire.Pdf
Imports Spire.Pdf.Conversion

Namespace ToXlsxOptions
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument
			Dim document As New PdfDocument()

			' Load the PDF document from the specified file path
			document.LoadFromFile("../../../../../../Data/ToXlsxOptions.pdf")

			' Specify the options for converting PDF to Excel
			' These four parameters represent: convertToMultipleSheet, showRotatedText, splitCell, wrapText
			Dim options As New XlsxLineLayoutOptions(False, False, False, False)

			' Set the PDF to Excel conversion options
			document.ConvertOptions.SetPdfToXlsxOptions(options)

			' Specify the output file path for the Excel file
			Dim output As String = "ToXlsxOptions.xlsx"

			' Save the document as an Excel file
			document.SaveToFile(output, FileFormat.XLSX)

			' Close the PDF document
			document.Close()

			' Launch the Pdf file
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
