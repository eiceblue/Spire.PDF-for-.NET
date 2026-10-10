Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions

Namespace AddPdfLaunchAction
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document 
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page to the document
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Create a PDF Launch Action that will open a text file
            Dim launchAction As PdfLaunchAction = New PdfLaunchAction("..\\..\\..\\..\\..\\..\\Data\\text.txt",PdfFilePathType.Relative)

            ' Create a PDF Action Annotation with the PDF Launch Action
            Dim text As String = "Click here to open file"
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 13f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 13f ,PdfFontStyle.Regular, True)
            */

            Dim rect As RectangleF = New RectangleF(50, 50, 230, 15)
            page.Canvas.DrawString(text, font, PdfBrushes.ForestGreen, rect)
            rect = New RectangleF(90, 90, 230, 15)
            Dim annotation As PdfLinkAnnotation = New PdfLinkAnnotation(page, rect, launchAction)
            'Add the PDF Action Annotation to page
            PdfAnnotationCollection.Create(page).Add(annotation)

            Dim result As String = "AddPdfLaunchAction_out.pdf"

            ' Save the document
            doc.SaveToFile(result)

            'Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace
