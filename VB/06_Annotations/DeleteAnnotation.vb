Imports System
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations

Namespace DeleteAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim input As String = @"..\..\..\..\..\..\Data\DeleteAnnotation.pdf"

            'Open pdf document
            Dim doc As PdfDocument = New PdfDocument()
            doc.LoadFromFile(input)

            'Remove the first annotation
            PdfAnnotationCollection.Create(doc.Pages[0]).RemoveAt(0)

            Dim output As String = "DeleteAnnotation.pdf"

            'Save pdf document
            doc.SaveToFile(output)
            doc.Close()

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
