Imports System.Drawing.Imaging
Imports Spire.Pdf

Namespace PageToTIFF
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
            Dim fileName As String = "PageToTIFF.tiff"

            ' Join multiple TIFF images into a single TIFF file with LZW compression
            JoinTiffImages(pdf.SaveAsImage(pageIndex), fileName, EncoderValue.CompressionLZW)

            ' Close the PdfDocument
            pdf.Close()
        End Sub

        Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
            ' Get all available image encoders
            Dim encoders() As ImageCodecInfo = ImageCodecInfo.GetImageEncoders()

            ' Iterate through the encoders and find the one with the matching mimeType
            For j As Integer = 0 To encoders.Length - 1
                If encoders(j).MimeType = mimeType Then
                    Return encoders(j)
                End If
            Next j

            ' If no matching encoder is found, throw an exception indicating that the mimeType was not found
            Throw New Exception(mimeType & " mime type not found in ImageCodecInfo")
        End Function
        Public Sub JoinTiffImages(ByVal image As Image, ByVal outFile As String, ByVal compressEncoder As EncoderValue)
            ' Define the encoder and its parameters
            Dim enc As Encoder = Encoder.SaveFlag
            Dim ep As New EncoderParameters(2)
            ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.MultiFrame))
            ep.Param(1) = New EncoderParameter(Encoder.Compression, CLng(compressEncoder))

            ' Get the ImageCodecInfo for the "image/tiff" mimeType
            Dim info As ImageCodecInfo = GetEncoderInfo("image/tiff")

            ' Save the image as a TIFF file using the specified encoder info and parameters
            image.Save(outFile, info, ep)
        End Sub
    End Class
End Namespace
