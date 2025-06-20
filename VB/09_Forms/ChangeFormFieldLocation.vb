Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields

Namespace ChangeFormFieldLocation
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Define the input file path
            Dim input As String = "..\..\..\..\..\..\Data\FormField.pdf"

            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified input file
            pdf.LoadFromFile(input)

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

                    ' Check if the TextBox field has the name "TextBox1"
                    If textbox.Name = "TextBox1" Then
                        ' Set the location of the TextBox field
                        textbox.Location = New PointF(390, 525)
                    End If
                End If
            Next i

            ' Specify the output file path
            Dim result As String = "ChangeFormFieldLocation_out.pdf"

            ' Save the modified PDF document to the specified output file
            pdf.SaveToFile(result)

            ' Close the document
            pdf.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub
    End Class
End Namespace
