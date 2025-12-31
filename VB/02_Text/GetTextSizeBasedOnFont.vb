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
			' Create a StringBuilder instance to store the text size details
			Dim stringB As New StringBuilder()

			' Specify the text to measure
			Dim text As String = "Spire.PDF for .NET"

			' Create an instance of PdfFont using the Times Roman font family and size 12
			Dim font1 As New PdfFont(PdfFontFamily.TimesRoman, 12.0F)

			' Measure the size of the text based on the font
			Dim sizeF1 As SizeF = font1.MeasureString(text)

			' Append the details of the text size to the StringBuilder
			stringB.AppendLine("1. The width is: " & sizeF1.Width & ", the height is: " & sizeF1.Height)

			' Create an instance of PdfTrueTypeFont using the Arial font, size 12, and regular style
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 12.0F, FontStyle.Regular), True)

			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			' Dim font2 As New PdfTrueTypeFont("Arial", 12.0F, FontStyle.Regular, True)
			' =============================================================================

			' Measure the size of the text based on the font
			Dim sizeF2 As SizeF = font2.MeasureString(text)

			' Append the details of the text size to the StringBuilder
			stringB.AppendLine("2. The width is: " & sizeF2.Width & ", the height is: " & sizeF2.Height)

			' Specify the output file name
			Dim result As String = "GetTextSizeBasedOnFont_out.txt"

			' Write the content of the StringBuilder to a text file
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
