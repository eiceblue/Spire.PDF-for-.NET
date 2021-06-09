Imports Spire.Pdf
Imports Spire.Pdf.Attachments

Namespace SortFileInPdf
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim doc As New PdfDocument()

			doc.Collection.AddCustomField("No", "number", Spire.Pdf.Collections.CustomFieldType.NumberField)
			doc.Collection.AddFileRelatedField("Desc", "desc", Spire.Pdf.Collections.FileRelatedFieldType.Desc)
			doc.Collection.Sort(New String() { "No", "Desc" }, New Boolean() { True, True })

			Dim pdfAttachment As New PdfAttachment("..\..\..\..\..\..\Data\SampleB_1.pdf")
			doc.Collection.AddAttachment(pdfAttachment)
			pdfAttachment = New PdfAttachment("..\..\..\..\..\..\Data\SampleB_2.pdf")
			doc.Collection.AddAttachment(pdfAttachment)
			pdfAttachment = New PdfAttachment("..\..\..\..\..\..\Data\SampleB_3.pdf")
			doc.Collection.AddAttachment(pdfAttachment)

			Dim i As Integer = 1
			For Each attachment As PdfAttachment In doc.Collection.AssociatedFiles
				attachment.SetFieldValue("No", i)
				attachment.SetFieldValue("Desc", attachment.FileName)
				i += 1
			Next attachment

			Dim output As String = "SortFileInPdf.pdf"
			doc.SaveToFile(output, FileFormat.PDF)
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
