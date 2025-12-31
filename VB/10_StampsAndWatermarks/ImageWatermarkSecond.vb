Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Namespace ImageWatermarkSecond
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument
			Dim doc As New PdfDocument()

			' Load the PDF template file from a specified path
			doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

			' Create an Image object from the specified image file
			Dim image As Image = image.FromFile("../../../../../../Data/E-logo.png")

			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim fs As System.IO.FileStream = System.IO.File.OpenRead(TestUtil.DataPath & "Demo/E-logo.png")
			'Dim pdfImage As PdfImage = pdfImage.FromStream(fs)
			' =============================================================================

			' Get the width and height of the image
			Dim width As Integer = image.Width
			Dim height As Integer = image.Height

			' Set the scaling factor for the image
			Dim schale As Single = 1.5F

			' Calculate the new size of the image based on the scaling factor
			Dim size As New Size(CInt(Fix(width * schale)), CInt(Fix(height * schale)))

			' Create a new Bitmap object with the scaled image
			Dim schaleImage As New Bitmap(image, size)

			' Convert the scaled image to a PdfImage object
			Dim pdfImage As PdfImage = PdfImage.FromImage(schaleImage)

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Set the position where the image will be drawn on the page
			Dim position As New PointF(160, 260)

			' Save the current state of the canvas
			page.Canvas.Save()

			' Set the transparency of the canvas
			page.Canvas.SetTransparency(0.5F, 0.5F, PdfBlendMode.Multiply)

			' Draw the image on the page canvas
			page.Canvas.DrawImage(pdfImage, position)

			' Restore the previous state of the canvas
			page.Canvas.Restore()

			' Specify the output file name for the modified PDF document
			Dim output As String = "ImageWatermarkSecondApproach_out.pdf"

			' Save the modified PDF document to the specified output file
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the document
			doc.Close()

			' Launch the Pdf file
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
