Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace DetermineCorrectPassword
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim filePath As String="../../../../../../Data/Decryption.pdf"
			Dim passwords() As String = { "password1", "password2", "password3", "test", "sample" }
			For passwordcount As Integer = 0 To passwords.Length - 1
				Try
					Dim doc As New PdfDocument()
					doc.LoadFromFile(filePath, passwords(passwordcount))

					MessageBox.Show("Password = " & passwords(passwordcount) & "  is correct")
				Catch ex As Exception
					MessageBox.Show("Password = " & passwords(passwordcount) & "  is not correct")
				End Try
			Next passwordcount
		End Sub
	End Class
End Namespace
