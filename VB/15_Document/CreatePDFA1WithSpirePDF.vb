﻿Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace CreatePDFA1WithSpirePDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim doc As New PdfNewDocument()

			'Spire.PDF supports Pdf_A1B, Pdf_X1A2001, Pdf_A1A, Pdf_A2A 
			doc.Conformance = PdfConformanceLevel.Pdf_A1B

			'Create one A4 page
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4,New PdfMargins(40))

			' Draw content
			DrawPage(page)

			Dim result As String = "CreatePDFA1WithSpirePDF_out.pdf"

			'Save the document
			doc.Save(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub DrawPage(ByVal page As PdfPageBase)
			Dim pageWidth As Single = page.Canvas.ClientSize.Width
			Dim y As Single = 0

			'Title
			y = y + 5
			Dim brush2 As PdfBrush = New PdfSolidBrush(Color.Black)
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
			Dim format2 As New PdfStringFormat(PdfTextAlignment.Center)
			format2.CharacterSpacing = 1f
			Dim text As String = "Summary of Science"
			page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2)
			Dim size As SizeF = font2.MeasureString(text, format2)
			y = y + size.Height + 6

			'Icon
			Dim image As PdfImage = PdfImage.FromFile("..\\..\\..\\..\\..\\..\\Data\\Wikipedia_Science.png")
			page.Canvas.DrawImage(image, New PointF(pageWidth - image.PhysicalDimension.Width, y))
			Dim imageLeftSpace As Single = pageWidth - image.PhysicalDimension.Width - 2
			Dim imageBottom As Single = image.PhysicalDimension.Height + y

			'Reference content
			Dim font3 As New PdfTrueTypeFont(New Font("Arial", 9f))
			Dim format3 As New PdfStringFormat()
			format3.ParagraphIndent = font3.Size * 2
			format3.MeasureTrailingSpaces = True
			format3.LineSpacing = font3.Size * 1.5f
			Dim text1 As String = "(All text and picture from "
			Dim text2 As String = "Wikipedia"
			Dim text3 As String = ", the free encyclopedia)"
			page.Canvas.DrawString(text1, font3, brush2, 0, y, format3)

			size = font3.MeasureString(text1, format3)
			Dim x1 As Single = size.Width
			format3.ParagraphIndent = 0
			Dim font4 As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Underline))
			Dim brush3 As PdfBrush = PdfBrushes.Blue
			page.Canvas.DrawString(text2, font4, brush3, x1, y, format3)
			size = font4.MeasureString(text2, format3)
			x1 = x1 + size.Width

			page.Canvas.DrawString(text3, font3, brush2, x1, y, format3)
			y = y + size.Height

			'Content
			Dim format4 As New PdfStringFormat()
            text = System.IO.File.ReadAllText("..\\..\\..\\..\\..\\..\\Data\\Summary_of_Science.txt")
			Dim font5 As New PdfTrueTypeFont(New Font("Arial", 10f))
			format4.LineSpacing = font5.Size * 1.5f
			Dim textLayouter As New PdfStringLayouter()
			Dim imageLeftBlockHeight As Single = imageBottom - y
			Dim result As PdfStringLayoutResult = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))
			If result.ActualSize.Height < imageBottom - y Then
				imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight
				result = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))
			End If
			For Each line As LineInfo In result.Lines
				page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4)
				y = y + result.LineHeight
			Next line
			Dim textWidget As New PdfTextWidget(result.Remainder, font5, brush2)
			Dim textLayout As New PdfTextLayout()
			textLayout.Break = PdfLayoutBreakType.FitPage
			textLayout.Layout = PdfLayoutType.Paginate
			Dim bounds As New RectangleF(New PointF(0, y), page.Canvas.ClientSize)
			textWidget.StringFormat = format4
			textWidget.Draw(page, bounds, textLayout)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
