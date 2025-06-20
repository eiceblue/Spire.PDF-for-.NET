Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Namespace SelectRadioButtonItem
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path
			Dim input As String = "..\..\..\..\..\..\Data\RadioButton.pdf"

			' Create a new instance of PdfDocument
			Dim pdf As New PdfDocument()

			' Load the PDF document from the specified input file
			pdf.LoadFromFile(input)

			' Access the form widget of the PDF document
			Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

			' Iterate through each field in the form
			For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

				' Check if the field is a radio button list field
				If TypeOf field Is PdfRadioButtonListFieldWidget Then
					Dim radioButton As PdfRadioButtonListFieldWidget = TryCast(field, PdfRadioButtonListFieldWidget)

					' Check if the radio button list field has a specific name (e.g., "RadioButton")
					If radioButton.Name = "RadioButton" Then
						' Select the second item in the radio button list
						radioButton.SelectedIndex = 1
					End If
				End If
			Next i

			' Specify the output file path
			Dim result As String = "SelectRadioButtonItem_out.pdf"

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
