Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Namespace ModifyFormFieldValue
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file path
			Dim input As String = "..\..\..\..\..\..\Data\FormField.pdf"
			'Open pdf document
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(input)

			Dim form As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)
			For i As Integer = 0 To form.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(form.FieldsWidget.List(i), PdfField)
				If TypeOf field Is PdfTextBoxFieldWidget Then
					Dim textbox As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)

					'Find the textbox named total
					If textbox.Name = "TextBox1" Then
						textbox.Text = "New value"
					End If
				End If
			Next i

			Dim result As String = "ModifyFormFieldValue_out.pdf"

			'Save the document
			pdf.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
