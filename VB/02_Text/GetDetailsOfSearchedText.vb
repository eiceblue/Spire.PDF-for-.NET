Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Imports System.IO
Namespace GetDetailsOfSearchedText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf"
			Dim doc As New PdfDocument()

			' Read a pdf file
			doc.LoadFromFile(input)

			' Get the first page of pdf file
			Dim page As PdfPageBase = doc.Pages(0)

			' Create PdfTextFindCollection object to find all the matched phrases
			Dim collection As PdfTextFindCollection = page.FindText("Spire.PDF for .NET", TextFindParameter.IgnoreCase)

			' Create a StringBuilder object to put the details of the text searched
			Dim builder As New StringBuilder()

			For Each find As PdfTextFind In collection.Finds
				builder.AppendLine("==================================================================================")
				builder.AppendLine("Match Text: " + find.MatchText)
				builder.AppendLine("Text: " + find.SearchText)
				builder.AppendLine("Size: " + find.Size.ToString())
				builder.AppendLine("Position: " + find.Position.ToString())
				builder.AppendLine("The index of page which is including the searched text : " + find.SearchPageIndex.ToString())
				builder.AppendLine("The line that contains the searched text : " + find.LineText)
				builder.AppendLine("Match Text: " + find.MatchText)

			Next find

			Dim result As String = "GetDetailsOfSearchedText_out.txt"

			File.WriteAllText(result, builder.ToString())
			'Launch the result file
			DocumentViewer(result)
		End Sub

		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
