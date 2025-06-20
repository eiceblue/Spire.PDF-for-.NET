Imports Spire.Pdf
Imports System.Drawing.Imaging

Namespace ToTiff
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the input PDF file
			Dim input As String = "..\..\..\..\..\..\Data\ToTiff.pdf"

			' Create a new PdfDocument object
			Dim document As New PdfDocument()

			' Load the PDF document from the specified file path
			document.LoadFromFile(input)

			' Convert each page of the PDF to images
			Dim images(document.Pages.Count - 1) As Image
			For i As Integer = 0 To document.Pages.Count - 1
				' Use the document.SaveAsImage() method to save the PDF page as an image
				images(i) = document.SaveAsImage(i)
			Next i

			' Specify the output file name for the TIFF file
			Dim outFile As String = "result.tiff"

			' Specify the compression type for the TIFF file
			Dim compressEncoder As EncoderValue = EncoderValue.CompressionLZW

			' Join the TIFF images into a single multi-page TIFF file
			JoinTiffImages(images, outFile, compressEncoder)
		End Sub

        Private Shared Function SaveAsImage(ByVal document As PdfDocument) As Image()
            Dim images(document.Pages.Count - 1) As Image
            For i As Integer = 0 To document.Pages.Count - 1
                ' Use the document.SaveAsImage() method to save the PDF page as an image
                images(i) = document.SaveAsImage(i)
            Next i
            Return images
        End Function

        Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
            Dim encoders() As ImageCodecInfo = ImageCodecInfo.GetImageEncoders()
            For j As Integer = 0 To encoders.Length - 1
                If encoders(j).MimeType = mimeType Then
                    Return encoders(j)
                End If
            Next j
            Throw New Exception(mimeType & " mime type not found in ImageCodecInfo")
        End Function

        Public Shared Sub JoinTiffImages(ByVal images() As Image, ByVal outFile As String, ByVal compressEncoder As EncoderValue)
            ' Use the save encoder
            Dim enc As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.SaveFlag
            Dim ep As New EncoderParameters(2)
            ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.MultiFrame))
            ep.Param(1) = New EncoderParameter(System.Drawing.Imaging.Encoder.Compression, CLng(compressEncoder))
            Dim pages As Image = images(0)
            Dim frame As Integer = 0
            Dim info As ImageCodecInfo = GetEncoderInfo("image/tiff")
            For Each img As Image In images
                If frame = 0 Then
                    pages = img
                    ' Save the first frame
                    pages.Save(outFile, info, ep)
                Else
                    ' Save the intermediate frames
                    ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.FrameDimensionPage))
                    pages.SaveAdd(img, ep)
                End If
                If frame = images.Length - 1 Then
                    ' Flush and close
                    ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.Flush))
                    pages.SaveAdd(ep)
                End If
                frame += 1
            Next img
        End Sub
    End Class
End Namespace
