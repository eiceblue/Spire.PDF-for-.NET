Imports Spire.Pdf
Imports Spire.Pdf.Attachments
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace GetAllAttachments
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document.
			Dim pdf As New PdfDocument()

			'Load the file from disk.
			pdf.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_2.pdf")

			'Get a collection of attachments on the PDF document.
			Dim collection As PdfAttachmentCollection = pdf.Attachments

			'Save all the attachments to the files.
			For i As Integer = 0 To collection.Count - 1
				File.WriteAllBytes(collection(i).FileName, collection(i).Data)
			Next i
		End Sub
	End Class
End Namespace
