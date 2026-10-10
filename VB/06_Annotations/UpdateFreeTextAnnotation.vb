Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace UpdateFreeTextAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document.
            Dim pdf As PdfDocument = New PdfDocument()

            ' Load an existing PDF document from a file.
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\UpdateFreeTextAnnotation.pdf")

            ' Get the collection of annotations from the first page of the PDF document.
            Dim annotations As PdfAnnotationCollection = PdfAnnotationCollection.Create(pdf.Pages[0])

            ' Iterate through each free text annotation in the collection.
            For Each annotation As PdfFreeTextAnnotation In annotations
                ' Change the color of the annotation to YellowGreen.
                annotation.Color = Color.YellowGreen
                annotation.RefreshAppearances()
            Next

            Dim result As String = "UpdateFreeTextAnnotation.pdf"

            ' Save the modified PDF document to a file with the specified filename.
            pdf.SaveToFile(result)
            pdf.Close()

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
