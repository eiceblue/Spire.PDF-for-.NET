Imports Spire.Pdf

Namespace XPSToPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Xps file
			Dim file As String = "..\..\..\..\..\..\Data\XPStoPDF.xps"

			'Open xps document
			Dim doc As New PdfDocument()
			doc.LoadFromXPS(file)

			'Convert to pdf file
			doc.SaveToFile("XPStoPDF-result.pdf")
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer("XPStoPDF-result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
