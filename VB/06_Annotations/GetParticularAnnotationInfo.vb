Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace GetParticularAnnotationInfo
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a new PDF document.
            Dim pdf As PdfDocument = New PdfDocument()

            'Load the file from disk.
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_3.pdf")

            'Get the annotation collection from the document.
            Dim annotations As PdfAnnotationCollection = PdfAnnotationCollection.Create(pdf.Pages[0])

            'Get particular annotation information from the document.
            Dim content As StringBuilder = New StringBuilder()
            If annotations[0] is PdfTextAnnotation Then
                Dim textAnnotation As PdfTextAnnotation = annotations[0] as PdfTextAnnotation
                content.AppendLine("Annotation text: " + textAnnotation.Contents)
                content.AppendLine("Annotation ModifiedDate: " + textAnnotation.ModifiedDate.ToString())
                content.AppendLine("Annotation author: " + textAnnotation.Title)
                content.AppendLine("Annotation Name: " + textAnnotation.Name)
            End If

            Dim result As String = "GetParticularAnnotationInfo_out.txt"
            'Save to file.
            File.WriteAllText(result, content.ToString())

            pdf.Close()

            'Launch the file.
            DocumentViewer(result)
        End Sub

        Private Sub DocumentViewer(ByVal filename As String)
            Try
                System.Diagnostics.Process.Start(filename)
        Catch
        End Try
        End Sub
    End Class
End Namespace
