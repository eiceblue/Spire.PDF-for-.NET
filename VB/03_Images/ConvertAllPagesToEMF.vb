Imports System.Drawing.Imaging
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ConvertAllPagesToEMF
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
				Dim fileName As String = String.Format("ToEMF-img-{0}.emf", i)
				'Save page to images in metafile type
				Using image As Image = pdf.SaveAsImage(i, PdfImageType.Metafile, 300, 300)
					image.Save(fileName, ImageFormat.Emf)
				End Using
			Next i

			pdf.Close()
		End Sub
	End Class
End Namespace
