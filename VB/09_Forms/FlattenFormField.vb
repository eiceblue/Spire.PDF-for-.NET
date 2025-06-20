Imports Spire.Pdf

Namespace FlattenFormField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Define the input file path
			Dim input As String = "..\..\..\..\..\..\Data\FlattenFormField.pdf"

			'Create a new PdfDocument object
			Dim doc As New PdfDocument()

			'Load the PDF document from the specified input file
			doc.LoadFromFile(input)

			'Set the IsFlatten property of the form to True, which flattens all form fields
			doc.Form.IsFlatten = True

			'Define the output file path
			Dim output As String = "FlattenFormField.pdf"

			'Save the modified PDF document to the specified output file
			doc.SaveToFile(output)

			' Close the document
			doc.Close()

			' Launch the pdf file
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
