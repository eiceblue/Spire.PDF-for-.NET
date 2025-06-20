Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace CreateTwoColumnPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Add a page to the document and assign it to a PdfPageBase object
			Dim page As PdfPageBase = doc.Pages.Add()

			' Define two strings for the content of the page
			Dim s1 As String = "Spire.PDF for .NET is a professional PDF component applied to creating, writing, editing, handling and reading PDF files without any external dependencies within .NET application. Using this .NET PDF library, you can implement rich capabilities to create PDF files from scratch or process existing PDF documents entirely through C#/VB.NET without installing Adobe Acrobat."
			Dim s2 As String = "Many rich features can be supported by the .NET PDF API, such as security setting (including digital signature), PDF text/attachment/image extract, PDF merge/split, metadata update, section, graph/image drawing and inserting, table creation and processing, and importing data etc. Besides, Spire.PDF for .NET can be applied to easily converting Text, Image and HTML to PDF with C#/VB.NET in high quality."

			' Get the width and height of the page
			Dim pageWidth As Single = page.GetClientSize().Width
			Dim pageHeight As Single = page.GetClientSize().Height

			' Create a PdfBrush object with black color
			Dim brush As PdfBrush = PdfBrushes.Black

			' Create a PdfFont object with Times Roman font and size 12
			Dim font As New PdfFont(PdfFontFamily.TimesRoman, 12.0F)

			' Create a PdfStringFormat object with justified alignment
			Dim format As New PdfStringFormat(PdfTextAlignment.Justify)

			' Draw the first string on the left half of the page's canvas
			page.Canvas.DrawString(s1, font, brush, New RectangleF(0, 20, pageWidth / 2 - 8.0F, pageHeight), format)

			' Draw the second string on the right half of the page's canvas
			page.Canvas.DrawString(s2, font, brush, New RectangleF(pageWidth / 2 + 8.0F, 20, pageWidth / 2 - 8.0F, pageHeight), format)

			' Specify the output file name
			Dim result As String = "CreateTwoColumnPDF_out.pdf"

			' Save the document to the specified file
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
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
