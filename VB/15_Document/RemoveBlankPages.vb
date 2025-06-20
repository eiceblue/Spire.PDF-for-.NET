Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace RemoveBlankPages
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim document As New PdfDocument()

			' Load the PDF document from the specified file path
			document.LoadFromFile("..\..\..\..\..\..\Data\RemoveBlankPages.pdf")

			' Iterate through the pages of the document in reverse order
			For i As Integer = document.Pages.Count - 1 To 0 Step -1

				' Check if the current page is blank
				If document.Pages(i).IsBlank() Then
					' Remove the blank page
					document.Pages.RemoveAt(i)
				Else
					' Convert the page to an image (bitmap)
					Dim image As Image = document.SaveAsImage(i, PdfImageType.Bitmap)

					' Determine whether the image is blank or not
					If IsImageBlank(image) Then
						' Delete the corresponding PDF page if the image is blank
						document.Pages.RemoveAt(i)
					End If
				End If

			Next i

			' Specify the result file path for saving the modified document
			Dim result As String = "RemoveBlankPages_out.pdf"

			' Save the modified document to the result file
			document.SaveToFile(result)

			' Close the PDF document
			document.Close()

			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Public Shared Function IsImageBlank(ByVal image As Image) As Boolean
			Dim bitmap As New Bitmap(image)
			For i As Integer = 0 To bitmap.Width - 1
				For j As Integer = 0 To bitmap.Height - 1
					Dim pixel As Color = bitmap.GetPixel(i, j)
					If pixel.R < 240 OrElse pixel.G < 240 OrElse pixel.B < 240 Then
						Return False
					End If
				Next j
			Next i
			Return True
		End Function

		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
