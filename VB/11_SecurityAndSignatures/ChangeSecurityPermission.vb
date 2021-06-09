Imports Spire.Pdf
Imports Spire.Pdf.Security
Imports System.ComponentModel
Imports System.Text

Namespace ChangeSecurityPermission
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create and load a pdf document
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\ChangeSecurityPermission.pdf")

			'Set an owner password, enable the permissions of Printing and Copying, set encryption level
			pdf.Security.Encrypt("", "test  ", PdfPermissionsFlags.FillFields Or PdfPermissionsFlags.FullQualityPrint,PdfEncryptionKeySize.Key256Bit)

			'Save and launch
			pdf.SaveToFile("SecurityPermission.pdf")
			Process.Start("SecurityPermission.pdf")

		End Sub
	End Class
End Namespace
