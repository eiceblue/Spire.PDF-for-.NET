Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Windows.Forms

Namespace RemoveHyperlinks
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Load an existing PDF file.
            Dim document As PdfDocument = New PdfDocument()
            document.LoadFromFile(@"..\..\..\..\..\..\Data\RemoveHyperlinks.pdf")

            ' Get the first page of the document.
            Dim page As PdfPageBase = document.Pages[0]

            ' Get the collection of annotations on the page.
            Dim widgetCollection As PdfAnnotationCollection = PdfAnnotationCollection.Create(page)

            ' Check if the widgetCollection is not null and contains annotations.
            If widgetCollection.Count > 0 Then
                ' Iterate over the annotations in reverse order.
                Dim i As Integer = widgetCollection.Count - 1
                While i >= 0
                    ' Get the current annotation.
                    Dim annotation As PdfAnnotation = widgetCollection[i]

                    ' Check if the annotation is a TextWebLink Annotation.
                    If annotation is PdfLinkAnnotation Then
                        ' Cast the annotation to TextWebLink Annotation.
                        Dim link As PdfLinkAnnotation = annotation as PdfLinkAnnotation

                        ' Remove the TextWebLink annotation from the collection.
                        widgetCollection.Remove(link)
                    End If
                Next
            End If

            ' Specify the output file name.
            Dim output As String = "RemoveHyperlinks-result.pdf"

            ' Save the modified document to a new file.
            document.SaveToFile(output)

            'Launch the Pdf file
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace
