Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Graphics
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace AddDateTimeStamp
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Load a PDF document from disk
            Dim document As PdfDocument = New PdfDocument()
            document.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

            ' Get the first page of the document
            Dim page As PdfPageBase = document.Pages[0]

            ' Set the font and brush for the text
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Regular), True)
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, True)
            */

            Dim brush As PdfSolidBrush = New PdfSolidBrush(Color.Blue)

            ' Generate a string representing the current date and time
            Dim timeString As String = DateTime.Now.ToString("MM/dd/yy hh:mm:ss")

            'Create a template and rectangle, draw the string
            Dim template As PdfTemplate = New PdfTemplate(140, 15)
            Dim rect As RectangleF = New RectangleF(New PointF(page.ActualSize.Width - template.Width - 10, page.ActualSize.Height - template.Height - 10), template.Size)
            template.Graphics.DrawString(timeString, font, brush, New PointF(0, 0))

            'Create stamp annoation
            Dim stamp As PdfRubberStampAnnotation = New PdfRubberStampAnnotation(page, rect)
            stamp.Appearances.SetNormalAppearance(New PdfAppearance(template))

            'Draw stamp into page
            PdfAnnotationCollection.Create(page).Add(stamp)

            ' Specify the file name for the modified PDF document
            Dim output As String = "AddDateTimeStamp_result.pdf"

            ' Save the modified document to the specified file path in PDF format
            document.SaveToFile(output, FileFormat.PDF)

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
