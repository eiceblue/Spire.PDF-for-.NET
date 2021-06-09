Imports System.IO
Imports System.Text
Imports Spire.Pdf


Namespace DocumentAndPagePieceDictionaries
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim pdf As New PdfDocument()
			'Input file path
			Dim input As String = "..\..\..\..\..\..\Data\DocumentAndPagePieceDictionaries.pdf"
			'Load file from disk
			pdf.LoadFromFile(input)
'''            
'''             * Add piece dictionaries into a document 
'''             * 
			'If the document piece info is null, create it
			If pdf.DocumentPieceInfo Is Nothing Then
				pdf.DocumentPieceInfo = New PdfPieceInfo()
			End If
			'Add pairs of key-value
			pdf.DocumentPieceInfo.AddApplicationData("ice", "E-iceblue-ice")
			pdf.DocumentPieceInfo.AddApplicationData("blue", "E-iceblue-blue")
			pdf.DocumentPieceInfo.AddApplicationData("Blue", "E-iceblue-Blue")
			pdf.DocumentPieceInfo.AddApplicationData("Ice", "E-iceblue-Ice")
			'Remove the value by key
			pdf.DocumentPieceInfo.RemoveApplicationData("blue")
'''            
'''             * Add piece dictionaries into a page
'''             * 
			'If the piece info in the first page is null, create it
			If pdf.Pages(0).PagePieceInfo Is Nothing Then
				pdf.Pages(0).PagePieceInfo = New PdfPieceInfo()
			End If
			'Add pairs of key-value
			pdf.Pages(0).PagePieceInfo.AddApplicationData("ice", "E-iceblue-ice")
			pdf.Pages(0).PagePieceInfo.AddApplicationData("blue", "E-iceblue-blue")
			pdf.Pages(0).PagePieceInfo.AddApplicationData("Blue", "E-iceblue-Blue")
			pdf.Pages(0).PagePieceInfo.AddApplicationData("Ice", "E-iceblue-Ice")
			'Remove the value by key
			pdf.Pages(0).PagePieceInfo.RemoveApplicationData("Ice")

			'Get piece dictionaries from document
			getDictionary(pdf.DocumentPieceInfo.ApplicationDatas, "documentPieceDictionary.txt")
			'Get piece dictionaries from the first page
			getDictionary(pdf.Pages(0).PagePieceInfo.ApplicationDatas, "pagePieceDictionary.txt")

			'Save pdf file
			pdf.SaveToFile("DocumentAndPagePieceDictionaries-result.pdf")
			pdf.Close()

			'Launch the Pdf file
			FileViewer("DocumentAndPagePieceDictionaries-result.pdf")
			'Launch the .txt files
			FileViewer("documentPieceDictionary.txt")
			FileViewer("pagePieceDictionary.txt")
		End Sub

		Private Sub getDictionary(ByVal dic As IDictionary(Of String, PdfApplicationData), ByVal fileName As String)
			Dim sb As New StringBuilder()
			'Traverse all keys in the dictionary
			For Each item As String In dic.Keys
				Dim data As PdfApplicationData = dic(item)
				If TypeOf data.Private Is String Then
					'Get the value and append it to StringBuilder
					Dim ss As String = TryCast(data.Private, String)
					sb.AppendLine(ss)
				End If
			Next item
			'Wirte the text of StringBuilder to file
			File.WriteAllText(fileName, sb.ToString())
		End Sub

		Private Sub FileViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
