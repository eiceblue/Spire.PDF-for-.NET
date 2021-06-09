Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text

Namespace TiffToPdf
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			 Using pdfDocument As New PdfDocument()
				 'Load Tiff file
				Dim tiffImage As Image = Image.FromFile("..\..\..\..\..\..\Data\TiffToPdf.tiff")
				'Split Tiff to images
				Dim images() As Image = SplitTIFFImage(tiffImage)
				For i As Integer = 0 To images.Length - 1
					Dim pdfImg As PdfImage = PdfImage.FromImage(images(i))
					Dim page As PdfPageBase = pdfDocument.Pages.Add()
					'Scale image
					Dim width As Single = pdfImg.Width * 0.7f
					Dim height As Single = pdfImg.Height * 0.7f
					Dim x As Single = (page.Canvas.ClientSize.Width - width) / 2
					'Draw imge on the page
					page.Canvas.DrawImage(pdfImg, x, 0, width, height)
				Next i

				Dim result As String = "TiffToPdf-result.pdf"
				'Save to file
				pdfDocument.SaveToFile(result)

				'Launch the result file
				PDFDocumentViewer(result)
			 End Using
		End Sub
		Public Shared Function SplitTIFFImage(ByVal tiffImage As Image) As Image()
			Dim frameCount As Integer = tiffImage.GetFrameCount(FrameDimension.Page)
			Dim images(frameCount - 1) As Image
			Dim objGuid As Guid = tiffImage.FrameDimensionsList(0)
			Dim objDimension As New FrameDimension(objGuid)
			For i As Integer = 0 To frameCount - 1
				tiffImage.SelectActiveFrame(objDimension, i)
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
