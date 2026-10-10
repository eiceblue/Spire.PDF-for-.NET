Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations
Namespace AddImageStamp
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Specify the file path for the input PDF document
            Dim input As String = @"../../../../../../Data/AddImageStamp.pdf"

            ' Create a new instance of PdfDocument
            Dim document As PdfDocument = New PdfDocument()

            ' Load the PDF document from the specified file path
            document.LoadFromFile(input)

            ' Get the first page of the document
            Dim page As PdfPageBase = document.Pages[0]

            'Create a rubber stamp annotation
            Dim loStamp As PdfRubberStampAnnotation = New PdfRubberStampAnnotation(page, New RectangleF(New PointF(0, 0), New SizeF(60, 60)))

            ' Load an image file to be used as the stamp
            Dim image As PdfImage = PdfImage.FromFile(@"../../../../../../Data/image stamp.jpg")

            ' Create a template with specific dimensions
            Dim template As PdfTemplate = New PdfTemplate(210, 210)

            'Draw a pdf image into pdf template
            template.Graphics.DrawImage(image, 60, 60)
            loStamp.Appearances.SetNormalAppearance(New PdfAppearance(template))

            'Add the rubber stamp annotation into pdf
            PdfAnnotationCollection.Create(page).Add(loStamp)

            ' Specify the file name for the modified PDF document
            Dim output As String = "AddImageStamp.pdf"

            ' Save the modified PDF document
            document.SaveToFile(output)

            'Launch the file
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
