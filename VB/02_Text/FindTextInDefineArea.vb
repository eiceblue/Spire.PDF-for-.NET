Imports Spire.Pdf
Imports Spire.Pdf.General.Find

Namespace FindTextInDefineArea
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\SampleB_1.pdf"
			Dim output As String = "FindTextInDefinePlace.pdf"
			'Load document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)

			'Define a rectangle
			Dim rctg As New RectangleF(0, 0, 300, 300)

			'Find text in the rectangle
			Dim findCollection As PdfTextFindCollection = doc.Pages(0).FindText(rctg, "Spire", TextFindParameter.WholeWord)
			Dim findCollectionOut As PdfTextFindCollection = doc.Pages(0).FindText(rctg, "PDF", TextFindParameter.WholeWord)

			'Highlight the found text
			For Each find As PdfTextFind In findCollection.Finds
				find.ApplyHighLight(Color.Green)
			Next find

			For Each findOut As PdfTextFind In findCollectionOut.Finds
				findOut.ApplyHighLight(Color.Yellow)
			Next findOut

			'Save the document
			doc.SaveToFile(output, FileFormat.PDF)
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
