Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text

Namespace PDFAToPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim input As String = "..\..\..\..\..\..\Data\SamplePDFA.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)

			'Create a new pdf and draw content on new file
			Dim newDoc As New PdfNewDocument()
			newDoc.CompressionLevel = PdfCompressionLevel.None

			For Each page As PdfPageBase In doc.Pages
				Dim size As SizeF = page.Size
				Dim p As PdfPageBase = newDoc.Pages.Add(size, New Spire.Pdf.Graphics.PdfMargins(0))
				page.CreateTemplate().Draw(p, 0, 0)
			Next page


			Dim output As String = "PDFAToPdf-result.pdf"

			newDoc.Save(output)
			newDoc.Close()

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
