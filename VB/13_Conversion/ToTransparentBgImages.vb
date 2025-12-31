Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.Drawing.Imaging
Imports System.IO

Namespace ToTransparentBgImages
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified path
			doc.LoadFromFile("..\..\..\..\..\..\Data\ToTransparentBackgroundImages.pdf")

			' Set the background to transparent
			doc.ConvertOptions.SetPdfToImageOptions(0)

			' Convert the first page to image
			Dim image As Image = doc.SaveAsImage(0, PdfImageType.Bitmap)

			' Specify the output file path for the image
			Dim output As String = "ToTransparentBackgroundImages_output.png"

			' Save the image to a PNG file
			image.Save(output, ImageFormat.Png)
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Using image = doc.SaveAsImage(0, PdfImageType.Bitmap)
			'	' SkiaSharp.SKImage image = doc.SaveAsImage(0, Spire.Pdf.Graphics.PdfImageType.Bitmap);
			'	Using fileStream As New FileStream(outputFile, FileMode.Create, FileAccess.Write)
			'		' image.Encode(SkiaSharp.SKEncodedImageFormat.Bmp, 100).SaveTo(fileStream);
			'		image.CopyTo(fileStream)
			'		fileStream.Flush()
			'	End Using
			'End Using
			' =============================================================================

			' Close the PDF document
			doc.Close()

			' Launch the file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
