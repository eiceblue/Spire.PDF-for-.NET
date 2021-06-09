Imports System.Drawing.Imaging
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace PageToPNG
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

			'Convert a particular page to png
			'Set page index and image name
			Dim pageIndex As Integer = 1
			Dim fileName As String = "PageToPNG.png"
			'Save page to image
			Using image As Image = pdf.SaveAsImage(pageIndex, 300, 300)
				image.Save(fileName, ImageFormat.Png)
			End Using

			pdf.Close()
		End Sub

	End Class
End Namespace
