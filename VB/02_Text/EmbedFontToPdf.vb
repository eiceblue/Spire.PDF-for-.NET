Imports Spire.Pdf.Conversion

Namespace EmbedFontToPdf
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfEmbeddedFontConverter object with the path to an existing PDF file
			Dim converter As New PdfEmbeddedFontConverter("..\..\..\..\..\..\Data\UnEmbed.pdf")

			' Specify the output file name for the converted PDF document
			Dim output As String = "EmbedFontToPdf.pdf"

			' Convert the input PDF by embedding the fonts and save it as a new document
			converter.ToEmbeddedFontDocument(output)

			' Dispose the converter
			converter.Dispose()

			' Launch the Pdf file
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
