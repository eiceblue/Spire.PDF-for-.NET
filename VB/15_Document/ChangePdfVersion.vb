Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text

Namespace ChangePdfVersion
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\ChangePdfVersion.pdf")

			'Change the pdf version
			doc.FileInfo.Version = PdfVersion.Version1_6

			doc.SaveToFile("ChangePdfVersion_result.pdf")

			'Launch the Pdf file.
			PDFDocumentViewer("ChangePdfVersion_result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
