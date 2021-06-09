Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Namespace SearchTextAndAddHyperlink
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
			Dim collection As PdfTextFindCollection = page.FindText("e-iceblue", TextFindParameter.IgnoreCase)

			' hyperlink url
			Dim url As String = "http://www.e-iceblue.com"

			For Each find As PdfTextFind In collection.Finds
				' Create a PdfUriAnnotation object to add hyperlink for the searched text 
				Dim uri As New PdfUriAnnotation(find.Bounds)
				uri.Uri = url
				uri.Border = New PdfAnnotationBorder(1f)
				uri.Color = Color.Blue
				page.AnnotationsWidget.Add(uri)
			Next find

			Dim result As String = "SearchTextAndAddHyperlink_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
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
