Imports Spire.Pdf
Imports Spire.Pdf.Conversion
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace ToXlsxSpecialTableLayoutOptions
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the PDF document to be converted
			Dim filePath As String = "../../../../../../Data/toXlsxOptions.pdf"

			' Create a new PdfDocument object to work with PDF files
			Dim document As New PdfDocument()

			' Load the PDF document from the specified file path
			document.LoadFromFile(filePath)

			' Create a new XlsxSpecialTableLayoutOptions object with specified layout options
			Dim options As New XlsxSpecialTableLayoutOptions(False, False, False)

			' Set the XlsxSpecialTableLayoutOptions as the conversion options for PDF to XLSX conversion
			document.ConvertOptions.SetPdfToXlsxOptions(options)

			' Save the converted document as an XLSX file with the name "Result.xlsx"
			document.SaveToFile("Result.xlsx", FileFormat.XLSX)

			' Dispose of system resources associated with the PdfDocument object
			document.Dispose()
		End Sub
	End Class
End Namespace
