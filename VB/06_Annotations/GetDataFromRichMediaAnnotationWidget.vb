Imports System
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics

Namespace GetDataFromRichMediaAnnotationWidget
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a pdf instance
            Dim doc As PdfDocument = New PdfDocument()

            doc.LoadFromFile(@"..\..\..\..\..\..\Data\VideoAndAudio.pdf")

            Dim i As Integer = 0
            While i < doc.Pages.Count
                Dim page As PdfPageBase = doc.Pages[i]
                'Get the annotation collection of the page
                Dim ancoll As PdfAnnotationCollection = page.Annotations
                Dim j As Integer = 0
                While j < ancoll.Count
                    'Convert to Rich Media Annotations
                    Dim MediaWidget As PdfRichMediaAnnotationWidget = ancoll[j] as PdfRichMediaAnnotationWidget
                    'Obtain data from rich media annotations
                    Dim data As Byte[] = MediaWidget.RichMediaData
                    'Obtain names from rich media annotations
                    Dim embedFileName As String = MediaWidget.RichMediaName
                    'Save Data
                    File.WriteAllBytes(embedFileName, data)
                    'Launch the Pdf file
                    PDFDocumentViewer(embedFileName)
                Next
            Next
          
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub

    End Class
End Namespace
