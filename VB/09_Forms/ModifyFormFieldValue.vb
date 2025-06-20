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
			' Specify the input file path
			Dim input As String = "..\..\..\..\..\..\Data\FormField.pdf"

			' Create a new instance of PdfDocument
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(input)

			' Access the form widget of the PDF document
			Dim form As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

			' Iterate through each field in the form
			For i As Integer = 0 To form.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(form.FieldsWidget.List(i), PdfField)

				' Check if the field is a text box
				If TypeOf field Is PdfTextBoxFieldWidget Then
					Dim textbox As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)

					' Check if the text box has a specific name (e.g., "TextBox1")
					If textbox.Name = "TextBox1" Then
						' Modify the text value of the text box
						textbox.Text = "New value"
					End If
				End If
			Next i

			' Specify the output file path
			Dim result As String = "ModifyFormFieldValue_out.pdf"

			' Save the modified PDF document to the output file
			pdf.SaveToFile(result)

			' Close the document
			pdf.Close()

			' Launch the Pdf file
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
