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
            ' Define the input file path
            Dim input As String = "..\..\..\..\..\..\Data\FillFormField.pdf"

            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified input file
            doc.LoadFromFile(input)

            ' Get the form widget from the loaded PDF document
            Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

            ' Iterate through each field in the form
            For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
                ' Get the current field
                Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

                ' Check if the field is a TextBox field
                If TypeOf field Is PdfTextBoxFieldWidget Then
                    ' Cast the field as a TextBox field
                    Dim textBoxField As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)

                    ' Fill the TextBox fields based on their names
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

                        Case "company_name"
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

                ' Check if the field is a ListBox field
                If TypeOf field Is PdfListBoxWidgetFieldWidget Then
                    ' Cast the field as a ListBox field
                    Dim listBoxField As PdfListBoxWidgetFieldWidget = TryCast(field, PdfListBoxWidgetFieldWidget)

                    ' Fill the ListBox fields based on their names
                    Select Case listBoxField.Name
                        Case "email_format"
                            Dim index() As Integer = {1}
                            listBoxField.SelectedIndex = index
                    End Select
                End If

                ' Check if the field is a ComboBox field
                If TypeOf field Is PdfComboBoxWidgetFieldWidget Then
                    ' Cast the field as a ComboBox field
                    Dim comBoxField As PdfComboBoxWidgetFieldWidget = TryCast(field, PdfComboBoxWidgetFieldWidget)

                    ' Fill the ComboBox fields based on their names
                    Select Case comBoxField.Name
                        Case "title"
                            Dim items() As Integer = {0}
                            comBoxField.SelectedIndex = items
                    End Select
                End If

                ' Check if the field is a RadioButtonList field
                If TypeOf field Is PdfRadioButtonListFieldWidget Then
                    ' Cast the field as a RadioButtonList field
                    Dim radioBtnField As PdfRadioButtonListFieldWidget = TryCast(field, PdfRadioButtonListFieldWidget)

                    ' Fill the RadioButtonList fields based on their names
                    Select Case radioBtnField.Name
                        Case "country"
                            radioBtnField.SelectedIndex = 1
                    End Select
                End If

                ' Check if the field is a CheckBox field
                If TypeOf field Is PdfCheckBoxWidgetFieldWidget Then
                    ' Cast the field as a CheckBox field
                    Dim checkBoxField As PdfCheckBoxWidgetFieldWidget = TryCast(field, PdfCheckBoxWidgetFieldWidget)

                    ' Fill the CheckBox fields based on their names
                    Select Case checkBoxField.Name
                        Case "agreement_of_terms"
                            checkBoxField.Checked = True
                    End Select
                End If

                ' Check if the field is a Button field
                If TypeOf field Is PdfButtonWidgetFieldWidget Then
                    ' Cast the field as a Button field
                    Dim btnField As PdfButtonWidgetFieldWidget = TryCast(field, PdfButtonWidgetFieldWidget)

                    ' Fill the Button fields based on their names
                    Select Case btnField.Name
                        Case "submit"
                            btnField.Text = "Submit"
                    End Select
                End If
            Next i

            ' Define the output file path
            Dim output As String = "FillFormField.pdf"

            'Save the document to the file path
            doc.SaveToFile(output)

            ' Close the document
            doc.Close()

            ' Launch the file
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
