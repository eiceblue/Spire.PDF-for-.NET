Imports Spire.Pdf

Namespace ToPCL
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the input PDF file
			Dim input As String = "..\..\..\..\..\..\Data\ToPCL.pdf"

			' Create a new instance of PdfDocument
			Dim doc As New PdfDocument()

			' Load the PDF file from the specified file path
			doc.LoadFromFile(input)

			' Specify the file path for the resulting PCL file
			Dim output As String = "ToPCL_result.pcl"

			' Save the PDF document to a PCL file
			doc.SaveToFile(output, FileFormat.PCL)

			' Close the PDF document
			doc.Close()

			' Launch the PCL file
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
