Imports System.Drawing.Imaging
Imports Spire.Pdf


Namespace ConvertToBMP
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the file path of the PDF to be converted to images
            Dim file As String = "..\..\..\..\..\..\Data\ToImage.pdf"

            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified file
            pdf.LoadFromFile(file)

            ' Iterate through each page of the PDF document
            For i As Integer = 0 To pdf.Pages.Count - 1
                ' Generate a unique file name for each image
                Dim fileName As String = String.Format("ToBMP-img-{0}.bmp", i)

                ' Convert the current page of the PDF to an image with a resolution of 300x300 dpi
                Using image As Image = pdf.SaveAsImage(i, 300, 300)
                    ' Save the image in BMP format with the specified file name
                    image.Save(fileName, ImageFormat.Bmp)
                End Using

                ' =============================================================================
                ' Use the following code for netstandard dlls
                ' =============================================================================
                'Using image = pdf.SaveAsImage(i)
                '    Dim filename As String = String.Format(outputFile & i & ".bmp")
                '    Using fileStream As New System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                '        image.CopyTo(fileStream)
                '        fileStream.Flush()
                '    End Using
                'End Using
                ' =============================================================================
            Next i

            ' Close the PdfDocument object
            pdf.Close()
        End Sub
    End Class
End Namespace
