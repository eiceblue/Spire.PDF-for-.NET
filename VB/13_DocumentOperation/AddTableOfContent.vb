Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.IO
Imports Spire.Pdf.General
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Actions

Namespace AddTableOfContent
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file 
			Dim input As String = "..\..\..\..\..\..\Data\Sample2.pdf"

			'open a pdf document
			Dim doc As New PdfDocument(input)

			'get the page count
			Dim pageCount As Integer = doc.Pages.Count

			'insert a blank page into the pdf document
			Dim tocPage As PdfPageBase = doc.Pages.Insert(0)

			'set title
			Dim title As String = "Table Of Contents"
			Dim titleFont As New PdfTrueTypeFont(New Font("Arial", 16, FontStyle.Bold))
			Dim centerAlignment As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			Dim location As New PointF(tocPage.Canvas.ClientSize.Width \ 2, titleFont.MeasureString(title).Height)
			tocPage.Canvas.DrawString(title, titleFont, PdfBrushes.Black, location, centerAlignment)

			'draw TOC text
			Dim titlesFont As New PdfTrueTypeFont(New Font("Arial", 10))
			Dim titles(pageCount - 1) As String
			For i As Integer = 0 To titles.Length - 1
				titles(i) = String.Format("This is page{0}", i+1)
			Next i
			Dim y As Single = titleFont.MeasureString(title).Height + 10
			Dim x As Single = 0

			For i As Integer = 1 To pageCount
				Dim text As String = titles(i-1)
				Dim titleSize As SizeF = titlesFont.MeasureString(text)

				Dim navigatedPage As PdfPageBase = doc.Pages(i)

				Dim pageNumText As String = (i+1).ToString()
				Dim pageNumTextSize As SizeF = titlesFont.MeasureString(pageNumText)
				tocPage.Canvas.DrawString(text, titlesFont, PdfBrushes.Black, 0, y)
				Dim dotLocation As Single = titleSize.Width + 2 + x
				Dim pageNumlocation As Single = tocPage.Canvas.ClientSize.Width - pageNumTextSize.Width
				For j As Single = dotLocation To pageNumlocation - 1
					If dotLocation >= pageNumlocation Then
						Exit For
					End If
					tocPage.Canvas.DrawString(".", titlesFont, PdfBrushes.Black, dotLocation, y)
					dotLocation += 2
				Next j
				tocPage.Canvas.DrawString(pageNumText, titlesFont, PdfBrushes.Black, pageNumlocation, y)

				'add TOC action
				location = New PointF(0, y)
				Dim titleBounds As New RectangleF(location, New SizeF(tocPage.Canvas.ClientSize.Width, titleSize.Height))
				Dim Dest As New PdfDestination(navigatedPage, New PointF(-doc.PageSettings.Margins.Top, -doc.PageSettings.Margins.Left))
				Dim action As New PdfActionAnnotation(titleBounds, New PdfGoToAction(Dest))
				action.Border = New PdfAnnotationBorder(0)
				TryCast(tocPage, PdfNewPage).Annotations.Add(action)
				y += titleSize.Height + 10
			Next i

			Dim output As String = "AddTableOfContent.pdf"

			'save pdf document
			doc.SaveToFile(output)

			'Launching the Pdf file
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
