Imports Spire.Pdf

Namespace PdfToExcel
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles label1.Click, button1.Click, pictureBox1.Click
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\PdfToExcel.pdf")

			Dim result As String = "PdfToExcel_result.xlsx"
			'Save the pdf file to excel 
			pdf.SaveToFile(result, FileFormat.XLSX)
			'View the excel document
			FileViewer(result)
		End Sub

		Private Sub FileViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
