Imports Spire.Pdf

Namespace Encryption
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Load a PDF document
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\Encryption.pdf")

			' Specify the open password and permission password for the encryption
			Dim openPassword As String = "e-iceblue"
			Dim permissionPassword As String = "test"

			' Create a new PdfPasswordSecurityPolicy object with the specified passwords
			Dim policy As New PdfPasswordSecurityPolicy(openPassword, permissionPassword)

			' Set the encryption algorithm to AES-256
			policy.EncryptionAlgorithm = PdfEncryptionAlgorithm.AES_128

			' Allow printing and filling form fields in the document
			policy.DocumentPrivilege.AllowPrint = True
			policy.DocumentPrivilege.AllowFillFormFields = True

			' Encrypt the PDF document using the specified security policy
			doc.Encrypt(policy)

			' Save the encrypted PDF document to a file
			doc.SaveToFile("Encryption-result.pdf")

			' Close the document
			doc.Close()

			' Launch the file
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
