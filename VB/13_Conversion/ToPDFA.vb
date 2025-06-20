Imports Spire.Pdf.Conversion

Namespace ToPDFA
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the input PDF file
			Dim input As String = "..\..\..\..\..\..\Data\ToPDFA.pdf"

			' Create a new instance of PdfStandardsConverter and load PDF file
			Dim converter As PdfStandardsConverter = New PdfStandardsConverter(input)

			' Specify the file path for the resulting PDF/A-1b compliant PDF file
			Dim output As String = "ToPDFA-result.pdf"

			' Convert the input PDF to PDF/A-1b format. It also provides ToPdfA1A / ToPdfA1B / ToPdfA2B / ToPdfA2A / ToPdfA3B / ToPdfA3A / ToPdfX1A2001
			converter.ToPdfA1B(output)

			' Dispose the convertor
			converter.Dispose()

			' Launch the result file
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
