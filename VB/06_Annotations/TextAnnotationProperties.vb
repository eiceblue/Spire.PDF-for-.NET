Imports Spire.Pdf
Imports Spire.Pdf.Annotations

Namespace TextAnnotationProperties
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object 
            Dim pdf As New PdfDocument()

            ' Load an existing PDF document
            pdf.LoadFromFile("..\..\..\..\..\..\Data\FreeTextAnnotation.pdf")

            ' Get the first page of the PDF
            Dim firstPage As PdfPageBase = pdf.Pages(0)

            ' Create a new PdfDocument object to store the copied annotations
            Dim newPdf As New PdfDocument()

            ' Iterate through each annotation in the first page
            For Each annotation As PdfAnnotation In firstPage.Annotations.List

                ' Check if the annotation is a free text annotation
                If TypeOf annotation Is PdfFreeTextAnnotationWidget Then

                    ' Convert the annotation to a PdfFreeTextAnnotationWidget
                    Dim textAnnotation As PdfFreeTextAnnotationWidget = TryCast(annotation, PdfFreeTextAnnotationWidget)

                    ' Extract the bounds and text of the annotation
                    Dim rect = textAnnotation.Bounds
                    Dim text = textAnnotation.Text

                    ' Create a new page in the new PDF document with the same size as the original page
                    Dim newPage As PdfPageBase = newPdf.Pages.Add(firstPage.Size)

                    ' Create a new free text annotation in the new page
                    Dim newAnnotation As New PdfFreeTextAnnotation(rect)
                    newAnnotation.Text = text
                    newAnnotation.CalloutLines = textAnnotation.CalloutLines
                    newAnnotation.LineEndingStyle = textAnnotation.LineEndingStyle
                    newAnnotation.AnnotationIntent = PdfAnnotationIntent.FreeTextCallout
                    newAnnotation.RectangleDifferences = textAnnotation.RectangularDifferenceArray
                    newAnnotation.Color = textAnnotation.Color

                    ' Add the new annotation to the new page
                    newPage.Annotations.Add(newAnnotation)
                End If
            Next annotation

            ' Specify the output file path for the modified PDF
            Dim result As String = "CopyTextAnnotationProperties.pdf"

            ' Save the modified PDF document to the output file
            newPdf.SaveToFile(result)

            ' Close the PDF documents
            newPdf.Close()
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
