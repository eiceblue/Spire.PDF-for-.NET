Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Imports System.IO

Namespace GetStyleOfRadioButton
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path.
            Dim input As String = "..\..\..\..\..\..\Data\GetStyleOfRadioButton.pdf"

            ' Create a new PdfDocument object.
            Dim pdf As New PdfDocument()

            ' Load an existing PDF file from the specified input path.
            pdf.LoadFromFile(input)

            ' Get the first page of the loaded PDF document.
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Get the form widget from the loaded document and cast it to a PdfFormWidget object.
            Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

            ' Create a StringBuilder object to store the extracted information.
            Dim builder As New StringBuilder()

            ' Initialize a counter for radio buttons.
            Dim num As Integer = 0

            ' Iterate through each field in the form widget.
            For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
                ' Get the current field as a PdfField object.
                Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

                ' Check if the field is a radio button list field.
                If TypeOf field Is PdfRadioButtonListFieldWidget Then
                    ' Increment the counter for radio buttons.
                    num += 1

                    ' Cast the field to a PdfRadioButtonListFieldWidget object.
                    Dim radio As PdfRadioButtonListFieldWidget = TryCast(field, PdfRadioButtonListFieldWidget)

                    ' Get the button style of the radio button.
                    Dim buttonStyle As PdfCheckBoxStyle = radio.ButtonStyle

                    ' Append the button style information to the StringBuilder.
                    builder.AppendLine(String.Format("The button style of Radio button {0} is: {1}", num, buttonStyle.ToString()))
                End If
            Next i

            ' Specify the output file name for the extracted information.
            Dim result As String = "GetStyleOfRadioButton_out.txt"

            ' Write the contents of the StringBuilder to the output file.
            File.WriteAllText(result, builder.ToString())

            ' Close the document.
            pdf.Close()

            ' Launch the txt file
            DocumentViewer(result)
        End Sub
        Private Sub DocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub
    End Class
End Namespace
