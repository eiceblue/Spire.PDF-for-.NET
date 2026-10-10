Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Windows.Forms

Namespace SetPropertiesForStamp
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Load an existing PDF document from the disk.
            Dim pdf As PdfDocument = New PdfDocument()
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\TextStamp.pdf")

            ' Get the first page from the document.
            Dim page As PdfPageBase = pdf.Pages[0]

            ' Traverse through each annotation widget on the page.
            For Each annotation As PdfAnnotation In PdfAnnotationCollection.Create(page)
                'If it is PdfRubberStampAnnotationWidget
                If annotation is PdfRubberStampAnnotation Then
                    Dim stamp As PdfRubberStampAnnotation = annotation as PdfRubberStampAnnotation
                    stamp.Title = "TestUser"
                    stamp.Subject = "E-iceblue"
                    stamp.CreationDate = DateTime.Now
                    stamp.ModifiedDate = DateTime.Now
                End If
            Next

            ' Save the modified PDF document to a file.
            Dim result As String = "SetPropertiesForStamp.pdf"
            pdf.SaveToFile(result, Spire.Pdf.FileFormat.PDF)

            'Launch the file
            DocumentViewer(result)
        End Sub
        Private Sub DocumentViewer(ByVal filename As String)
            Try
                System.Diagnostics.Process.Start(filename)
        Catch
        End Try
        End Sub
    End Class
End Namespace
