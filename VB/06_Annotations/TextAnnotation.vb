Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace TextAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Define a rectangle for the text annotation
            Dim rect As RectangleF = New RectangleF(100, 100, 20, 20)

            ' Create a text annotation
            Dim annotation As PdfTextAnnotation = New PdfTextAnnotation(page, rect)

            ' Set the annotation properties
            annotation.Icon = PdfTextIcon.Note
            annotation.Title = "TextAnnotation"
            annotation.Contents = "A text annotation with a note icon."
            annotation.Name = "TextName"
            annotation.Subject = "Text"
            annotation.Open = True
            annotation.Color = Color.Yellow
            annotation.Border.Width = 2f
            annotation.Flags = PdfAnnotationFlags.Print

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Add several text annotations with different icons
            Dim icons As PdfTextIcon[] = New PdfTextIcon[]
                PdfTextIcon.Comment, PdfTextIcon.Key, PdfTextIcon.Help,
                PdfTextIcon.NewParagraph, PdfTextIcon.Paragraph, PdfTextIcon.Insert
            Dim i As Integer = 0
            While i < icons.Length
                Dim iconRect As RectangleF = New RectangleF(100 + (i % 3) * 200, 200 + (i / 3) * 100, 20, 20)
                Dim iconAnnotation As PdfTextAnnotation = New PdfTextAnnotation(page, iconRect)
                iconAnnotation.Icon = icons[i]
                iconAnnotation.Title = "Icon_" + icons[i]
                iconAnnotation.Contents = "Text annotation with the " + icons[i] + " icon."
                PdfAnnotationCollection.Create(page).Add(iconAnnotation)
                iconAnnotation.RefreshAppearances()
            Next

            ' Save the document
            Dim output As String = "TextAnnotation.pdf"
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
