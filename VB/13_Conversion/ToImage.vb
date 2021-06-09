Imports Spire.Pdf

Namespace ToImage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim file As String = "..\..\..\..\..\..\Data\ToImage.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			'Save to images
			For i As Integer = 0 To doc.Pages.Count - 1
				Dim fileName As String = String.Format("ToImage-img-{0}.png", i)
				Using image As Image = doc.SaveAsImage(i,300,300)
					image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png)
					Process.Start(fileName)
				End Using
			Next i

			doc.Close()
		End Sub
	End Class
End Namespace
