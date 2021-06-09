Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Namespace RemovePageMargins
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\PDFTemplate-Az.pdf"
			Dim doc As New PdfDocument()

			' Read a pdf file
			doc.LoadFromFile(input)

			' Creates a new page
			Dim newDoc As New PdfDocument()

			' Get page margins of source pdf page
			Dim margins As PdfMargins = doc.PageSettings.Margins
			Dim top As Single = margins.Left
			Dim bottom As Single = margins.Bottom
			Dim left As Single = margins.Left
			Dim right As Single = margins.Right

			For Each page As PdfPageBase In doc.Pages
				' Adds a new page to the new document
				Dim newPage As PdfPageBase = newDoc.Pages.Add(New SizeF(page.Size.Width - left - right, page.Size.Height - top - bottom), New PdfMargins(0))

				' Draws the content of the source page onto the new document page
				newPage.Canvas.DrawTemplate(page.CreateTemplate(), New PointF(-left, -top))
			Next page

			Dim result As String = "RemovePageMargins_out.pdf"

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
