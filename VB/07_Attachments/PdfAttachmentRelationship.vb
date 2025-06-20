Imports Spire.Pdf
Imports Spire.Pdf.Attachments

Namespace PdfAttachmentRelationship
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path for the PDF document
			Dim input As String = "..\..\..\..\..\..\Data\Attachment.pdf"

			' Specify the attachment file path
			Dim attachmentPath As String = "..\..\..\..\..\..\Data\E-iceblueLogo.png"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the input file path
			doc.LoadFromFile(input)

			' Create a new PdfAttachment object
			Dim attachment As New PdfAttachment(attachmentPath)

			' Add the attachment to the PDF document
			doc.Attachments.Add(attachment, doc, Spire.Pdf.General.PdfAttachmentRelationship.Alternative)

			' Specify the output file name for the PDF document
			Dim output As String = "addAttachments.pdf"

			' Save the modified PDF document to the output file
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the document
			doc.Close()

			' Launch the file
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
