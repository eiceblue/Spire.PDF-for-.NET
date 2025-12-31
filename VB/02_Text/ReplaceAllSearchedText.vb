Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Texts

Namespace ReplaceAllSearchedText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the path to the input PDF file
			Dim input As String = "..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf"

			' Create a new PdfDocument instance and load the input file
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Create a PdfTextFinder instance to find text on the page
			Dim finder As New PdfTextFinder(page)

			' Set the find options to ignore case
			finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase

			' Find the specified text on the page
			Dim finds As List(Of PdfTextFragment) = finder.Find("Spire.PDF for .NET")

			' Define the new replacement text
			Dim newText As String = "E-iceblue Spire.PDF"

			' Define a brush for text color
			Dim brush As PdfBrush = New PdfSolidBrush(Color.DarkBlue)

			' Define a font for the new text
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F, FontStyle.Regular))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			' Dim font As New PdfTrueTypeFont("Arial", 12.0F, FontStyle.Regular, True)
			' =============================================================================

			' Define a rectangle to cover the found text
			Dim rec As RectangleF

			' Loop through all found text fragments
			For Each find As PdfTextFragment In finds
				' Get the bounding rectangle of the found text
				rec = find.Bounds(0)
				' Draw a white rectangle to cover the found text
				page.Canvas.DrawRectangle(PdfBrushes.White, rec)
				' Draw the new text in the rectangle with the defined font and color
				page.Canvas.DrawString(newText, font, brush, rec)

				' Alternatively, you can use the ApplyRecoverString method to directly replace the old text with newText,
				' but it only sets the background color and cannot set the font or foreground color.
				' find.ApplyRecoverString(newText, Color.Gray);
			Next find

			' Specify the output file name
			Dim result As String = "ReplaceAllSearchedText_out.pdf"

			' Save the modified document to a file
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				System.Diagnostics.Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
