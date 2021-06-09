Imports Spire.Pdf
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Namespace GetPageLabel
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a PdfDocument instance
			Dim pdf As New PdfDocument()

			'Load the PDF file
			pdf.LoadFromFile("..\..\..\..\..\..\Data\PageLabel.pdf")

			'Create a StringBuilder instance
			Dim sb As New StringBuilder()

			'Get the labels of the pages in the PDF file
			For i As Integer = 0 To pdf.Pages.Count - 1
				sb.AppendLine("The page label of page " & (i+1) & " is """ & pdf.Pages(i).PageLabel & """")
			Next i

			Dim result As String="PageLabels.txt"
			'Save to a .txt file
			File.WriteAllText(result, sb.ToString())

			'Launch file
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
