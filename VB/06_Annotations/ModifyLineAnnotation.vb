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

Namespace ModifyLineAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim result As String = "ModifyLineAnnotation.pdf"

            ' Create a new PdfDocument object
            Dim document As PdfDocument = New PdfDocument()

            ' Load an existing PDF file into the document from the specified path
            document.LoadFromFile(@"..\..\..\..\..\..\Data\PdfLineAnnotation.pdf")

            ' Retrieve the first annotation from the first page of the document
            Dim annotation As PdfAnnotation = PdfAnnotationCollection.Create(document.Pages[0])[0]

            ' Check if the retrieved annotation is a PdfLineAnnotation
            If annotation is PdfLineAnnotation Then
                ' Cast the annotation as a PdfLineAnnotation to access its specific properties and methods
                Dim lineAnn As PdfLineAnnotation = annotation as PdfLineAnnotation

                ' Set the title property of the line annotation to "Author_test"
                lineAnn.Title = "Author_test"

                ' Set the subject property of the line annotation to "Subject_test"
                lineAnn.Subject = "Subject_test"
            End If

            ' Save the modified document to the specified file path
            document.SaveToFile(result)

            document.Dispose()

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
