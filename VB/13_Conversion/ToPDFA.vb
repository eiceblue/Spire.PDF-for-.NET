Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Conversion

Namespace ToPDFA
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim input As String = "..\..\..\..\..\..\Data\ToPDFA.pdf"

      Dim converter As PdfStandardsConverter = New PdfStandardsConverter(input)
      Dim output As String = "ToPDFA-result.pdf"
      converter.ToPdfA1B(output)

			'Launch the result file.
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
