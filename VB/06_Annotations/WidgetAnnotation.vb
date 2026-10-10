Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations

Namespace WidgetAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Load an existing PDF document that contains a form field
            Dim doc As PdfDocument = New PdfDocument()
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\AllFields.pdf")

            ' Get the first page and its first annotation as a widget annotation
            Dim page As PdfPageBase = doc.Pages[0]
            Dim annotation As PdfWidgetAnnotation = PdfAnnotationCollection.Create(page)[0] as PdfWidgetAnnotation

            If annotation != null Then
                ' Set the annotation properties
                annotation.Color = Color.Red
                annotation.Flags = PdfAnnotationFlags.Print
                annotation.Border.Width = 3f
                annotation.RefreshAppearances()
            End If

            ' Save the document
            Dim output As String = "WidgetAnnotation.pdf"
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
