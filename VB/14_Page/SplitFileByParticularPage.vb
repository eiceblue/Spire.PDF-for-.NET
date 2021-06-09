Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace SplitFileByParticularPage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim oldPdf As New PdfDocument()

			'Load an existing pdf from disk
			oldPdf.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

			'Create a new PDF document
			Dim newPdf As New PdfDocument()

			'Initialize a new instance of PdfPageBase class
			Dim page As PdfPageBase

			'Specify the pages which you want them to be split
			For i As Integer = 1 To 2
				'Add same size page for newPdf
				page = newPdf.Pages.Add(oldPdf.Pages(i).Size, New Spire.Pdf.Graphics.PdfMargins(0))

				'Create template of the oldPdf page and draw into newPdf page
				oldPdf.Pages(i).CreateTemplate().Draw(page, New PointF(0, 0))
			Next i

			Dim result As String = "SplitFileByParticularPage_out.pdf"

			'Save the document
			newPdf.SaveToFile(result)
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
