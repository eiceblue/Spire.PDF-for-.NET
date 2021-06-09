Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Annotations.Appearance
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace AddDateTimeStamp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a Pdf document from disk
			Dim document As New PdfDocument()
			document.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

			'Get the first page
			Dim page As PdfPageBase = document.Pages(0)

			'Set the font and brush
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Regular), True)
			Dim brush As New PdfSolidBrush(Color.Blue)

			'Time text
			Dim timeString As String = Date.Now.ToString("MM/dd/yy hh:mm:ss tt ")

			'Create a template and rectangle, draw the string
			Dim template As New PdfTemplate(140, 15)
			Dim rect As New RectangleF(New PointF(page.ActualSize.Width - template.Width - 10, page.ActualSize.Height - template.Height - 10), template.Size)
			template.Graphics.DrawString(timeString, font, brush, New PointF(0, 0))

			'Create stamp annoation
			Dim stamp As New PdfRubberStampAnnotation(rect)
			Dim apprearance As New PdfAppearance(stamp)
			apprearance.Normal = template
			stamp.Appearance = apprearance
			page.AnnotationsWidget.Add(stamp)

			'Sabe the document
			Dim output As String = "AddDateTimeStamp_result.pdf"
			document.SaveToFile(output, FileFormat.PDF)

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
