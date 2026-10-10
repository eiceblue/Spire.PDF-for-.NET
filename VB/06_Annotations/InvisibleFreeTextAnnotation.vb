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

Namespace InvisibleFreeTextAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document.
            Dim doc As PdfDocument = New PdfDocument()

            ' Load the PDF file from the specified path.
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_4.pdf")

            ' Get the first page of the PDF document.
            Dim page As PdfPageBase = doc.Pages[0]

            ' Define a rectangle with specific coordinates and dimensions.
            Dim rect As RectangleF = New RectangleF(100, 120, 150, 30)

            ' Specify the font for the free text annotation.
            Dim font As PdfFont = New PdfFont(PdfFontFamily.TimesRoman, 10)

            ' Specify a default appearance for the free text annotation.
            Dim defaultAppearance As PdfDefaultAppearance = New PdfDefaultAppearance(font)

            ' Create a new free text annotation using the page, the rectangle and the default appearance.
            Dim FreetextAnnotation As PdfFreeTextAnnotation = New PdfFreeTextAnnotation(page, rect, defaultAppearance)

            ' Set the text content of the free text annotation.
            FreetextAnnotation.Contents = "Invisible Free Text Annotation"

            ' Set various properties for the free text annotation.
            FreetextAnnotation.Border.Width = 1f
            FreetextAnnotation.Border.Color = Color.Purple
            FreetextAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Circle
            FreetextAnnotation.Color = Color.Green
            FreetextAnnotation.StrokingOpacity = 0.8f

            ' Set flags to make the free text annotation invisible.
            FreetextAnnotation.Flags = PdfAnnotationFlags.Print | PdfAnnotationFlags.NoView

            ' Add the free text annotation to the page's annotations collection.
            PdfAnnotationCollection.Create(page).Add(FreetextAnnotation)

            ' Refresh the appearance of the free text annotation.
            FreetextAnnotation.RefreshAppearances()

            ' Define a new rectangle for the next free text annotation.
            rect = New RectangleF(100, 180, 150, 30)

            ' Create another free text annotation using the new rectangle.
            FreetextAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))

            ' Set properties for the second free text annotation.
            FreetextAnnotation.Contents = "Show Free Text Annotation"
            FreetextAnnotation.Border.Width = 1f
            FreetextAnnotation.Border.Color = Color.LightPink
            FreetextAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Circle
            FreetextAnnotation.Color = Color.LightGreen
            FreetextAnnotation.StrokingOpacity = 0.8f

            ' Add the second free text annotation to the page's annotations collection.
            PdfAnnotationCollection.Create(page).Add(FreetextAnnotation)

            ' Refresh the appearance of the second free text annotation.
            FreetextAnnotation.RefreshAppearances()

            ' Specify the filename for the output PDF document.
            Dim result As String = "InvisibleFreeTextAnnotation.pdf"

            ' Save the document with the specified filename.
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
