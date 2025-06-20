Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System.IO
Imports System.Text

Namespace GetParticularAnnotationInfo
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object 
            Dim pdf As New PdfDocument()
            pdf.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_3.pdf")

            ' Get the collection of annotations from the first page of the PDF
            Dim annotations As PdfAnnotationCollection = pdf.Pages(0).Annotations

            ' Create a StringBuilder to store the annotation information
            Dim content As New StringBuilder()

            ' Check if the first annotation is a text annotation
            If TypeOf annotations(0) Is PdfTextAnnotationWidget Then
                ' Cast the annotation as a PdfTextAnnotationWidget
                Dim textAnnotation As PdfTextAnnotationWidget = TryCast(annotations(0), PdfTextAnnotationWidget)

                ' Retrieve and append the annotation's text, modified date, author, and name to the StringBuilder
                content.AppendLine("Annotation text: " & textAnnotation.Text)
                content.AppendLine("Annotation ModifiedDate: " & textAnnotation.ModifiedDate.ToString())
                content.AppendLine("Annotation author: " & textAnnotation.Author)
                content.AppendLine("Annotation Name: " & textAnnotation.Name)
            End If

            ' Specify the output file path for the annotation information
            Dim result As String = "GetParticularAnnotationInfo_out.txt"

            ' Write the contents of the StringBuilder to the output file
            File.WriteAllText(result, content.ToString())

            ' Close the PDF document
            pdf.Close()

            ' Launch the file
            DocumentViewer(result)
        End Sub
        Private Sub DocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub
    End Class
End Namespace
