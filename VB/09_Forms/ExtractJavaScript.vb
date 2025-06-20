Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget
Imports System.IO

Namespace ExtractJavaScript
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified file path
            pdf.LoadFromFile("..\..\..\..\..\..\Data\ExtractJavaScript.pdf")

            ' Initialize a variable to store the JavaScript code
            Dim js As String = Nothing

            ' Get the form widget from the loaded PDF document
            Dim form As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

            ' Iterate through each field in the form
            For i As Integer = 0 To form.FieldsWidget.List.Count - 1
                ' Get the current field
                Dim field As PdfField = TryCast(form.FieldsWidget.List(i), PdfField)

                ' Check if the field is a TextBox field
                If TypeOf field Is PdfTextBoxFieldWidget Then
                    ' Cast the field as a TextBox field
                    Dim textbox As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)

                    ' Find the textbox named "total"
                    If textbox.Name = "total" Then
                        ' Get the Calculate action of the textbox
                        Dim jsa As PdfJavaScriptAction = textbox.Actions.Calculate

                        ' Check if a JavaScript action is associated with the textbox
                        If jsa IsNot Nothing Then
                            ' Get the JavaScript code from the action
                            js = jsa.Script
                        End If
                    End If
                End If
            Next i

            ' Write the JavaScript code to a text file
            File.WriteAllText("ExtractJavaScript.txt", js)

            ' Close the document
            pdf.Close()

            Process.Start("ExtractJavaScript.txt")
        End Sub

    End Class
End Namespace
