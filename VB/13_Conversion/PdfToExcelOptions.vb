Imports Spire.Pdf

Namespace PdfToExcelOptions
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles label1.Click, button1.Click, pictureBox1.Click
			Dim pdf As New PdfDocument()
			Dim PDFFile As String = "..\..\..\..\..\..\Data\PdfToXlsxOptions.pdf"
			pdf.LoadFromFile(PDFFile)

			pdf.ConvertOptions.SetPdfToXlsxOptions(PdfToXlsxLayout.Line)
			Dim ExcelFile As String = "PdfToXlsxOptions_results.xlsx"
			'Save the pdf file to excel
			pdf.SaveToFile(ExcelFile, FileFormat.XLSX)
			'View the excel document
			FileViewer(ExcelFile)
		End Sub

		Private Sub FileViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub
	End Class
End Namespace
