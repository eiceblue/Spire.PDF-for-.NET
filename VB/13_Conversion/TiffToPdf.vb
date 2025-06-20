Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.Drawing.Imaging
Imports System.IO

Namespace TiffToPdf
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object using the Using statement
			Using pdfDocument As New PdfDocument()
				' Load the Tiff file
				Dim tiffImage As Image = Image.FromFile("..\..\..\..\..\..\Data\TiffToPdf.tiff")

				' Split the Tiff image into multiple images
				Dim images() As Image = SplitTIFFImage(tiffImage)

				' Loop through each image and add it to a PDF page
				For i As Integer = 0 To images.Length - 1
					Dim pdfImg As PdfImage = PdfImage.FromImage(images(i))
					Dim page As PdfPageBase = pdfDocument.Pages.Add()

					' Scale the image
					Dim width As Single = pdfImg.Width * 0.7F
					Dim height As Single = pdfImg.Height * 0.7F
					Dim x As Single = (page.Canvas.ClientSize.Width - width) / 2

					' Draw the image on the page
					page.Canvas.DrawImage(pdfImg, x, 0, width, height)
				Next i

				Dim result As String = "TiffToPdf-result.pdf"

				' Save the PDF document
				pdfDocument.SaveToFile(result)

				' Launch the result file
				PDFDocumentViewer(result)
			End Using
		End Sub

		' Function to split a TIFF image into multiple images
		Public Shared Function SplitTIFFImage(ByVal tiffImage As Image) As Image()
			Dim frameCount As Integer = tiffImage.GetFrameCount(FrameDimension.Page)
			Dim images(frameCount - 1) As Image
			Dim objGuid As Guid = tiffImage.FrameDimensionsList(0)
			Dim objDimension As New FrameDimension(objGuid)

			' Loop through each frame in the TIFF image
			For i As Integer = 0 To frameCount - 1
				tiffImage.SelectActiveFrame(objDimension, i)

				' Convert the frame to an image and store it in the array
				Using ms As New MemoryStream()
					tiffImage.Save(ms, ImageFormat.Tiff)
					images(i) = Image.FromStream(ms)
				End Using
			Next i

			Return images
		End Function

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
