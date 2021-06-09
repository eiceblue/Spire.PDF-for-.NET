Imports System.Drawing.Imaging
Imports Spire.Pdf

Namespace PageToTIFF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim file As String = "..\..\..\..\..\..\Data\PageToImage.pdf"

			'Open pdf document
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(file)

			'Convert a particular page to tiff
			'Set page index and image name
			Dim pageIndex As Integer = 1
			Dim fileName As String = "PageToTIFF.tiff"
			JoinTiffImages(pdf.SaveAsImage(pageIndex), fileName, EncoderValue.CompressionLZW)
			pdf.Close()
		End Sub

		Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
			'Get encoder information of all image type
			Dim encoders() As ImageCodecInfo = ImageCodecInfo.GetImageEncoders()
			'Find the information of tiff type
			For j As Integer = 0 To encoders.Length - 1
				If encoders(j).MimeType = mimeType Then
					Return encoders(j)
				End If
			Next j
			Throw New Exception(mimeType & " mime type not found in ImageCodecInfo")
		End Function
		Public Shared Sub JoinTiffImages(ByVal image As Image, ByVal outFile As String, ByVal compressEncoder As EncoderValue)
			'Use the save encoder
			Dim enc As Encoder = Encoder.SaveFlag
			Dim ep As New EncoderParameters(2)
			ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.MultiFrame))
			ep.Param(1) = New EncoderParameter(Encoder.Compression, CLng(compressEncoder))
			'Get the information of tiff type
			Dim info As ImageCodecInfo = GetEncoderInfo("image/tiff")
			'Save to image
			image.Save(outFile, info, ep)
		End Sub
	End Class
End Namespace
