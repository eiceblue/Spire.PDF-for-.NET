Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace Decryption
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim encryptedPdf As String = "..\..\..\..\..\..\Data\Encrypted.pdf"
            Dim doc As New PdfDocument()
            doc.LoadFromFile(encryptedPdf, "test")

			'extract image
			Dim image As Image = doc.Pages(0).ImagesInfo(0).Image

			doc.Close()

			'Save image file.
			image.Save("Wikipedia_Science.png", System.Drawing.Imaging.ImageFormat.Png)

			'Launching the image file.
			ImageViewer("Wikipedia_Science.png")
		End Sub

		Private Sub ImageViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
