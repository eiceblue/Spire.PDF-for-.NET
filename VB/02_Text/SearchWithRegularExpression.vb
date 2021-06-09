Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Namespace SearchWithRegularExpression
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

			' Create PdfTextFindCollection object to find all the phrases matching the regular expression
			Dim collection As PdfTextFindCollection = page.FindText("\d{4}",TextFindParameter.Regex)

			Dim newText As String = "New Year"

			' Creates a brush
			Dim brush As PdfBrush = New PdfSolidBrush(Color.DarkBlue)

			' Defines a font
			Dim font As New PdfTrueTypeFont(New Font("Arial", 7f, FontStyle.Bold))

			' Defines text horizontal/vertical center format
			Dim centerAlign As New PdfStringFormat(PdfTextAlignment.Center,PdfVerticalAlignment.Middle)

			Dim rec As RectangleF
			For Each find As PdfTextFind In collection.Finds
				' Gets the bound of the found text in page
				 rec = find.Bounds

				 page.Canvas.DrawRectangle(PdfBrushes.GreenYellow, rec)
				 ' Draws new text as defined font and color
				 page.Canvas.DrawString(newText, font, brush, rec,centerAlign)

				' This method can directly replace old text with newText,but it just can set the background color, can not set font/forecolor
				' find.ApplyRecoverString(newText, Color.Gray);
			Next find

			Dim result As String = "ReplaceTextWithRegularExpression_out.pdf"

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
