Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports System.ComponentModel
Imports System.Text

Namespace GetFieldValue
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load from file
			doc.LoadFromFile("..\..\..\..\..\..\Data\TextBoxSampleB_1.pdf")

			'Get form fields
			Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			'Get textbox
			Dim textbox As PdfTextBoxFieldWidget = TryCast(formWidget.FieldsWidget("Text1"), PdfTextBoxFieldWidget)

			'Get the text of the textbox
			Dim text As String = textbox.Text

			MessageBox.Show("The value of the field named " & textbox.Name & " is " & text)

		End Sub
	End Class
End Namespace
