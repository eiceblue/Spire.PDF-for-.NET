Imports Spire.Pdf
Imports System.IO
Imports System.Text
Imports Spire.Pdf.Annotations

Namespace GetAllAnnotationsFromPage
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load a PDF file from the specified path
            pdf.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_3.pdf")

            ' Get the collection of annotations on the first page
            Dim annotations As PdfAnnotationCollection = pdf.Pages(0).Annotations

            ' Create a StringBuilder to store the annotation information
            Dim content As New StringBuilder()

            ' Iterate through each annotation in the collection
            For i As Integer = 0 To annotations.Count - 1

                ' Check if the current annotation is a PopupAnnotationWidget
                If TypeOf annotations(i) Is PdfPopupAnnotationWidget Then

                    ' Skip the iteration if it is a PopupAnnotationWidget
                    Continue For
                End If

                ' Append annotation information header
                content.AppendLine("Annotation information: ")

                ' Append the annotation text
                content.AppendLine("Text: " & annotations(i).Text)

                ' Get the modified date of the annotation and append it
                Dim modifiedDate As String = annotations(i).ModifiedDate.ToString()
                content.AppendLine("ModifiedDate: " & modifiedDate)
            Next i

            ' Specify the result file name
            Dim result As String = "Result-GetAllAnnotationsFromPage.txt"

            ' Write the annotation information to the result file
            File.WriteAllText(result, content.ToString())

            ' Close the PDF document
            pdf.Close()

            ' Launch the file
            PDFDocumentViewer(result)
        End Sub

        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub
    End Class
End Namespace
