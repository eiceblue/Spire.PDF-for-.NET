Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Imports Spire.Pdf

Namespace Extraction
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\Sample2.pdf")

			Dim buffer As New StringBuilder()
			Dim images As IList(Of Image) = New List(Of Image)()

			For Each page As PdfPageBase In doc.Pages
				buffer.Append(page.ExtractText())
				For Each image As Image In page.ExtractImages()
					images.Add(image)
				Next image
			Next page

			doc.Close()

			'save text
			Dim fileName As String = "TextInPdf.txt"
			File.WriteAllText(fileName, buffer.ToString())

			'save image
			Dim index As Integer = 0
			For Each image As Image In images
				Dim imageFileName As String = String.Format("Image-{0}.png", index)
				index += 1
				image.Save(imageFileName, ImageFormat.Png)
			Next image

			'Launching the Pdf file.
			PDFDocumentViewer(fileName)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
