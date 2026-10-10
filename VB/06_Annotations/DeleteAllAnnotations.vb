Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Windows.Forms

Namespace DeleteAllAnnotations
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a new PDF document.
            Dim document As PdfDocument = New PdfDocument()

            'Load the file from disk
            document.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_3.pdf")

            'Remove all annotations
            PdfAnnotationCollection.Create(document.Pages[0]).Clear()

            Dim result As String = "DeleteAllAnnotations.pdf"

            'Save the document
            document.SaveToFile(result)
            document.Close()

            'Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                System.Diagnostics.Process.Start(filename)
        Catch
        End Try
        End Sub
    End Class
End Namespace
