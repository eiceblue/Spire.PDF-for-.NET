Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Graphics
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace SetFreeTextAnnotationStyle
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a new PDF document.
            Dim doc As PdfDocument = New PdfDocument()

            'Load the file from disk.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_4.pdf")

            'Get the first page of PDF file.
            Dim page As PdfPageBase = doc.Pages[0]

            'Initialize a PdfFreeTextAnnotation.
            Dim rect As RectangleF = New RectangleF(150, 120, 150, 30)
            Dim font As PdfFont = New PdfFont(PdfFontFamily.TimesRoman, 10)
            Dim textAnnotation As PdfFreeTextAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))

            'Specify content.
            textAnnotation.Contents = "\nFree Text Annotation Formatting"
            'Set free text annotation formatting and add it to page.
            textAnnotation.Border.Width = 1f
            textAnnotation.Border.Color = Color.Purple
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Circle
            textAnnotation.Color = Color.Green
            textAnnotation.StrokingOpacity = 0.8f
            textAnnotation.RefreshAppearances()
            PdfAnnotationCollection.Create(page).Add(textAnnotation)

            rect = New RectangleF(150, 200, 150, 40)
            font = New PdfFont(PdfFontFamily.Helvetica, 10)
            textAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))
            textAnnotation.Contents = "\nFree Text Annotation Formatting"
            textAnnotation.Border.Width = 1f
            textAnnotation.Border.Color = Color.LightGoldenrodYellow
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.RClosedArrow
            textAnnotation.Color = Color.LightPink
            textAnnotation.StrokingOpacity = 0.8f
            textAnnotation.RefreshAppearances()
            PdfAnnotationCollection.Create(page).Add(textAnnotation)

            rect = New RectangleF(150, 280, 280, 40)
            font = New PdfFont(PdfFontFamily.Helvetica, 10)
            textAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))
            textAnnotation.Contents = "\noHow to Set Free Text Annotation Formatting in Pdf file"
            textAnnotation.Border.Width = 1f
            textAnnotation.Border.Color = Color.Gray
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Circle
            textAnnotation.Color = Color.LightSkyBlue
            textAnnotation.StrokingOpacity = 0.8f
            textAnnotation.RefreshAppearances()
            PdfAnnotationCollection.Create(page).Add(textAnnotation)

            rect = New RectangleF(150, 360, 200, 40)
            font = New PdfFont(PdfFontFamily.Helvetica, 10)
            textAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))
            textAnnotation.Contents = "\nFree Text Annotation Formatting"
            textAnnotation.Border.Width = 1f
            textAnnotation.Border.Color = Color.Pink
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.RClosedArrow
            textAnnotation.Color = Color.LightGreen
            textAnnotation.StrokingOpacity = 0.8f
            textAnnotation.RefreshAppearances()
            PdfAnnotationCollection.Create(page).Add(textAnnotation)

            Dim result As String = "SetFreeTextAnnotationStyle.pdf"

            'Save the document
            doc.SaveToFile(result)
            doc.Close()

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
