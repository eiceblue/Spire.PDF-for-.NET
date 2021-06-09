Imports Spire.Pdf.Conversion

Namespace ToPdfA2B
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a standard pdf document
			Dim converter_1 As New PdfStandardsConverter("..\..\..\..\..\..\Data\ToPdfA2B.pdf")

			'Convert Pdf to PdfA2B 
			converter_1.ToPdfA2B("ToPdfA2B_result.pdf")

			'Launch the result file
			PDFDocumentViewer("ToPdfA2B_result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
