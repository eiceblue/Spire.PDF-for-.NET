Imports Spire.Pdf
Imports Spire.Pdf.Attachments
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace GetPdfAttachmentInfo
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document
			Dim pdf As New PdfDocument()

			'Load the file from disk.
			pdf.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_2.pdf")

			'Get a collection of attachments on the PDF document
			Dim collection As PdfAttachmentCollection = pdf.Attachments

			'Get the first attachment.
			Dim attachment As PdfAttachment = collection(0)

			'Get the information of the first attachment.
			Dim content As New StringBuilder()
			content.AppendLine("Filename: " & attachment.FileName)
			content.AppendLine("Description: " & attachment.Description)
			content.AppendLine("Creation Date: " & attachment.CreationDate)
			content.AppendLine("Modification Date: " & attachment.ModificationDate)


			Dim result As String = "GetPdfAttachmentInfo_out.txt"

			'Save to file.
			File.WriteAllText(result, content.ToString())

			'Launch the file.
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
