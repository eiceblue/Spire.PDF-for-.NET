Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

Namespace SetFreeTextAnnotationAlignment
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PdfDocument object
            Dim pdf As PdfDocument = New PdfDocument()

            ' Add a new page to the document and assign it to the 'page' variable
            Dim page As PdfPageBase = pdf.Pages.Add()

            ' Define a rectangle with specific coordinates and dimensions
            Dim rect As RectangleF = New RectangleF(40, 340, 200, 80)

            ' Create a new PdfFont object using the Times Roman font family and a font size of 20
            Dim font As PdfFont = New PdfFont(PdfFontFamily.TimesRoman, 20)

            ' Create a new PdfFreeTextAnnotation object and pass the rectangle as a parameter
            Dim textAnnotation As PdfFreeTextAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))

            ' Set the text content of the free text annotation
            textAnnotation.Contents = "\n  Spire.PDF"

            ' Assign the created border to the border property of the free text annotation
            textAnnotation.Border.Width = 1f

            ' Set the border color of the free text annotation to gray
            textAnnotation.Border.Color = Color.Gray

            ' Set the line ending style of the free text annotation to slash
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Slash

            ' Set the background color of the free text annotation to light blue
            textAnnotation.Color = Color.LightBlue

            ' Set the opacity of the free text annotation to 0.8
            textAnnotation.StrokingOpacity = 0.8f

            ' Set the alignment of the text within the free text annotation to center
            Dim builder As PdfFreeTextAppearanceBuilder = New PdfFreeTextAppearanceBuilder(textAnnotation)
            Dim format As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Center)
            builder.SetStringFormat(format)
            textAnnotation.Appearances.SetNormalAppearance(builder.Build())

            ' Add the free text annotation to the annotations collection of the page
            PdfAnnotationCollection.Create(page).Add(textAnnotation)

            ' Specify the output file path for the modified PDF document
            Dim result As String = "SetFreeTextAnnotationAlignment.pdf"

            ' Save the modified document to the specified file path
            pdf.SaveToFile(result)
            pdf.Dispose()

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
