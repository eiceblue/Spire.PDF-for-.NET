Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ConvertImageStreamToPDF
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Create a section within the PDF document
            Dim section As PdfSection = pdf.Sections.Add()

            ' Add a new page to the section
            Dim page As PdfPageBase = section.Pages.Add()

            ' Open the image file as a FileStream
            Dim fs As FileStream = File.OpenRead("..\..\..\..\..\..\Data\bg.png")

            ' Read the image data into a byte array
            Dim data(CType(fs.Length - 1, Integer)) As Byte
            fs.Read(data, 0, data.Length)

            ' Create a MemoryStream from the image data
            Dim ms As New MemoryStream(data)

            ' Create a PdfImage from the MemoryStream
            Dim image As PdfImage = PdfImage.FromStream(ms)

            ' Calculate the fit rate for the image on the page
            Dim widthFitRate As Single = (image.PhysicalDimension.Width / page.Canvas.ClientSize.Width)
            Dim heightFitRate As Single = (image.PhysicalDimension.Height / page.Canvas.ClientSize.Height)
            Dim fitRate As Single = Math.Max(widthFitRate, heightFitRate)

            ' Calculate the dimensions of the image after fitting
            Dim fitWidth As Single = image.PhysicalDimension.Width / fitRate
            Dim fitHeight As Single = image.PhysicalDimension.Height / fitRate

            ' Draw the image on the page using the calculated dimensions
            page.Canvas.DrawImage(image, 0, 30, fitWidth, fitHeight)

            ' Specify the output file name for the PDF
            Dim output As String = "ConvertImageStreamToPDF.pdf"

            ' Save the PDF document to the specified file
            pdf.SaveToFile(output)

            ' Close the document
            pdf.Close()

            ' Launch the file
            Process.Start(output)
        End Sub
    End Class
End Namespace
