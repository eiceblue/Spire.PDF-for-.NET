Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions

Namespace AddPdfLaunchAction
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument
			Dim doc As New PdfDocument()

			' Add a new page to the document
			Dim page As PdfPageBase = doc.Pages.Add()

			' Create a PdfLaunchAction to launch a file
			Dim launchAction As New PdfLaunchAction("..\..\..\..\..\..\Data\text.txt")

			' Set the text to be displayed on the page
			Dim text As String = "Click here to open file"

			' Set the font for the text
			Dim font As New PdfTrueTypeFont(New Font("Arial", 13.0F))

			' Set the rectangle for the text
			Dim rect As New RectangleF(50, 50, 230, 15)

			' Draw the text on the page using the specified font and rectangle
			page.Canvas.DrawString(text, font, PdfBrushes.ForestGreen, rect)

			' Create a PdfActionAnnotation for the text
			Dim annotation As New PdfActionAnnotation(rect, launchAction)

			' Add the annotation to the page's annotations collection
			TryCast(page, PdfNewPage).Annotations.Add(annotation)

			' Save the document to a file
			Dim result As String = "AddPdfLaunchAction_out.pdf"
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
