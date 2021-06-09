Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text

Namespace FlattenFormField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file path
			Dim input As String = "..\..\..\..\..\..\Data\FlattenFormField.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
		doc.LoadFromFile(input)
			'Flatten form fields
			doc.Form.IsFlatten = True

			Dim output As String = "FlattenFormField.pdf"

			'Save pdf document
			doc.SaveToFile(output)

			'Launch the pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
