Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Namespace ReplaceAllSearchedText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf"
			Dim doc As New PdfDocument()

			' Read a pdf file
			doc.LoadFromFile(input)

			' Get the first page of pdf file
			Dim page As PdfPageBase = doc.Pages(0)

			' Searches "Spire.PDF for .NET" by ignoring case
			Dim collection As PdfTextFindCollection = page.FindText("Spire.PDF for .NET",TextFindParameter.IgnoreCase)

			Dim newText As String = "E-iceblue Spire.PDF"

			' Creates a brush
			Dim brush As PdfBrush = New PdfSolidBrush(Color.DarkBlue)

			' Defines a font
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Regular))

			Dim rec As RectangleF
			For Each find As PdfTextFind In collection.Finds
				' Gets the bound of the found text in page
				 rec = find.Bounds

				 page.Canvas.DrawRectangle(PdfBrushes.White, rec)
				 ' Draws new text as defined font and color
				 page.Canvas.DrawString(newText, font, brush, rec)

				' This method can directly replace old text with newText,but it just can set the background color, can not set font/forecolor
				' find.ApplyRecoverString(newText, Color.Gray);
			Next find

			Dim result As String = "ReplaceAllSearchedText_out.pdf"

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
