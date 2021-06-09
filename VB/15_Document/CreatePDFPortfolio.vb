Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Collections
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace CreatePDFPortfolio
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'The folder path for files
			Dim files() As String = Directory.GetFiles("..\..\..\..\..\..\Data\CreatePDFPortfolio")

			'The target file path 
			Dim targetFile As String = "..\..\..\..\..\..\Data\Sample.pdf"

			'Create folder and sub folder to add file into it
			Dim doc As New PdfDocument(targetFile)
			For i As Integer = 0 To files.Length - 1
				doc.Collection.Folders.AddFile(files(i))
				Dim folder As PdfFolder = doc.Collection.Folders.CreateSubfolder("SubFolder" & (i+1))
				folder.AddFile(files(i))
			Next i
			'Save the document
			Dim result As String = "CreatePDFPortfolio_out.pdf"
			doc.SaveToFile(result)
			doc.Dispose()

			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
