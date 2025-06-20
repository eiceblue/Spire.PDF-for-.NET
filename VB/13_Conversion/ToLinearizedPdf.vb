Imports Spire.Pdf.Conversion

Namespace ToLinearizedPdf
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the input PDF file
			Dim input As String = "../../../../../../Data/PDFTemplate_N.pdf"

			' Specify the file path for the resulting linearized PDF file
			Dim result As String = "toLinearizedPdf.pdf"

			' Create a new instance of PdfToLinearizedPdfConverter
			Dim converter As New PdfToLinearizedPdfConverter(input)

			' Convert the input PDF to a linearized PDF and save it
			converter.ToLinearizedPdf(result)

			' Dispose the convertor
			converter.Dispose()

			' Launch the Pdf file
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
