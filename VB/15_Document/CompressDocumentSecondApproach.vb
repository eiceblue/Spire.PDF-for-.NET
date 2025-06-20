Imports Spire.Pdf.Conversion.Compression

Namespace CompressDocumentSecondApproach
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of the PdfCompressor class and specify the path of the PDF file to be compressed
			Dim compressor As New PdfCompressor("..\..\..\..\..\..\Data\CompressDocument.pdf")

			' Alternatively, you can provide the password for an encrypted PDF file
			'PdfCompressor compressor = new PdfCompressor("input.pdf", "password");

			' Enable resizing of images during compression
			compressor.Options.ImageCompressionOptions.ResizeImages = True

			' Set the image quality to low
			compressor.Options.ImageCompressionOptions.ImageQuality = ImageQuality.Low

			' Compress the document and save it to a new file named "CompressDocument_result.pdf"
			compressor.CompressToFile("CompressDocument_result.pdf")

			' Alternatively, you can compress the document and save it to a memory stream
			'MemoryStream ms = new MemoryStream();
			'compressor.CompressToStream(ms);

			' View the pdf document
			PDFDocumentViewer("CompressDocument_result.pdf")
		End Sub


		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
