
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Texts

Namespace SearchWithRegularExpression
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the path to the input PDF file
			Dim input As String = "..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified input file
			doc.LoadFromFile(input)

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Create a PdfTextFinder object and set search options as regular expression
			Dim finder As New PdfTextFinder(page)
			finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.Regex

			' Find all occurrences of a four-digit number in the document
			Dim finds As List(Of PdfTextFragment) = finder.Find("\d{4}")

			' Specify the new text to replace the found text
			Dim newText As String = "New Year"

			' Specify the brush for the text color
			Dim brush As PdfBrush = New PdfSolidBrush(Color.DarkBlue)

			' Specify the font for the new text
			Dim font As New PdfTrueTypeFont(New Font("Arial", 7.0F, FontStyle.Bold))

			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			' Dim font As New PdfTrueTypeFont("Arial", 7.0F, FontStyle.Bold, true)
			' =============================================================================

			' Specify the string format for center alignment
			Dim centerAlign As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

			Dim rec As RectangleF
			For Each find As PdfTextFragment In finds
				' Get the bounds of the found text on the page
				rec = find.Bounds(0)

				' Draw a rectangle with green-yellow color around the found text
				page.Canvas.DrawRectangle(PdfBrushes.GreenYellow, rec)

				' Draw the new text using the defined font, color, and alignment within the same bounds
				page.Canvas.DrawString(newText, font, brush, rec, centerAlign)

				' Alternatively, the following line can directly replace the old text with the new text,
				' but it only sets the background color and cannot set the font or forecolor
				' find.ApplyRecoverString(newText, Color.Gray);
			Next find

			' Specify the output file name
			Dim result As String = "ReplaceTextWithRegularExpression_out.pdf"

			' Save the modified document to the specified output file
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
