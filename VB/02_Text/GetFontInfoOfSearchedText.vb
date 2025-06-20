Imports Spire.Pdf
Imports Spire.Pdf.Texts
Imports System.IO
Imports System.Text

Namespace GetFontInfoOfSearchedText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf instance
			Dim doc As New PdfDocument()

			'Load from file and get the first page
			doc.LoadFromFile("..\..\..\..\..\..\Data\findText.pdf")
			Dim page As PdfPageBase = doc.Pages(0)

			' Create PdfTextFinder
			Dim finds As New PdfTextFinder(page)
			' Set options to find
			finds.Options.Parameter = TextFindParameter.None
			' Find the key word
			Dim result As List(Of PdfTextFragment) = finds.Find("science")
			Dim str As New StringBuilder()
			' Iterate the results
			For Each find As PdfTextFragment In result
				' Get the line of keyword 
				Dim text As String = find.LineText
				' Get the font name 
				Dim FontName As String = find.TextStates(0).FontName
				' Get the fot size
				Dim FontSize As Single = find.TextStates(0).FontSize
				' Get font family
				Dim FontFamily As String = find.TextStates(0).FontFamily
				' Get whether the keyword is bold
				Dim IsBold As Boolean = find.TextStates(0).IsBold
				' Get whether the keyword is simulate bold
				Dim IsSimulateBold As Boolean = find.TextStates(0).IsSimulateBold
				' Get whether the keyword is italic
				Dim IsItalic As Boolean = find.TextStates(0).IsItalic
				' Get color
				Dim color As Color = find.TextStates(0).ForegroundColor
				' Append informtion to str
				str.AppendLine(text)
				str.AppendLine("FontName: " & FontName)
				str.AppendLine("FontSize: " & FontSize)
				str.AppendLine("FontFamily: " & FontFamily)
				str.AppendLine("IsBold: " & IsBold)
				str.AppendLine("IsSimulateBold: " & IsSimulateBold)
				str.AppendLine("IsItalic: " & IsItalic)
                str.AppendLine("color: " & color.ToString())
				str.AppendLine(" ")
			Next find

			' Output the file
			Dim outputFile As String = "GetFindTextStates-result.txt"

			File.WriteAllText(outputFile, str.ToString())

			'Release Object
			doc.Dispose()

			'Launch the Pdf file
			PDFDocumentViewer(outputFile)

			Me.Close()

		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try

		End Sub
	End Class
End Namespace
