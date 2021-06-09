Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ResetPageSize
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\ResetPageSize.pdf"

			Dim output As String = "ResetPageSize.pdf"

			'Load the document from disk
			Dim originalDoc As New PdfDocument()
			originalDoc.LoadFromFile(input)
			'Set the margins
			Dim margins As New PdfMargins(0)

			'Create a new pdf document
			Using newDoc As New PdfDocument()
				Dim scale As Single = 0.8f
				For i As Integer = 0 To originalDoc.Pages.Count - 1
					Dim page As PdfPageBase = originalDoc.Pages(i)

					'Use same scale to set width and height
					Dim width As Single = page.Size.Width * scale
					Dim height As Single = page.Size.Height * scale

					'Add new page with expected width and height
					Dim newPage As PdfPageBase = newDoc.Pages.Add(New SizeF(width, height), margins)
					newPage.Canvas.ScaleTransform(scale, scale)

					'Copy content of original page into new page
					newPage.Canvas.DrawTemplate(page.CreateTemplate(), PointF.Empty)
				Next i

				'save the document
				newDoc.SaveToFile(output)
			End Using

			'Launch the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
