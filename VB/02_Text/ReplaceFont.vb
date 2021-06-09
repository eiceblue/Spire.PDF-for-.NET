Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Graphics.Fonts
Imports System.ComponentModel
Imports System.Text

Namespace ReplaceFont
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load the document from disk 
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\ReplaceFont.pdf")

			'Get the fonts used in PDF
			Dim fonts() As PdfUsedFont = doc.UsedFonts

			'Create a new font 
			Dim newfont As New PdfTrueTypeFont(New Font("Arial", 13f),True)

			For Each font As PdfUsedFont In fonts
				'Replace the font with new font
				font.Replace(newfont)
			Next font

			'Save the document
			doc.SaveToFile("Output.pdf")

			'View the Pdf doc
			Process.Start("Output.pdf")
		End Sub
	End Class
End Namespace
