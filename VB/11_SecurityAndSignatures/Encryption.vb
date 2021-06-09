Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security

Namespace Encryption
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a pdf document.
			Dim doc As New PdfDocument()
		doc.LoadFromFile("..\..\..\..\..\..\Data\Encryption.pdf")
			'Encrypt
			Dim keySize As PdfEncryptionKeySize = PdfEncryptionKeySize.Key128Bit
			Dim openPassword As String = "e-iceblue"
			Dim permissionPassword As String = "test"
			Dim flags As PdfPermissionsFlags = PdfPermissionsFlags.Print Or PdfPermissionsFlags.FillFields
			doc.Security.Encrypt(openPassword, permissionPassword, flags, keySize)

			'Save pdf file.
			doc.SaveToFile("Encryption-result.pdf")
			doc.Close()

			'Launch the file.
			PDFDocumentViewer("Encryption-result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
