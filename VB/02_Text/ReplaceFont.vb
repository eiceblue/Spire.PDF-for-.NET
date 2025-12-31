Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Graphics.Fonts
Namespace ReplaceFont
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument instance
			Dim doc As New PdfDocument()

			' Load the document from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\ReplaceFont.pdf")

			' Get the fonts used in the PDF
			Dim fonts() As PdfUsedFont = doc.UsedFonts

			' Create a new font
			Dim newfont As New PdfTrueTypeFont(New Font("Arial", 13.0F), True)
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			' Dim newfont As New PdfTrueTypeFont("Arial", 13.0F, True)
			' =============================================================================

			For Each font As PdfUsedFont In fonts
				' Replace the font with the new font
				font.Replace(newfont)
			Next font

			' Save the modified document to a file
			doc.SaveToFile("Output.pdf")

			' Close the document
			doc.Close()

			' Launch the Pdf file
			Process.Start("Output.pdf")
		End Sub
	End Class
End Namespace
