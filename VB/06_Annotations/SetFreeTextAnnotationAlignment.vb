Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics

Namespace SetFreeTextAnnotationAlignment
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object 
            Dim pdf As New PdfDocument()

            ' Add a new page to the document
            Dim page As PdfPageBase = pdf.Pages.Add()

            ' Define the rectangle for the free text annotation
            Dim rect As New RectangleF(0, 300, 200, 80)

            ' Create a new PdfFreeTextAnnotation with the specified rectangle
            Dim textAnnotation As New PdfFreeTextAnnotation(rect)

            ' Set the text content of the free text annotation
            textAnnotation.Text = vbLf & "  Spire.PDF"

            ' Create a border for the annotation
            Dim border As New PdfAnnotationBorder(1.0F)

            ' Create a font for the annotation
            Dim font As New PdfFont(PdfFontFamily.TimesRoman, 20)

            ' Set the font and border properties of the free text annotation
            textAnnotation.Font = font
            textAnnotation.Border = border

            ' Set the border color of the free text annotation to gray
            textAnnotation.BorderColor = Color.Gray

            ' Set the line ending style of the free text annotation to a slash
            textAnnotation.LineEndingStyle = PdfLineEndingStyle.Slash

            ' Set the color of the free text annotation to light blue
            textAnnotation.Color = Color.LightBlue

            ' Set the opacity of the free text annotation to 0.8
            textAnnotation.Opacity = 0.8F

            ' Set the text alignment of the free text annotation to center
            textAnnotation.TextAlignment = PdfAnnotationTextAlignment.Center

            ' Add the free text annotation to the page's annotations widget
            page.Annotations.Add(textAnnotation)

            ' Specify the output file path for the modified PDF
            Dim output As String = "SetFreeTextAnnotationAlignment.pdf"

            ' Save the modified PDF document to the output file
            pdf.SaveToFile(output)

            ' Close the document
            pdf.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub
    End Class
End Namespace
