Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports System.IO
Namespace ExtractTextFromParticularPage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\PDFTemplate-Az.pdf"
			Dim doc As New PdfDocument()
			' Read a pdf file
			doc.LoadFromFile(input)

			' Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			' Extract text from page keeping white space
			Dim text As String = page.ExtractText(True)

			' Extract text from page without keeping white space
			'String text = page.ExtractText(false);

			Dim result As String = Path.GetFullPath("ExtractTextFromParticularPage_out.txt")
			' Create a writer to put the extracted text
			Dim tw As TextWriter = New StreamWriter(result)

			' Write a line of text to the file
			tw.WriteLine(text)

			' Close the stream
			tw.Close()

			MessageBox.Show(vbLf & "Text extracted successfully from particular pages of PDF Document." & vbLf & "File saved at " & result)
		End Sub
	End Class
End Namespace
