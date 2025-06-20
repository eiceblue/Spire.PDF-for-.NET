Imports System.Drawing.Imaging
Imports Spire.Pdf

Namespace ToImage
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the file path of the PDF document to be loaded
            Dim file As String = "..\..\..\..\..\..\Data\ToImage.pdf"

            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified file path
            doc.LoadFromFile(file)

            ' Save each page of the PDF document as an image
            For i As Integer = 0 To doc.Pages.Count - 1
                ' Generate a unique file name for each image
                Dim fileName As String = String.Format("ToImage-img-{0}.png", i)

                ' Convert the page to an image and save it
                Using image As Image = doc.SaveAsImage(i, 300, 300)
                    image.Save(fileName, ImageFormat.Png)

                    ' Open the saved image using the default associated application
                    Process.Start(fileName)
                End Using
            Next i

            ' Close the PDF document
            doc.Close()
        End Sub
    End Class
End Namespace
