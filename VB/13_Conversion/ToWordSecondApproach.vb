Imports Spire.Pdf.Conversion

Namespace ToWordSecondApproach
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the input PDF file
			Dim file As String = "..\..\..\..\..\..\Data\ToDocx.pdf"

			' Create a new instance of PdfToWordConverter and load a PDF file
			Dim converter As New PdfToWordConverter(file)

			' Convert the PDF to Word with flow layout
			converter.SaveToDocx("ToWordConvorter.docx")

			' Dispose the converter
			converter.Dispose()

			' Launch the file
			PDFDocumentViewer("ToWordConvorter.docx")
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
