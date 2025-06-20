Imports Spire.Pdf

Namespace SetTabOrder
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument object
			Dim pdf As New PdfDocument()

			' Load the PDF file from the specified path
			pdf.LoadFromFile("..\..\..\..\..\..\Data\SetTabOrder.pdf")

			' Disable incremental update for the file info
			pdf.FileInfo.IncrementalUpdate = False

			' Get the first page of the PDF document
			Dim page As PdfPageBase = pdf.Pages(0)

			' Set the tab order of the page using the structure order
			page.SetTabOrder(TabOrder.Structure)

			' Specify the output file name
			Dim result As String = "SetTabOrder_output.pdf"

			' Save the modified PDF document to the output file
			pdf.SaveToFile(result)

			' Close the PDF document
			pdf.Close()

			' Launch the file
			DocumentViewer(result)
		End Sub
		Private Sub DocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
