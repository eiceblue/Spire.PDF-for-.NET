Imports Spire.Pdf

Namespace ChangeSecurityPermission
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim pdf As New PdfDocument()

			' Load a PDF file from a specified path
			pdf.LoadFromFile("..\..\..\..\..\..\Data\ChangeSecurityPermission.pdf")

			' Create a new PdfPasswordSecurityPolicy object with permission password "test"
			Dim policy As New PdfPasswordSecurityPolicy("", "test")

			' Set the encryption algorithm to AES-256
			policy.EncryptionAlgorithm = PdfEncryptionAlgorithm.AES_256

			' Allow printing and filling form fields in the document
			policy.DocumentPrivilege.AllowPrint = True
			policy.DocumentPrivilege.AllowFillFormFields = True

			' Encrypt the PDF document using the specified security policy
			pdf.Encrypt(policy)

			' Save the modified PDF document to a file named "SecurityPermission.pdf"
			pdf.SaveToFile("SecurityPermission.pdf")

			' Close the PdfDocument object
			pdf.Close()

			' Launch the file
			Process.Start("SecurityPermission.pdf")

		End Sub
	End Class
End Namespace
