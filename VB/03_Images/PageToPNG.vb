Imports System.Drawing.Imaging
Imports Spire.Pdf

Namespace PageToPNG
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim file As String = "..\..\..\..\..\..\Data\PageToImage.pdf"

            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified file
            pdf.LoadFromFile(file)

            ' Specify the page index to convert
            Dim pageIndex As Integer = 1

            ' Specify the output file name and format
            Dim fileName As String = "PageToPNG.png"

            ' Use a using statement to ensure proper disposal of the created image
            Using image As Image = pdf.SaveAsImage(pageIndex, 300, 300)
                ' Save the image as PNG format
                image.Save(fileName, ImageFormat.Png)
            End Using

            ' Close the PdfDocument
            pdf.Close()
        End Sub
    End Class
End Namespace
