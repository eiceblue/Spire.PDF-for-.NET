Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace Properties
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			 'Load pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\Properties.pdf")

			'Set document info
			doc.DocumentInformation.Author = "E-iceblue"
			doc.DocumentInformation.Creator = "E-iceblue"
			doc.DocumentInformation.Keywords = "pdf, demo, document information"
			doc.DocumentInformation.Producer = "Spire.Pdf"
			doc.DocumentInformation.Subject = "Demo of Spire.Pdf"
			doc.DocumentInformation.Title = "Document Information"

			'File info
			doc.FileInfo.CrossReferenceType = PdfCrossReferenceType.CrossReferenceStream
			doc.FileInfo.IncrementalUpdate = False

			'Save pdf file
			doc.SaveToFile("Properties_result.pdf")
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer("Properties_result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
