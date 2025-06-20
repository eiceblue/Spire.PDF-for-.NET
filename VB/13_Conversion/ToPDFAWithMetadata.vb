Imports Spire.Pdf
Imports Spire.Pdf.Conversion
Imports Spire.Pdf.Interchange.Metadata

Namespace ToPDFAWithMetadata

	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRun.Click
			Dim path As String = "..\..\..\..\..\..\Data\ToPDFAWithMetadata.pdf"
			Dim pdfA As String = "ToPDFAWithMetadata_out.pdf"

			' Create an instance of the PdfStandardsConverter class
			Dim converter As New PdfStandardsConverter(path)
			
			' Convert to PDFA format document to preserve XMP data
			converter.Options.PreserveAllowedMetadata = True
			converter.ToPdfA1A(pdfA)

			'Launch the file
       DocumentViewer(pdfA)
		End Sub
		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

		Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
			Close()
		End Sub

	End Class
End Namespace
