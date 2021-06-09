Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security


Namespace Decryption
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a pdf document
			Dim encryptedPdf As String = "..\..\..\..\..\..\Data\Decryption.pdf"
			Dim doc As New PdfDocument()

			'Open the document
			doc.LoadFromFile(encryptedPdf, "test")

			'Decrypt the document
			doc.Security.Encrypt("", "", PdfPermissionsFlags.Default, PdfEncryptionKeySize.Key256Bit, "test")

			'Save Pdf file
			doc.SaveToFile("Decryption.pdf", FileFormat.PDF)

			DocumentViewer("Decryption.pdf")
		End Sub

		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
