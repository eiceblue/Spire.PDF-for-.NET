Imports Spire.Pdf

Namespace ToPostScript
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the input PDF file
			Dim input As String = "..\..\..\..\..\..\Data\ToPostScript.pdf"

			' Create a new instance of PdfDocument
			Dim document As New PdfDocument()

			' Load the PDF document from the specified file path
			document.LoadFromFile(input)

			' Specify the file path for the resulting PostScript file
			Dim output As String = "toPostScript_result.ps"

			' Save the PDF document to a PostScript file
			document.SaveToFile(output, FileFormat.POSTSCRIPT)

			' Close the PDF document
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
