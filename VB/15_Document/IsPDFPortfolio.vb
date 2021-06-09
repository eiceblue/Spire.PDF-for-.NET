Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text

Namespace IsPDFPortfolio
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load from file
			doc.LoadFromFile("..\..\..\..\..\..\Data\TextBoxSampleB_1.pdf")

			'Judge whether the document is portfolio or not.
			Dim value As Boolean = doc.IsPortfolio
			If value Then
				MessageBox.Show("The document is portfolio")
			Else
				MessageBox.Show("The document is not portfolio")
			End If
		End Sub
	End Class
End Namespace
