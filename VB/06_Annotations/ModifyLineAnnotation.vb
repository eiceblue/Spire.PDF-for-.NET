Imports Spire.Pdf
Imports Spire.Pdf.Annotations

Namespace ModifyLineAnnotation
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object 
            Dim document As New PdfDocument()

            ' Load an existing PDF document
            document.LoadFromFile("..\..\..\..\..\..\Data\PdfLineAnnotation.pdf")

            ' Get the first annotation from the first page of the document
            Dim annotation As PdfAnnotation = document.Pages(0).Annotations(0)

            ' Check if the annotation is a PdfLineAnnotationWidget
            If TypeOf annotation Is PdfLineAnnotationWidget Then
                ' Cast the annotation as a PdfLineAnnotationWidget
                Dim lineAnn As PdfLineAnnotationWidget = TryCast(annotation, PdfLineAnnotationWidget)

                ' Modify the author and subject properties of the line annotation
                lineAnn.Author = "Author_test"
                lineAnn.Subject = "Subject_test"
            End If

            ' Save the modified document to a file
            Dim result As String = "ModifyLineAnnotation.pdf"
            document.SaveToFile(result)

            ' Close the document
            document.Close()

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
