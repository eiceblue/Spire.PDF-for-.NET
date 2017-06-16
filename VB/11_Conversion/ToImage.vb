Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf

Namespace ToImage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            'pdf file
            Dim file As String = "..\..\..\..\..\..\Data\Sample4.pdf"

            'open pdf document
            Dim doc As New PdfDocument()
            doc.LoadFromFile(file)

            'save to images
            For i As Integer = 0 To doc.Pages.Count - 1
                Dim fileName As String = String.Format("Sample4-img-{0}.png", i)
                Using image As Image = doc.SaveAsImage(i)
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png)
                    System.Diagnostics.Process.Start(fileName)
                End Using
            Next
            doc.Close()
        End Sub
	End Class
End Namespace
