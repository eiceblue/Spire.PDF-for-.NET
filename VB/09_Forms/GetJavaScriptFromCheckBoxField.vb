Imports System.IO
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget

Namespace GetJavaScriptFromCheckBoxField
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object.
            Dim doc As New PdfDocument()

            ' Load an existing PDF file from the specified path.
            doc.LoadFromFile("..\..\..\..\..\..\Data\GetJavaScriptFromCheckBox.pdf")

            ' Get the form widget from the loaded document and cast it to a PdfFormWidget object.
            Dim fw As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

            ' Create a StringBuilder object to store the JavaScript code.
            Dim sb As New StringBuilder()

            ' Iterate through each field in the form widget.
            For i As Integer = 0 To fw.FieldsWidget.Count - 1
                ' Get the current field as a PdfField object.
                Dim pdfField As PdfField = fw.FieldsWidget(i)

                ' Check if the field is a checkbox field.
                If TypeOf pdfField Is PdfCheckBoxWidgetFieldWidget Then
                    ' Cast the field to a PdfCheckBoxWidgetFieldWidget object.
                    Dim checkBoxField As PdfCheckBoxWidgetFieldWidget = TryCast(pdfField, PdfCheckBoxWidgetFieldWidget)

                    ' Get the MouseDown action of the checkbox field as a PdfJavaScriptAction object.
                    Dim mousedown As PdfJavaScriptAction = CType(checkBoxField.Actions.MouseDown, PdfJavaScriptAction)

                    ' Append the JavaScript script of the MouseDown action to the StringBuilder.
                    sb.Append(mousedown.Script.ToString())
                End If
            Next i

            ' Specify the output file name for the JavaScript code.
            Dim result As String = "js-out.txt"

            ' Write the contents of the StringBuilder to the output file.
            File.WriteAllText(result, sb.ToString())

            MessageBox.Show("The obtained JavaScript: " & sb.ToString())
        End Sub
    End Class
End Namespace
