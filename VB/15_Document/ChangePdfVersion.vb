Imports Spire.Pdf

Namespace ChangePdfVersion
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object.
			Dim doc As New PdfDocument()

			' Load an existing PDF file from the specified path.
			doc.LoadFromFile("..\..\..\..\..\..\Data\ChangePdfVersion.pdf")

			' Set the PDF version of the loaded document to Version 1.6.
			doc.FileInfo.Version = PdfVersion.Version1_6

			' Save the modified document to a new file named "ChangePdfVersion_result.pdf".
			doc.SaveToFile("ChangePdfVersion_result.pdf")

			' Close the document.
			doc.Close()

			' Launch the Pdf file.
			PDFDocumentViewer("ChangePdfVersion_result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
