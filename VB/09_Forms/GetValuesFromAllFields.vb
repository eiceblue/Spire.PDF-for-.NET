Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Namespace GetValuesFromAllFields
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim sb As New StringBuilder()

			'Load a pdf document
			Dim input As String = "..\..\..\..\..\..\Data\AllFields.pdf"
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)

			'Get pdf forms
			Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			'Find pdf form fields
			For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)
				If TypeOf field Is PdfTextBoxFieldWidget Then
					Dim textBoxField As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)
					'Get text of textbox
					Dim text As String = textBoxField.Text
					sb.Append("The text in textbox is " & text & vbCrLf)
				End If

				If TypeOf field Is PdfListBoxWidgetFieldWidget Then
					Dim listBoxField As PdfListBoxWidgetFieldWidget = TryCast(field, PdfListBoxWidgetFieldWidget)
					sb.Append("Listbox items are " & vbCrLf)
					'Get values of listbox
					Dim items As PdfListWidgetItemCollection = listBoxField.Values

					For Each item As PdfListWidgetItem In items
						sb.Append(item.Value & vbCrLf)
					Next item
					'Get selected value
					Dim selectedValue As String = listBoxField.SelectedValue
					sb.Append("The selected value in the listbox is " & selectedValue & vbCrLf)

				End If

				If TypeOf field Is PdfComboBoxWidgetFieldWidget Then
					Dim comBoxField As PdfComboBoxWidgetFieldWidget = TryCast(field, PdfComboBoxWidgetFieldWidget)
					sb.Append("comBoxField items are " & vbCrLf)
					'Get values of comboBox
					Dim items As PdfListWidgetItemCollection = comBoxField.Values

					For Each item As PdfListWidgetItem In items
						sb.Append(item.Value & vbCrLf)
					Next item
					'Get selected value
					Dim selectedValue As String = comBoxField.SelectedValue
					sb.Append("The selected value in the comBoxField is " & selectedValue & vbCrLf)

				End If

				If TypeOf field Is PdfRadioButtonListFieldWidget Then
					Dim radioBtnField As PdfRadioButtonListFieldWidget = TryCast(field, PdfRadioButtonListFieldWidget)
					'Get value of radio button
					Dim value As String = radioBtnField.Value

					sb.Append("The text in radioButtonField is " & value & vbCrLf)
				End If

				If TypeOf field Is PdfCheckBoxWidgetFieldWidget Then
					Dim checkBoxField As PdfCheckBoxWidgetFieldWidget = TryCast(field, PdfCheckBoxWidgetFieldWidget)
					'Get the checked state of the checkbox
					Dim state As Boolean = checkBoxField.Checked
					sb.Append("If the checkBox is checked: " & state & vbCrLf)
				End If
			Next i
			Dim result As String = "GetAllValues.txt"

			File.WriteAllText(result, sb.ToString())

			'Launch file
			PDFDocumentViewer(result)

		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
