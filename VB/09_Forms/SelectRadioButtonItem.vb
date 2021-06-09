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
			'Load a pdf document
			Dim input As String = "..\..\..\..\..\..\Data\RadioButton.pdf"
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(input)

			'Get pdf forms
			Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

			'Find the radio button field and select the second item
			For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

				If TypeOf field Is PdfRadioButtonListFieldWidget Then
					Dim radioButton As PdfRadioButtonListFieldWidget = TryCast(field, PdfRadioButtonListFieldWidget)
					If radioButton.Name = "RadioButton" Then
						radioButton.SelectedIndex = 1
					End If
				End If
			Next i

			Dim result As String = "SelectRadioButtonItem_out.pdf"

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
