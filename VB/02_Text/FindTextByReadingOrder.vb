Imports Spire.Pdf
Imports Spire.Pdf.Texts
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace FindTextByReadingOrder
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the PDF file to be loaded
			Dim filePath As String = "../../../../../../Data/ColumnarText.pdf"

			' Create a new PdfDocument object to work with PDF files
			Dim doc As New PdfDocument()

			' Load the PDF file from the specified file path
			doc.LoadFromFile(filePath)

			' Get the first page of the loaded document
			Dim pdfPageBase As PdfPageBase = doc.Pages(0)

			' Create a PdfTextFinder object 'finder' with the first page for searching text
			Dim finder As New PdfTextFinder(pdfPageBase)

			' Set the search strategy as Simple
			finder.Options.Strategy = PdfTextStrategy.Simple

			' Find all occurrences of the text "knowledge" on the page
			Dim pdfTextFragments As List(Of PdfTextFragment) = finder.Find("knowledge")

			' Create a StringBuilder object 'builder' to store the extracted information
			Dim builder As New StringBuilder()

			' Iterate over each found text fragment
			For Each find As PdfTextFragment In pdfTextFragments
				' Append separator line to the string builder
				builder.AppendLine("==================================================================================")

				' Append the found text to the string builder
				builder.AppendLine("Text: " & find.Text)

				' Append the sizes of the text to the string builder
				For Each size As SizeF In find.Sizes
					builder.AppendLine("Size: " & size.ToString())
				Next size

				' Append the positions of the text to the string builder
				For Each point As PointF In find.Positions
					builder.AppendLine("Position: " & point.ToString())
				Next point

				' Append the line that contains the searched text to the string builder
				builder.AppendLine("The line that contains the searched text : " & find.LineText)
			Next find

			' Specify the result file name
			Dim result As String = "FindTextByReadingOrder_out.txt"

			' Write the contents of the string builder to the result file
			File.WriteAllText(result, builder.ToString())

			' Dispose of system resources associated with the PdfDocument object
			doc.Dispose()
		End Sub
	End Class
End Namespace
