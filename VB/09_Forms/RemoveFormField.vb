Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Namespace RemoveFormField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Input and output file paths
			Dim input As String = "..\..\..\..\..\..\Data\RemoveFormField.pdf"
			Dim output As String = "RemoveFormField_result.pdf"
			'Create a PdfDocument
			Dim pdf As New PdfDocument()
			'Load the input file from disk
			pdf.LoadFromFile(input)
			'Get form from the document
			Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)
			If formWidget IsNot Nothing Then
				For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
					'Case 1: Remove the first form field
					If i = 0 Then
						Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)
						formWidget.FieldsWidget.Remove(field)
						Exit For
					End If
				Next i
				'Case 2: Remove all form fields
				'formWidget.FieldsWidget.Clear();

				'Save the pdf file
				pdf.SaveToFile(output)
			End If
			'Launch the Pdf files
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
