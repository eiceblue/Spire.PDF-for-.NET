Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Namespace ExtractJavaScript
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim pdf As New PdfDocument()

			'Load a pdf document
			pdf.LoadFromFile("..\..\..\..\..\..\Data\ExtractJavaScript.pdf")

			Dim js As String = Nothing

			Dim form As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)
			For i As Integer = 0 To form.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(form.FieldsWidget.List(i), PdfField)
				If TypeOf field Is PdfTextBoxFieldWidget Then
					Dim textbox As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)

					'Find the textbox named total
					If textbox.Name = "total" Then
						'Get the action
						Dim jsa As PdfJavaScriptAction = textbox.Actions.Calculate

						If jsa IsNot Nothing Then
							'Get JavaScript
							js = jsa.Script
						End If
					End If
				End If
			Next i

			'Save and launch the result file
			File.WriteAllText("ExtractJavaScript.txt", js)
			Process.Start("ExtractJavaScript.txt")
		End Sub

	End Class
End Namespace
