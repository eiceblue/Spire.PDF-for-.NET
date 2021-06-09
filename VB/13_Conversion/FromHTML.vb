Imports System.Reflection
Imports Spire.Pdf
Imports System.IO
Imports Spire.Pdf.HtmlConverter

Namespace FromHTML
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()
			Dim pgSt As New PdfPageSettings()
			pgSt.Size = PdfPageSize.A4

			Dim htmlLayoutFormat As New PdfHtmlLayoutFormat()
			htmlLayoutFormat.IsWaiting = False

			Dim htmlpath As String = "..\..\..\..\..\..\Data\FromHTML.htm"
			Dim source As String = File.ReadAllText(htmlpath)
			doc.LoadFromHTML(source, True, pgSt, htmlLayoutFormat)

			'Save pdf file.
			doc.SaveToFile("FromHTML.pdf")
			doc.Close()

			'Launch the file.
			PDFDocumentViewer("FromHTML.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
