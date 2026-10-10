Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations

Namespace FileAttachmentAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Define a rectangle for the file attachment annotation
            Dim rect As RectangleF = New RectangleF(100, 100, 200, 100)

            ' Create a file specification that references an existing data file
            Dim fileSpecification As PdfFileSpecification = New PdfFileSpecification(@"..\..\..\..\..\..\Data\Summary_of_Science.txt")

            ' Create a file attachment annotation with the file specification
            Dim annotation As PdfFileAttachmentAnnotation = New PdfFileAttachmentAnnotation(page, rect, fileSpecification)

            ' Set the annotation properties
            annotation.Title = "FileAttachment"
            annotation.Icon = PdfFileIcon.PushPin
            annotation.Contents = "Contents"
            annotation.Name = "Name"
            annotation.Color = Color.Red
            annotation.Border.Width = 2f
            annotation.Flags = PdfAnnotationFlags.Print

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Save the document
            Dim output As String = "FileAttachmentAnnotation.pdf"
            doc.SaveToFile(output)
            doc.Close()

            ' Launch the Pdf file
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
