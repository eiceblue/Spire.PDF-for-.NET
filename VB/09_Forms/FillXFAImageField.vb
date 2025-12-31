Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Widget

Namespace FillXFAImageField
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdfDocument As New PdfDocument()

            ' Load a PDF file from the specified path
            pdfDocument.LoadFromFile("..\..\..\..\..\..\Data\XFAImageField.pdf")

            ' Get the form widget from the loaded PDF document
            Dim form As PdfFormWidget = TryCast(pdfDocument.Form, PdfFormWidget)

            ' Check if the form is an XFA form
            If form.XFAForm IsNot Nothing Then
                ' Get a list of XFA fields from the XFA form
                Dim xFields As List(Of XfaField) = form.XFAForm.XfaFields

                ' Loop through each XFA field
                For i As Integer = 0 To xFields.Count - 1
                    ' Check if the current field is an XfaImageField
                    If TypeOf xFields(i) Is XfaImageField Then
                        ' Add an image to the XfaImageField
                        Dim xImageField As XfaImageField = TryCast(xFields(i), XfaImageField)
                        Dim fileStream As New FileStream("..\..\..\..\..\..\Data\E-logo.png", FileMode.Open, FileAccess.Read, FileShare.Read)

                        xImageField.Image = Image.FromStream(fileStream)
                        ' =============================================================================
                        ' Use the following code for netstandard dlls
                        ' =============================================================================
                        'xImageField.Image =fileStream
                        ' =============================================================================
                    End If
                Next i
            End If

            ' Save the modified PDF document to a file with the specified name
            Dim result As String = "XFAImageField_output.pdf"
            pdfDocument.SaveToFile(result)

            ' Close the document
            pdfDocument.Close()

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
