Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf

Namespace ToEMF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file
			Dim input As String = "..\..\..\..\..\..\Data\Sample4.pdf"

			'open pdf document
			Dim doc As New PdfDocument(input)

			'save to emf files
			For i As Integer = 0 To doc.Pages.Count - 1
				Dim fileName As String = String.Format("Sample4-img-{0}.emf", i)
				Using image As Image = doc.SaveAsImage(i,Spire.Pdf.Graphics.PdfImageType.Metafile, 300, 300)
					image.Save(fileName, System.Drawing.Imaging.ImageFormat.Emf)
					Process.Start(fileName)
				End Using
			Next i
		End Sub
	End Class
End Namespace
