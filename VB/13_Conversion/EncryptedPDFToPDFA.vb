Imports Spire.Pdf.Conversion

Namespace EncryptedPDFToPDFA
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of the PdfStandardsConverter class and specify the input PDF file path and password
			Dim converter As New PdfStandardsConverter("..\..\..\..\..\..\Data\Decryption.pdf", "test")

			' Convert the PDF to PDF/A-2A standard and save it as "EncryptedPDFToPDFA.pdf"
			converter.ToPdfA2A("EncryptedPDFToPDFA.pdf")

			' Dispose the convertor
			converter.Dispose()

			' Launch the result file.
			PDFDocumentViewer("EncryptedPDFToPDFA.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
