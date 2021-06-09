Imports System.Drawing.Imaging
Imports Spire.Pdf


Namespace ConvertAllPagesToPNG
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim file As String = "..\..\..\..\..\..\Data\ToImage.pdf"

			'Open pdf document
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(file)

			'Save to images
			For i As Integer = 0 To pdf.Pages.Count - 1
				Dim fileName As String = String.Format("ToPNG-img-{0}.png", i)
				Using image As Image = pdf.SaveAsImage(i, 300, 300)
					image.Save(fileName, ImageFormat.Png)
				End Using
			Next i

			pdf.Close()
		End Sub

	End Class
End Namespace
