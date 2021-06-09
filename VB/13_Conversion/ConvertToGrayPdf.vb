Imports Spire.Pdf.Conversion

Namespace ConvertToGrayPdf
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Output file path
			Dim output As String = "ConvertToGrayPdf-result.pdf"
			'Create a PdfGrayConverter with an pdf file
			Dim converter As New PdfGrayConverter("..\..\..\..\..\..\Data\ConvertToGrayPdf.pdf")
			'Convert the file to gray pdf
			converter.ToGrayPdf(output)
			'Launch the Pdf file
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
