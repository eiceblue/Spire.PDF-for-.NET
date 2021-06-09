Imports Spire.Pdf
Imports Spire.Pdf.Attachments
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Namespace AddAttachmentsToPDFA
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim input As String = "..\..\..\..\..\..\Data\SampleB_2.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)
			Dim newDoc As New PdfNewDocument()
			'Set Pdf_A1B
			newDoc.Conformance = PdfConformanceLevel.Pdf_A1B
			For Each page As PdfPageBase In doc.Pages
				Dim size As SizeF = page.Size
				Dim p As PdfPageBase = newDoc.Pages.Add(size, New Spire.Pdf.Graphics.PdfMargins(0))
				page.CreateTemplate().Draw(p, 0, 0)
			Next page

			'Load files and add in attachments
			Dim data() As Byte = File.ReadAllBytes("..\..\..\..\..\..\Data\SampleB_1.png")
			Dim attach1 As New PdfAttachment("attachment1.png", data)
			Dim data2() As Byte = File.ReadAllBytes("..\..\..\..\..\..\Data\SampleB_1.pdf")
			Dim attach2 As New PdfAttachment("attachment2.pdf", data2)
			newDoc.Attachments.Add(attach1)
			newDoc.Attachments.Add(attach2)

			Dim output As String = "ToPDFAWithAttachments-result.pdf"

			newDoc.Save(output)
			newDoc.Close()

			'Launch the reuslt file
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
