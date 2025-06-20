Imports Spire.Pdf

Namespace CheckPasswordProtection
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Check if the PDF file at the specified path is password protected
			Dim isProtected As Boolean = PdfDocument.IsPasswordProtected("..\..\..\..\..\..\Data\CheckPasswordProtection.pdf")

			' Show a message box indicating whether the PDF is password protected or not
			MessageBox.Show("The PDF is " & (If(isProtected, "password ", "not password ")) & "protected!")
		End Sub
	End Class
End Namespace
