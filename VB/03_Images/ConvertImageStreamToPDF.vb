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
			' Create a pdf document with a section and page added.
			Dim pdf As New PdfDocument()
			Dim section As PdfSection = pdf.Sections.Add()
			Dim page As PdfPageBase = section.Pages.Add()

			' Create a FileStream object to read the imag file
			Dim fs As FileStream = File.OpenRead("..\..\..\..\..\..\Data\bg.png")
			' Read the image into Byte array
			Dim data(fs.Length - 1) As Byte
			fs.Read(data, 0, data.Length)
			' Create a MemoryStream object from image Byte array
			Dim ms As New MemoryStream(data)
			' Specify the image source as MemoryStream
			Dim image As PdfImage = PdfImage.FromStream(ms)

			'Set image display location and size in PDF
			'Calculate rate
			Dim widthFitRate As Single = (image.PhysicalDimension.Width \ page.Canvas.ClientSize.Width)
			Dim heightFitRate As Single = (image.PhysicalDimension.Height \ page.Canvas.ClientSize.Height)
			Dim fitRate As Single = Math.Max(widthFitRate, heightFitRate)
			'Calculate the size of image 
			Dim fitWidth As Single = image.PhysicalDimension.Width / fitRate
			Dim fitHeight As Single = image.PhysicalDimension.Height / fitRate
			'Draw image
			page.Canvas.DrawImage(image, 0, 30, fitWidth, fitHeight)

			'save and launch the file
			Dim output As String = "ConvertImageStreamToPDF.pdf"
			pdf.SaveToFile(output)
			Process.Start(output)
		End Sub
	End Class
End Namespace
