Imports Spire.Pdf
Imports Spire.Pdf.Attachments
Imports System.IO

Namespace GetIndividualAttachment
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

			' Get a collection of attachments in the PDF document
			Dim collection As PdfAttachmentCollection = pdf.Attachments

			' Get the second attachment from the collection
			Dim attachment As PdfAttachment = collection(1)

			' Save the data of the second attachment to a file using its original filename
			File.WriteAllBytes(attachment.FileName, attachment.Data)

			' Close the PDF document
			pdf.Close()
		End Sub
	End Class
End Namespace
