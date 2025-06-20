Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace RemovePageMargins
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input PDF file path
			Dim input As String = "..\..\..\..\..\..\Data\PDFTemplate-Az.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the input file
			doc.LoadFromFile(input)

			' Create a new PdfDocument object to store the modified document
			Dim newDoc As New PdfDocument()

			' Get the margins of the pages in the source document
			Dim margins As PdfMargins = doc.PageSettings.Margins

			' Extract the margin values
			Dim top As Single = margins.Top
			Dim bottom As Single = margins.Bottom
			Dim left As Single = margins.Left
			Dim right As Single = margins.Right

			' Iterate through each page in the source document
			For Each page As PdfPageBase In doc.Pages

				' Add a new page to the new document with adjusted size based on the margins
				Dim newPage As PdfPageBase = newDoc.Pages.Add(New SizeF(page.Size.Width - left - right, page.Size.Height - top - bottom), New PdfMargins(0))

				' Draw the content of the source page onto the new document page with adjusted position based on the margins
				newPage.Canvas.DrawTemplate(page.CreateTemplate(), New PointF(-left, -top))

			Next page

			' Specify the output file path for saving the modified document
			Dim result As String = "RemovePageMargins_out.pdf"

			' Save the modified document to the output file
			newDoc.SaveToFile(result)

			' Close the PDF documents
			newDoc.Close()
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
