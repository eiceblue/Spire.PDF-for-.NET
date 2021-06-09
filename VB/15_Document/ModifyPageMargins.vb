Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Namespace ModifyPageMargins
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\ModifyPageMargins.pdf"
			Dim doc As New PdfDocument()

			' Read a pdf file
			doc.LoadFromFile(input)

			' Creates a new pdf document
			Dim newDoc As New PdfDocument()

			' Defines the page margins of the new document
			Dim top As Single = 50
			Dim bottom As Single = 50
			Dim left As Single = 50
			Dim right As Single = 50

			For Each page As PdfPageBase In doc.Pages
				' Adds a new page to the new document and set the page size to be the same as the source document
				Dim newPage As PdfPageBase = newDoc.Pages.Add(page.Size, New PdfMargins(0))
				' Set the scale of the new document content
				newPage.Canvas.ScaleTransform((page.ActualSize.Width - left - right) / page.ActualSize.Width, (page.ActualSize.Height - top - bottom) / page.ActualSize.Height)
				' Draws the content of the source page onto the new document page
				newPage.Canvas.DrawTemplate(page.CreateTemplate(), New PointF(left, top))
			Next page


			Dim result As String = "ModifyPageMargins_out.pdf"

			'Save the document
			newDoc.SaveToFile(result)
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
