Imports Spire.Pdf
Imports Spire.Pdf.Attachments
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace GetIndividualAttachment
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

			'Get the second attachment in PDF file.
			Dim attachment As PdfAttachment = collection(1)

			'Save the second attachment to the file.
			File.WriteAllBytes(attachment.FileName, attachment.Data)
		End Sub
	End Class
End Namespace
