Imports Spire.Pdf
Imports System.IO
Imports System.Text

Namespace GetPageLabel
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim pdf As New PdfDocument()

			' Load the PDF file
			pdf.LoadFromFile("..\..\..\..\..\..\Data\PageLabel.pdf")

			' Create a StringBuilder instance
			Dim sb As New StringBuilder()

			' Get the labels of the pages in the PDF file
			For i As Integer = 0 To pdf.Pages.Count - 1
				sb.AppendLine("The page label of page " & (i + 1) & " is """ & pdf.Pages(i).PageLabel & """")
			Next i

			' Specify the output file path for the text file
			Dim result As String = "PageLabels.txt"

			' Save the page labels to a text file
			File.WriteAllText(result, sb.ToString())

			' Close the PDF document
			pdf.Close()

			' Launch the file
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
