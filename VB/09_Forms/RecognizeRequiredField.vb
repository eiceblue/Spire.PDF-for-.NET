Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget

Namespace RecognizeRequiredField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path
			Dim input As String = "..\..\..\..\..\..\Data\RecognizeRequiredField.pdf"

			' Create a new instance of PdfDocument
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified input file
			doc.LoadFromFile(input)

			' Access the form widget of the PDF document
			Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			' Iterate through each field in the form
			For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

				' Check if the field is required
				If field.Required Then
					MessageBox.Show("The field named: " & field.Name & " is required")
				End If
			Next i

			' Close the document
			doc.Close()
		End Sub
	End Class
End Namespace
