Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Namespace AddPdfLaunchAction
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document and add a page to it
			Dim doc As New PdfDocument()
			Dim page As PdfPageBase = doc.Pages.Add()

			'Create a PDF Launch Action       
			Dim launchAction As New PdfLaunchAction("..\..\..\..\..\..\Data\text.txt")

			'Create a PDF Action Annotation with the PDF Launch Action
			Dim text As String = "Click here to open file"
			Dim font As New PdfTrueTypeFont(New Font("Arial", 13f))
			Dim rect As New RectangleF(50, 50, 230, 15)
			page.Canvas.DrawString(text, font, PdfBrushes.ForestGreen, rect)
			Dim annotation As New PdfActionAnnotation(rect, launchAction)

			'Add the PDF Action Annotation to page
			TryCast(page, PdfNewPage).Annotations.Add(annotation)


			Dim result As String = "AddPdfLaunchAction_out.pdf"

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
