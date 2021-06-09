Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget
Imports System.ComponentModel
Imports System.Text

Namespace RecognizeRequiredField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a pdf document
			Dim input As String = "..\..\..\..\..\..\Data\RecognizeRequiredField.pdf"
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)
			'Get pdf forms
			Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)
				'Judge if the field is required
				If field.Required Then
					MessageBox.Show("The field named: " & field.Name & " is required")
				End If
			Next i

		End Sub
	End Class
End Namespace
