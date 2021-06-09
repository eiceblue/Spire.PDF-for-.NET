Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Text
Imports System.Threading.Tasks

Namespace InsertEmptyPage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load an existing pdf from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

			'insert a blank page as the second page
			doc.Pages.Insert(1)

			Dim result As String = "InsertEmptyPage_out.pdf"

			'Save the document
			doc.SaveToFile(result)

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