Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace PopupAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Create a parent text annotation
            Dim textRect As RectangleF = New RectangleF(100, 100, 200, 100)
            Dim parent As PdfTextAnnotation = New PdfTextAnnotation(page, textRect)
            parent.Icon = PdfTextIcon.Note
            parent.Title = "ParentNote"
            parent.Contents = "This Is the parent text annotation."
            parent.Color = New PdfRGBColor(255, 255, 0)

            ' Define a rectangle for the popup annotation
            Dim popupRect As RectangleF = New RectangleF(330, 80, 200, 120)

            ' Create a popup annotation and link it to the parent
            Dim annotation As PdfPopupAnnotation = New PdfPopupAnnotation(page, popupRect)
            annotation.Parent = parent
            annotation.Open = True
            annotation.Contents = "Contents"
            annotation.Name = "Name"
            annotation.Color = Color.Red
            annotation.Border.Width = 2f
            annotation.Flags = PdfAnnotationFlags.Print

            ' Add the parent and the popup annotation to the page
            PdfAnnotationCollection.Create(page).Add(parent)
            PdfAnnotationCollection.Create(page).Add(annotation)

            ' Save the document
            Dim output As String = "PopupAnnotation.pdf"
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
