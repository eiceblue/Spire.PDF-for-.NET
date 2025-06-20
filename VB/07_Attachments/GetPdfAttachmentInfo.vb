Imports Spire.Pdf
Imports Spire.Pdf.Attachments
Imports System.IO
Imports System.Text

Namespace GetPdfAttachmentInfo
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim pdf As New PdfDocument()

			' Load the PDF document from the specified input file
			pdf.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_2.pdf")

			' Get the collection of attachments in the PDF document
			Dim collection As PdfAttachmentCollection = pdf.Attachments

			' Access the first attachment in the collection
			Dim attachment As PdfAttachment = collection(0)

			' Create a StringBuilder to store attachment information
			Dim content As New StringBuilder()
			content.AppendLine("Filename: " & attachment.FileName)
			content.AppendLine("Description: " & attachment.Description)
			content.AppendLine("Creation Date: " & attachment.CreationDate)
			content.AppendLine("Modification Date: " & attachment.ModificationDate)

			' Specify the output file name for writing attachment information
			Dim result As String = "GetPdfAttachmentInfo_out.txt"

			' Write the attachment information to the output file
			File.WriteAllText(result, content.ToString())

			' Close the document
			pdf.Close()

			' Launch the file
			DocumentViewer(result)
		End Sub

		Private Sub DocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
