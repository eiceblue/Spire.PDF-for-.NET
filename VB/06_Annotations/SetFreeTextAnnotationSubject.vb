Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics

Namespace SetFreeTextAnnotationSubject
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object 
            Dim doc As New PdfDocument()

            ' Load an existing PDF document
            doc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_4.pdf")

            ' Get the first page of the PDF
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a rectangle for the annotation position and size
            Dim rect As New RectangleF(150, 120, 150, 30)

            ' Create a free text annotation with the specified rectangle
            Dim textAnnotation As New PdfFreeTextAnnotation(rect)

            ' Specify the content of the annotation
            textAnnotation.Text = vbLf & "Set free text annotation subject"

            ' Set the subject of the annotation
            textAnnotation.Subject = "SubjectTest"

            ' Set the font of the annotation
            Dim font As New PdfFont(PdfFontFamily.TimesRoman, 10)
            textAnnotation.Font = font

            ' Set the border of the annotation
            Dim border As New PdfAnnotationBorder(1.0F)
            textAnnotation.Border = border

            ' Set the border color of the annotation
            textAnnotation.BorderColor = Color.Purple

            ' Set the line ending style of the annotation
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.Circle

            ' Set the color of the annotation
            textAnnotation.Color = Color.Green

            ' Set the opacity of the annotation
            textAnnotation.Opacity = 0.8F

            ' Add the annotation to the page
            page.Annotations.Add(textAnnotation)

            ' Specify the output file path for the modified PDF
            Dim result As String = "SetFreeTextAnnotationSubject_out.pdf"

            ' Save the modified PDF document to the output file
            doc.SaveToFile(result)

            ' Close the PDF document
            doc.Close()

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
