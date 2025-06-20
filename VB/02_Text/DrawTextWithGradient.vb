Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawTextWithGradient
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Add a new page to the document
			Dim page As PdfPageBase = doc.Pages.Add()

			' Define a rectangle with a specified position and size
			Dim rect As New Rectangle(New Point(0, 0), New Size(300, 100))

			' Create a linear gradient brush with a specified rectangle and colors
			Dim brush As New PdfLinearGradientBrush(rect, Color.Red, Color.Blue, PdfLinearGradientMode.Horizontal)

			' Create a TrueType font with Arial font family, size 20, and underline style
			Dim font As New PdfTrueTypeFont(New Font("Arial", 20, FontStyle.Underline))

			' Draw a string on the page's canvas using the specified font, brush, and position
			page.Canvas.DrawString("Welcome to E-iceblue!", font, brush, New Point(0, 100))

			' Specify the file name for saving the document
			Dim result As String = "DrawWithGradient-result.pdf"

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
