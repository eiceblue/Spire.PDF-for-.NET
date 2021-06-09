Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Namespace CreateTwoColumnPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Creates a pdf document
			Dim doc As New PdfDocument()

			' Creates a new page
			Dim page As PdfPageBase = doc.Pages.Add()

			Dim s1 As String = "Spire.PDF for .NET is a professional PDF component applied to creating, writing, " & "editing, handling and reading PDF files without any external dependencies within " & ".NET application. Using this .NET PDF library, you can implement rich capabilities " & "to create PDF files from scratch or process existing PDF documents entirely through " & "C#/VB.NET without installing Adobe Acrobat."
			Dim s2 As String = "Many rich features can be supported by the .NET PDF API, such as security setting " & "(including digital signature), PDF text/attachment/image extract, PDF merge/split " & ", metadata update, section, graph/image drawing and inserting, table creation and " & "processing, and importing data etc.Besides, Spire.PDF for .NET can be applied to easily " & "converting Text, Image and HTML to PDF with C#/VB.NET in high quality."

			' Get width and height of page
			Dim pageWidth As Single =page.GetClientSize().Width
			Dim pageHeight As Single=page.GetClientSize().Height

			Dim brush As PdfBrush = PdfBrushes.Black
			Dim font As New PdfFont(PdfFontFamily.TimesRoman, 12f)
			Dim format As New PdfStringFormat(PdfTextAlignment.Justify)

			' Draw text
			page.Canvas.DrawString(s1, font, brush, New RectangleF(0, 20, pageWidth / 2 - 8f, pageHeight), format)
			page.Canvas.DrawString(s2, font, brush, New RectangleF(pageWidth / 2 + 8f, 20, pageWidth / 2 - 8f, pageHeight), format)


			Dim result As String = "CreateTwoColumnPDF_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
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
