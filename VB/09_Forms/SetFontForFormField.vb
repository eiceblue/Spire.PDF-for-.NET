Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Widget

Namespace SetFontForFormField
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of PdfDocument
            Dim doc As New PdfDocument()

            ' Load the PDF document from file
            doc.LoadFromFile("..\..\..\..\..\..\Data\TextBoxSampleB.pdf")

            ' Access the form widget of the PDF document
            Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

            ' Access the textbox field by name ("Text1")
            Dim textbox As PdfTextBoxFieldWidget = TryCast(formWidget.FieldsWidget("Text1"), PdfTextBoxFieldWidget)

            ' Set the font for the textbox
            textbox.Font = New PdfTrueTypeFont(New Font("Tahoma", 12), True)
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'textbox.Font = New PdfTrueTypeFont("Tahoma", 12, PdfFontStyle.Regular, True)
            ' =============================================================================

            ' Set the text value for the textbox
            textbox.Text = "Hello World"

            ' Specify the output file path
            Dim result As String = "SetFontForFormField-result.pdf"

            ' Save the modified PDF document to the output file
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
