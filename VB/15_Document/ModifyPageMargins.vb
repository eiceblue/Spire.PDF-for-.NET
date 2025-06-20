Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ModifyPageMargins
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input PDF file path
			Dim input As String = "..\..\..\..\..\..\Data\ModifyPageMargins.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the input file
			doc.LoadFromFile(input)

			' Create a new PdfDocument object to store the modified document
			Dim newDoc As New PdfDocument()

			' Specify the margins for the modified pages
			Dim top As Single = 50
			Dim bottom As Single = 50
			Dim left As Single = 50
			Dim right As Single = 50

			' Iterate through each page in the source document
			For Each page As PdfPageBase In doc.Pages

				' Add a new page to the new document with the same size as the source page and zero margins
				Dim newPage As PdfPageBase = newDoc.Pages.Add(page.Size, New PdfMargins(0))

				' Set the scale of the new document content based on the margins
				newPage.Canvas.ScaleTransform((page.ActualSize.Width - left - right) / page.ActualSize.Width, (page.ActualSize.Height - top - bottom) / page.ActualSize.Height)

				' Draw the content of the source page onto the new document page with the specified margins
				newPage.Canvas.DrawTemplate(page.CreateTemplate(), New PointF(left, top))

			Next page

			' Specify the output file path
			Dim result As String = "ModifyPageMargins_out.pdf"

			' Save the modified document to the output file
			newDoc.SaveToFile(result)

			' Close the source document
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
