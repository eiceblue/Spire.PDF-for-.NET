Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget
Imports System.IO
Imports System.Text

Namespace GetValuesFromAllFields
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a StringBuilder object to store the extracted information.
            Dim sb As New StringBuilder()

            ' Specify the input file path for the PDF document.
            Dim input As String = "..\..\..\..\..\..\Data\AllFields.pdf"

            ' Create a new PdfDocument object.
            Dim doc As New PdfDocument()

            ' Load an existing PDF file from the specified input path.
            doc.LoadFromFile(input)

            ' Get the form widget from the loaded document and cast it to a PdfFormWidget object.
            Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

            ' Iterate through each field in the form widget.
            For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
                ' Get the current field as a PdfField object.
                Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

                ' Check if the field is a TextBox field.
                If TypeOf field Is PdfTextBoxFieldWidget Then
                    ' Cast the field to a PdfTextBoxFieldWidget object.
                    Dim textBoxField As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)

                    ' Get the text value entered in the TextBox field.
                    Dim text As String = textBoxField.Text

                    ' Append the TextBox field name and its corresponding text value to the StringBuilder.
                    sb.Append("The text in the textbox is " & text & vbCrLf)
                End If

                ' Check if the field is a ListBox field.
                If TypeOf field Is PdfListBoxWidgetFieldWidget Then
                    ' Cast the field to a PdfListBoxWidgetFieldWidget object.
                    Dim listBoxField As PdfListBoxWidgetFieldWidget = TryCast(field, PdfListBoxWidgetFieldWidget)

                    ' Append the label for listbox items to the StringBuilder.
                    sb.Append("Listbox items are " & vbCrLf)

                    ' Get the collection of listbox items.
                    Dim items As PdfListWidgetItemCollection = listBoxField.Values

                    ' Iterate through each listbox item and append its value to the StringBuilder.
                    For Each item As PdfListWidgetItem In items
                        sb.Append(item.Value & vbCrLf)
                    Next item

                    ' Get the selected value in the listbox field.
                    Dim selectedValue As String = listBoxField.SelectedValue

                    ' Append the label for the selected value to the StringBuilder.
                    sb.Append("The selected value in the listbox is " & selectedValue & vbCrLf)
                End If

                ' Check if the field is a ComboBox field.
                If TypeOf field Is PdfComboBoxWidgetFieldWidget Then
                    ' Cast the field to a PdfComboBoxWidgetFieldWidget object.
                    Dim comBoxField As PdfComboBoxWidgetFieldWidget = TryCast(field, PdfComboBoxWidgetFieldWidget)

                    ' Append the label for combobox items to the StringBuilder.
                    sb.Append("comBoxField items are " & vbCrLf)

                    ' Get the collection of combobox items.
                    Dim items As PdfListWidgetItemCollection = comBoxField.Values

                    ' Iterate through each combobox item and append its value to the StringBuilder.
                    For Each item As PdfListWidgetItem In items
                        sb.Append(item.Value & vbCrLf)
                    Next item

                    ' Get the selected value in the combobox field.
                    Dim selectedValue As String = comBoxField.SelectedValue

                    ' Append the label for the selected value to the StringBuilder.
                    sb.Append("The selected value in the comBoxField is " & selectedValue & vbCrLf)
                End If

                ' Check if the field is a RadioButtonList field.
                If TypeOf field Is PdfRadioButtonListFieldWidget Then
                    ' Cast the field to a PdfRadioButtonListFieldWidget object.
                    Dim radioBtnField As PdfRadioButtonListFieldWidget = TryCast(field, PdfRadioButtonListFieldWidget)

                    ' Get the value of the selected RadioButton.
                    Dim value As String = radioBtnField.Value

                    ' Append the label for the selected value to the StringBuilder.
                    sb.Append("The text in radioButtonField is " & value & vbCrLf)
                End If

                ' Check if the field is a CheckBox field.
                If TypeOf field Is PdfCheckBoxWidgetFieldWidget Then
                    ' Cast the field to a PdfCheckBoxWidgetFieldWidget object.
                    Dim checkBoxField As PdfCheckBoxWidgetFieldWidget = TryCast(field, PdfCheckBoxWidgetFieldWidget)

                    ' Get the checked state of the CheckBox field.
                    Dim state As Boolean = checkBoxField.Checked

                    ' Append the label indicating whether the CheckBox is checked or not to the StringBuilder.
                    sb.Append("If the checkBox is checked: " & state & vbCrLf)
                End If
            Next i

            ' Specify the output file name for the extracted information.
            Dim result As String = "GetAllValues.txt"

            ' Write the contents of the StringBuilder to the output file.
            File.WriteAllText(result, sb.ToString())

            ' Close the document.
            doc.Close()

            ' Launch the file.
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
