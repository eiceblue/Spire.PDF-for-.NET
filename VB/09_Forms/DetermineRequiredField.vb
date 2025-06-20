Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields

Namespace DetermineRequiredField
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Define the input file path
            Dim input As String = "..\..\..\..\..\..\Data\DetermineRequiredField.pdf"

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
                    Dim textbox As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)

                    ' Check if the TextBox field has the name "username"
                    If textbox.Name = "username" Then
                        ' Set the field as required
                        textbox.Required = True
                    End If

                    ' Check if the TextBox field has the name "password2"
                    If textbox.Name = "password2" Then
                        ' Set the field as not required
                        textbox.Required = False
                    End If
                End If
            Next i

            ' Specify the output file path
            Dim output As String = "DetermineRequiredField.pdf"

            ' Save the modified PDF document to the specified output file
            doc.SaveToFile(output)

            ' Close the document
            doc.Close()

            'Launch the file
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
