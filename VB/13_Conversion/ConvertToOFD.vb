Imports Spire.Pdf

Namespace ConvertToOFD
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the output file name for the resulting OFD document
			Dim output As String = "ConvertToOFD-result.ofd"

			' Specify the input PDF file path
			Dim input As String = "..\..\..\..\..\..\Data\ConvertToOFD.pdf"

			' Create a new PdfDocument object
			Dim pdf As New PdfDocument()

			' Load the PDF file from the specified path
			pdf.LoadFromFile(input)

			' Convert the PDF to OFD format
			pdf.SaveToFile(output, FileFormat.OFD)

			' Close the PdfDocument object
			pdf.Close()

			' Launch the odf file
			FileViewer(output)
		End Sub
		Private Sub FileViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
