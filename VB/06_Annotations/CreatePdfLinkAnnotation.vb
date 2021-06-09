Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace CreatePdfLinkAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new object of PdfDocument.
			Dim doc As New PdfDocument()

			'Add a page to it.
			Dim page As PdfPageBase = doc.Pages.Add()

			'Declare two parameters that will be passed to the constructor of PdfFileLinkAnnotation class.
			Dim rect As New RectangleF(0, 40, 250, 35)
			Dim filePath As String = "..\..\..\..\..\..\Data\Template_Pdf_3.pdf"

			'Create a file link annotation based on the two parameters and add the annotation to the new page.
			Dim link As New PdfFileLinkAnnotation(rect, filePath)
			page.AnnotationsWidget.Add(link)

			'Create a free text annotation based on the same RectangleF, specifying the content.
			Dim text As New PdfFreeTextAnnotation(rect)
			text.Text = "Click here! This is a link annotation."
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 15)
			text.Font = font
			page.AnnotationsWidget.Add(text)

			Dim result As String = "CreatePdfLinkAnnotation_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
