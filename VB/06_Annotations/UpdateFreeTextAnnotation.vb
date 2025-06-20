Imports Spire.Pdf
Imports Spire.Pdf.Annotations

Namespace UpdateFreeTextAnnotation
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load an existing PDF file
            pdf.LoadFromFile("..\..\..\..\..\..\Data\UpdateFreeTextAnnotation.pdf")

            ' Get the collection of annotations from the first page
            Dim annotations As PdfAnnotationCollection = pdf.Pages(0).Annotations

            ' Iterate through each annotation in the collection
            For Each annotaion As PdfFreeTextAnnotationWidget In annotations
                ' Set the color of the annotation to YellowGreen
                annotaion.Color = Color.YellowGreen
            Next annotaion

            ' Specify the output file name
            Dim result As String = "UpdateFreeTextAnnotation_out.pdf"

            ' Save the modified PDF document to the specified file
            pdf.SaveToFile(result)

            ' Close the PDF document
            pdf.Close()

            ' Launch the Pdf file
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
