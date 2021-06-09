Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace ImageWatermarkFirst
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            'Create a pdf document and load file from disk
            Dim doc As New PdfDocument()
            doc.LoadFromFile("..\..\..\..\..\..\Data\ImageWaterMark.pdf")

            'Get the first page
            Dim page As PdfPageBase = doc.Pages(0)

            'Load image
            Dim img As Image = Image.FromFile("..\..\..\..\..\..\Data\Background.png")

            'Set background image
            page.BackgroundImage = img

            'Save pdf file
            doc.SaveToFile("ImageWaterMark.pdf")
            doc.Close()

            'Launch the Pdf file
            PDFDocumentViewer("ImageWaterMark.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
