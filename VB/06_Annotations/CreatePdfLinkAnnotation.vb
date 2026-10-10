Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Actions
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

Namespace CreatePdfLinkAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a new object of PdfDocument.
            Dim doc As PdfDocument = New PdfDocument()

            'Add a page to it.
            Dim page As PdfPageBase = doc.Pages.Add()

            'Declare two parameters that will be passed to the constructor of PdfFileLinkAnnotation class.
            Dim rect As RectangleF = New RectangleF(40, 80, 250, 35)
            Dim filePath As String = @"..\..\..\..\..\..\Data\Template_Pdf_3.pdf"

            'Create a file link annotation based on the two parameters and add the annotation to the new page.
            Dim link As PdfLinkAnnotation = New PdfLinkAnnotation(page, rect, New PdfLaunchAction(filePath,PdfFilePathType.Relative))
            PdfAnnotationCollection.Create(page).Add(link)
            Dim font As PdfFont = New PdfFont(PdfFontFamily.Helvetica, 15)
            'Create a free text annotation based on the same RectangleF, specifying the content.
            Dim text As PdfFreeTextAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))
            text.Contents = "Click here! This Is a link annotation."

            PdfAnnotationCollection.Create(page).Add(text)

            Dim result As String = "CreatePdfLinkAnnotation.pdf"

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
