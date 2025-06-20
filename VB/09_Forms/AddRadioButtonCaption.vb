Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AddRadioButtonCaption
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\RadioButton.pdf"

            ' Create a new PDF document
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the input file
            pdf.LoadFromFile(input)

            ' Get the form widget from the PDF document
            Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

            ' Iterate through each field in the form
            For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
                ' Get the current form field
                Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

                ' Check if the form field is a radio button list field
                If TypeOf field Is PdfRadioButtonListFieldWidget Then
                    ' Cast the field to a radio button list field widget
                    Dim radioButton As PdfRadioButtonListFieldWidget = TryCast(field, PdfRadioButtonListFieldWidget)

                    ' Check if the radio button list field has the specified name
                    If radioButton.Name = "RadioButton" Then
                        ' Get the page where the radio button list field is located
                        Dim page As PdfPageBase = radioButton.Page

                        ' Set the caption text for the radio button list field
                        Dim text As String = "Radio button caption"

                        ' Set the font, pen, and brush for drawing the caption
                        Dim font As New PdfFont(PdfFontFamily.Helvetica, 12.0F)
                        Dim pen As New PdfPen(Color.Red, 0.02F)
                        Dim brush As New PdfSolidBrush(Color.Red)

                        ' Set the coordinates for drawing the caption
                        Dim x As Single = radioButton.Location.X
                        Dim y As Single = radioButton.Location.Y - font.MeasureString(text).Height - 10

                        ' Draw the caption onto the page
                        page.Canvas.DrawString(text, font, pen, brush, x, y)
                    End If
                End If
            Next i

            ' Specify the output file path
            Dim result As String = "AddRadioButtonCaption_out.pdf"

            ' Save the modified PDF document to the output file
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
