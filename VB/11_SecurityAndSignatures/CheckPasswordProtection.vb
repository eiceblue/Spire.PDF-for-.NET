Imports Spire.Pdf

Namespace CheckPasswordProtection
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Check whether the input pdf document is password protected.
			Dim isProtected As Boolean =PdfDocument.IsPasswordProtected("..\..\..\..\..\..\Data\CheckPasswordProtection.pdf")
			'Show the result by message box
			MessageBox.Show("The pdf is " & (If(isProtected, "password ", "not password ")) & "protected!")
		End Sub
	End Class
End Namespace
