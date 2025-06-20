Imports System.Drawing.Imaging
Imports Spire.Pdf

Namespace ConvertAllPagesToPNG
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            Dim file As String = "..\..\..\..\..\..\Data\ToImage.pdf"

            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load the PDF document from file
            pdf.LoadFromFile(file)

            ' Save each page as a PNG image
            For i As Integer = 0 To pdf.Pages.Count - 1
                ' Generate a file name for the image
                Dim fileName As String = String.Format("ToPNG-img-{0}.png", i)

                ' Save the page as an image in PNG format with a resolution of 300x300 dpi
                Using image As Image = pdf.SaveAsImage(i, 300, 300)
                    image.Save(fileName, ImageFormat.Png)
                End Using
            Next i

            ' Close the PDF document
            pdf.Close()
        End Sub

    End Class
End Namespace
