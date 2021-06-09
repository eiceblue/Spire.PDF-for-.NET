Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports System.IO
Namespace ExtractTextFromSpecificArea
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		 Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\ExtractTextFromSpecificArea.pdf"

			'Load the PDF file
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(input)

			'Get the first page
			Dim page As PdfPageBase = pdf.Pages(0)

			'Extract text from a specific rectangular area within the page
			Dim text As String = page.ExtractText(New RectangleF(80, 180, 500, 200))

			'Save the text to a .txt file
			Dim sb As New StringBuilder()
			sb.AppendLine(text)
		   Dim result As String ="ExtractText_result.txt"
		   File.WriteAllText(result, sb.ToString())

		   Viewer(result)
		 End Sub
		Private Sub Viewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
