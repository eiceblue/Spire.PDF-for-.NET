Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Widget

Namespace FillImageInButtonField
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load a PDF file from a specified path
            pdf.LoadFromFile("..\..\..\..\..\..\Data\ButtonField.pdf")

            ' Get the form widget from the loaded PDF document and cast it to PdfFormWidget
            Dim form As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

            ' Iterate through each field in the form
            For i As Integer = 0 To form.FieldsWidget.Count - 1

                ' Check if the field is a button widget
                If TypeOf form.FieldsWidget(i) Is PdfButtonWidgetFieldWidget Then

                    ' Cast the field to PdfButtonWidgetFieldWidget
                    Dim field As PdfButtonWidgetFieldWidget = TryCast(form.FieldsWidget(i), PdfButtonWidgetFieldWidget)

                    ' Check if the button field has a specific name (e.g., "Button1")
                    If field.Name = "Button1" Then

                        ' Set the icon layout properties of the button field
                        field.IconLayout.IsFitBounds = True
                        field.IconLayout.ScaleMode = PdfButtonIconScaleMode.Anamorphic

                        ' Set the button image using an image file
                        field.SetButtonImage(PdfImage.FromFile("..\..\..\..\..\..\Data\E-logo.png"))

                    End If
                End If
            Next i

            ' Save the modified PDF document to a new file named "FillImageInButtonField.pdf"
            Dim result As String = "FillImageInButtonField.pdf"
            pdf.SaveToFile(result, FileFormat.PDF)

            ' Close the document
            pdf.Close()

            ' Launch the file
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
