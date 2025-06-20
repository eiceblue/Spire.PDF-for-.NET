Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Annotations.Appearance
Imports Spire.Pdf.Graphics

Namespace AddDateTimeStamp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim document As New PdfDocument()

			' Load an existing PDF file from the specified path
			document.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

			' Access the first page of the document
			Dim page As PdfPageBase = document.Pages(0)

			' Create a new PdfTrueTypeFont object with Arial font, size 12, and regular style
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F, FontStyle.Regular), True)

			' Create a new PdfSolidBrush object with blue color
			Dim brush As New PdfSolidBrush(Color.Blue)

			' Get the current timestamp as a formatted string
			Dim timeString As String = Date.Now.ToString("MM/dd/yy hh:mm:ss tt ")

			' Create a new PdfTemplate object with a specific width and height
			Dim template As New PdfTemplate(140, 15)

			' Define the position and size of the template on the page
			Dim rect As New RectangleF(New PointF(page.ActualSize.Width - template.Width - 10, page.ActualSize.Height - template.Height - 10), template.Size)

			' Draw the timestamp string onto the template
			template.Graphics.DrawString(timeString, font, brush, New PointF(0, 0))

			' Create a new PdfRubberStampAnnotation object with the defined rectangle
			Dim stamp As New PdfRubberStampAnnotation(rect)

			' Create a new PdfAppearance object for the stamp annotation
			Dim appearance As New PdfAppearance(stamp)

			' Set the appearance of the stamp to use the created template
			appearance.Normal = template

			' Assign the appearance to the stamp annotation
			stamp.Appearance = appearance

			' Add the stamp annotation to the page
            page.Annotations.Add(stamp)

			' Specify the output file name
			Dim output As String = "AddDateTimeStamp_result.pdf"

			' Save the modified document to a file in PDF format
			document.SaveToFile(output, FileFormat.PDF)

			' Close the document
			document.Close()

			' Launch the file
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
