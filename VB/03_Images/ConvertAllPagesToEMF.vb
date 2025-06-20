Imports System.Drawing.Imaging
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ConvertAllPagesToEMF
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

            ' Save each page as an EMF image
            For i As Integer = 0 To pdf.Pages.Count - 1
                ' Generate a file name for the image
                Dim fileName As String = String.Format("ToEMF-img-{0}.emf", i)

                ' Save the page as an image in EMF format with a resolution of 300x300 dpi
                Using image As Image = pdf.SaveAsImage(i, PdfImageType.Metafile, 300, 300)
                    image.Save(fileName, ImageFormat.Emf)
                End Using
            Next i

            ' Close the document
            pdf.Close()
        End Sub
    End Class
End Namespace
