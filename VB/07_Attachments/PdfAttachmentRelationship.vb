Imports Spire.Pdf
Imports Spire.Pdf.Attachments

Namespace PdfAttachmentRelationship
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\Attachment.pdf"
			Dim attachmentPath As String = "..\..\..\..\..\..\Data\E-iceblueLogo.png"
			Dim output As String = "addAttachments.pdf"
			'Load document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)
			'Define PdfAttachment
			Dim attachment As New PdfAttachment(attachmentPath)
			'Add addachment
			doc.Attachments.Add(attachment, doc, Spire.Pdf.General.PdfAttachmentRelationship.Alternative)
			'Save the document
			doc.SaveToFile(output, FileFormat.PDF)
			'Launch the file
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
