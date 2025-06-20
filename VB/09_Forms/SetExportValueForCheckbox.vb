Imports Spire.Pdf
Imports Spire.Pdf.Widget

Namespace SetExportValueForCheckbox
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\SetExportValueForCheckbox.pdf"

            ' Create a new instance of PdfDocument
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified input file
            pdf.LoadFromFile(input)

            ' Access the form widget of the PDF document
            Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

            ' Initialize a count variable to track export values
            Dim count As Integer = 1

            ' Iterate through each field in the form
            For Each field As PdfFieldWidget In formWidget.FieldsWidget

                ' Check if the field is a checkbox widget field
                If TypeOf field Is PdfCheckBoxWidgetFieldWidget Then
                    Dim checkbox As PdfCheckBoxWidgetFieldWidget = TryCast(field, PdfCheckBoxWidgetFieldWidget)

                    ' Set the export value for the checkbox field
                    checkbox.SetExportValue("True" & (count))

                    ' Increment the count variable
                    count += 1
                End If
            Next field

            ' Specify the output file path
            Dim result As String = "SetExportValueForCheckbox_result.pdf"

            ' Save the modified PDF document to the output file using PDF format
            pdf.SaveToFile(result, FileFormat.PDF)

            ' Close the document
            pdf.Close()

            ' Launch the result file
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
