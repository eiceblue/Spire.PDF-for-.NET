Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget

Namespace FillFormField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file 
            Dim input As String = "..\..\..\..\..\..\..\Data\FormField.pdf"

			'open pdf document
			Dim doc As New PdfDocument(input)

			'get pdf form
			Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			'fill pdf form fields
			For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)
				If TypeOf field Is PdfTextBoxFieldWidget Then
					Dim textBoxField As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)
					Select Case textBoxField.Name
						Case "email"
							textBoxField.Text = "support@e-iceblue.com"

						Case "username"
							textBoxField.Text = "E-iceblue"

						Case "password"
							textBoxField.Password = True
							textBoxField.Text = "e-iceblue"

						Case "password2"
							textBoxField.Password = True
							textBoxField.Text = "e-iceblue"

						Case "company_name "
							textBoxField.Text = "E-iceblue"

						Case "first_name"
							textBoxField.Text = "James"

						Case "last_name"
							textBoxField.Text = "Chen"

						Case "middle_name"
							textBoxField.Text = "J"

						Case "address1"
							textBoxField.Text = "Chengdu"

						Case "address2"
							textBoxField.Text = "Beijing"

						Case "city"
							textBoxField.Text = "Shanghai"

						Case "postal_code"
							textBoxField.Text = "11111"

						Case "state"
							textBoxField.Text = "Shanghai"

						Case "phone"
							textBoxField.Text = "1234567901"

						Case "mobile_phone"
							textBoxField.Text = "123456789"

						Case "fax"
							textBoxField.Text = "12121212"
					End Select
				End If

				If TypeOf field Is PdfListBoxWidgetFieldWidget Then
					Dim listBoxField As PdfListBoxWidgetFieldWidget = TryCast(field, PdfListBoxWidgetFieldWidget)
					Select Case listBoxField.Name
						Case "email_format"
							Dim index() As Integer = { 1 }
							listBoxField.SelectedIndex = index
					End Select
				End If

				If TypeOf field Is PdfComboBoxWidgetFieldWidget Then
					Dim comBoxField As PdfComboBoxWidgetFieldWidget = TryCast(field, PdfComboBoxWidgetFieldWidget)
					Select Case comBoxField.Name
						Case "title"
							Dim items() As Integer = { 0 }
							comBoxField.SelectedIndex = items
					End Select
				End If

				If TypeOf field Is PdfRadioButtonListFieldWidget Then
					Dim radioBtnField As PdfRadioButtonListFieldWidget = TryCast(field, PdfRadioButtonListFieldWidget)
					Select Case radioBtnField.Name
						Case "country"
							radioBtnField.SelectedIndex = 1
					End Select
				End If

				If TypeOf field Is PdfCheckBoxWidgetFieldWidget Then
					Dim checkBoxField As PdfCheckBoxWidgetFieldWidget = TryCast(field, PdfCheckBoxWidgetFieldWidget)
					Select Case checkBoxField.Name
						Case "agreement_of_terms"
							checkBoxField.Checked = True
					End Select
				End If

				If TypeOf field Is PdfButtonWidgetFieldWidget Then
					Dim btnField As PdfButtonWidgetFieldWidget = TryCast(field, PdfButtonWidgetFieldWidget)
					Select Case btnField.Name

						Case "submit"
							btnField.Text = "Submit"
					End Select
				End If
			Next i

			Dim output As String = "FillFormField.pdf"

			'save pdf document
			doc.SaveToFile(output)

			'Launching the Pdf file
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
