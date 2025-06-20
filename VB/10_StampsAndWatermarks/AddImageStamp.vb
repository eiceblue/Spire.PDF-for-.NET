Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Annotations.Appearance

Namespace AddImageStamp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Define the input file path
			Dim input As String = "..\..\..\..\..\..\Data\AddImageStamp.pdf"

			' Create a new PdfDocument object
			Dim document As New PdfDocument()

			' Load the PDF document from the input file
			document.LoadFromFile(input)

			' Get the first page of the document
			Dim page As PdfPageBase = document.Pages(0)

			' Create a new PdfRubberStampAnnotation object with specified size and position
			Dim loStamp As New PdfRubberStampAnnotation(New RectangleF(New PointF(0, 0), New SizeF(60, 60)))

			' Create a PdfAppearance object for the stamp annotation
			Dim loApprearance As New PdfAppearance(loStamp)

			' Load an image to be used as the stamp
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\image stamp.jpg")

			' Create a PdfTemplate object with specified dimensions
			Dim template As New PdfTemplate(210, 210)

			' Draw the loaded image onto the template at a specific position
			template.Graphics.DrawImage(image, 60, 60)

			' Set the normal appearance of the stamp annotation to the created template
			loApprearance.Normal = template

			' Set the appearance of the stamp annotation to the created appearance object
			loStamp.Appearance = loApprearance

			' Add the stamp annotation to the page's annotations widget collection
            page.Annotations.Add(loStamp)

			' Define the output file path
			Dim output As String = "AddImageStamp.pdf"

			' Save the modified document to the output file
			document.SaveToFile(output)

			' Close the document
			document.Close()

			'Launch the file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
