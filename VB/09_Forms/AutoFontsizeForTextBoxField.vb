Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Widget

Namespace AutoFontsizeForTextBoxField
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load an existing PDF file from a specific location
            pdf.LoadFromFile("..\..\..\..\..\..\Data\FormField.pdf")

            ' Get the form widget from the loaded PDF document
            Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

            ' Loop through each field in the form widget
            For Each field As PdfField In formWidget.FieldsWidget.List
                ' Check if the field is a TextBox field
                If TypeOf field Is PdfTextBoxFieldWidget Then
                    ' Cast the field to a TextBox field widget
                    Dim textBoxField As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)

                    ' Set the font for the TextBox field to Arial with size 16
                    textBoxField.Font = New PdfTrueTypeFont(New Font("Arial", 16), True)
                    ' =============================================================================
                    ' Use the following code for netstandard dlls
                    ' =============================================================================
                    'textBoxField.Font = New PdfTrueTypeFont("Arial", 16,PdfFontStyle.Regular,True)
                    ' =============================================================================

                    ' Enable auto font size adjustment for the TextBox field
                    textBoxField.FontSizeAuto = True

                    ' Set the text of the TextBox field to "e-iceblue"
                    textBoxField.Text = "e-iceblue"
                End If
            Next field

            ' Save the modified PDF document to a new file named "setAutoFontSize.pdf" in PDF format
            pdf.SaveToFile("setAutoFontSize.pdf", FileFormat.PDF)

            ' Close the document
            pdf.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("setAutoFontSize.pdf")
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
