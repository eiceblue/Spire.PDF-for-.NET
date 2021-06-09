Imports Spire.Pdf
Imports Spire.Pdf.Exporting

Namespace DeleteImageByBounds
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Input and output file paths
			Dim input As String = "..\..\..\..\..\..\Data\DeleteImageByBounds.pdf"
			Dim result As String = "DeleteImageByBounds_result.pdf"
			'Open pdf document
			Dim pdf As New PdfDocument()
			'Load file from disk
			pdf.LoadFromFile(input)
			'Get the first page
			Dim p As PdfPageBase = pdf.Pages(0)
			'Get the information of all images in this page 
			Dim images() As PdfImageInfo = p.ImagesInfo
			'Traverse the array
			For i As Integer = 0 To images.Length - 1
				'Case 1: delete the image if it's bounds contains a certain point
				If images(i).Bounds.Contains(49.68f,72.75f) Then
					p.DeleteImage(images(i).Image)
				End If
				'Case 2: delete the image if it's bounds intersects with a certain rectangle
				If images(i).Bounds.IntersectsWith(New RectangleF(100f,500f,30f,40f)) Then
					p.DeleteImage(images(i).Image)
				End If

			Next i
			'Save the pdf file
			pdf.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
