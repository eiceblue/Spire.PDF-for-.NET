Imports Spire.Pdf

Namespace SVGToPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument class
			Dim doc As New PdfDocument()

			' Load the SVG file from the specified path
			doc.LoadFromSvg("..\..\..\..\..\..\Data\template.svg")

			' Specify the output file name for the resulting PDF
			Dim result As String = "SVgToPDF_out.pdf"

			' Save the document as a PDF file
			doc.SaveToFile(result)

			' Close the PdfDocument object
			doc.Close()

			' Launch the Pdf file
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
