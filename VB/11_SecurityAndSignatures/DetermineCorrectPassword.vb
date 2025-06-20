Imports Spire.Pdf

Namespace DetermineCorrectPassword
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Define the file path of the PDF file to be decrypted
            Dim filePath As String = "../../../../../../Data/Decryption.pdf"

            ' Define an array of passwords to try for decryption
            Dim passwords() As String = {"password1", "password2", "password3", "test", "sample"}

            ' Iterate through each password in the array
            For passwordcount As Integer = 0 To passwords.Length - 1

                ' Try to load the PDF document using the current password
                Try
                    Dim doc As New PdfDocument()
                    doc.LoadFromFile(filePath, passwords(passwordcount))

                    ' Display a message indicating that the current password is correct
                    MessageBox.Show("Password = " & passwords(passwordcount) & " is correct")

                    ' Close the PDF document
                    doc.Close()
                Catch ex As Exception
                    ' Display a message indicating that the current password is not correct
                    MessageBox.Show("Password = " & passwords(passwordcount) & " is not correct")
                End Try

            Next passwordcount
        End Sub
	End Class
End Namespace
