Imports Spire.Pdf

Namespace ImageWatermarkFirst
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load an existing PDF file from the specified path
            doc.LoadFromFile("..\..\..\..\..\..\Data\ImageWaterMark.pdf")

            ' Get the first page of the loaded document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a new Image object from the specified image file path
            Dim img As Image = Image.FromFile("..\..\..\..\..\..\Data\Background.png")

            ' Set the background image of the page to the loaded image
            page.BackgroundImage = img

            ' Save the modified document to a new file named "ImageWaterMark.pdf"
            doc.SaveToFile("ImageWaterMark.pdf")

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
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
