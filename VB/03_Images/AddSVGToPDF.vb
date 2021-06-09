Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace AddSVGToPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document.
			Dim existingPDF As New PdfDocument()

			'Load an existing PDF
			existingPDF.LoadFromFile("..\..\..\..\..\..\Data\SampleB_1.pdf")

			'Create a new PDF document.
			Dim doc As New PdfDocument()

			'Load the SVG file
			doc.LoadFromSvg("..\..\..\..\..\..\Data\template.svg")

			'Create template
			Dim template As PdfTemplate = doc.Pages(0).CreateTemplate()

			'Draw template on existing PDF
			existingPDF.Pages(0).Canvas.DrawTemplate(doc.Pages(0).CreateTemplate(), New PointF(50, 250), New SizeF(200, 200))

			'Save the document
			Dim result As String = "AddSVGToPDF_out.pdf"
			existingPDF.SaveToFile(result, FileFormat.PDF)

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
