Imports System.IO
Imports System.Text
Imports Spire.Pdf.Graphics


Namespace GetTextSizeBasedOnFont
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim stringB As New StringBuilder()
			Dim text As String = "Spire.PDF for .NET"

			'Create an instance for PdfFont
			Dim font1 As New PdfFont(PdfFontFamily.TimesRoman, 12f)
			'Get text size based on font name and size
			Dim sizeF1 As SizeF = font1.MeasureString(text)
			stringB.AppendLine("1. The width is: " & sizeF1.Width & ", the height is: " & sizeF1.Height)

			'Create an instance for PdfTrueTypeFont
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Regular), True)
			'Get text size based on font name and size
			Dim sizeF2 As SizeF = font2.MeasureString(text)
			stringB.AppendLine("2. The width is: " & sizeF2.Width & ", the height is: " & sizeF2.Height)

			Dim result As String = "GetTextSizeBasedOnFont_out.txt"
			File.WriteAllText(result, stringB.ToString())

			'Launch the Txt file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
