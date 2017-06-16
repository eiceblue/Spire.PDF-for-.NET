Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Xmp

Namespace SetXMPMetadata
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file 
			Dim input As String = "..\..\..\..\..\..\Data\Sample5.pdf"

			'open a pdf document
			Dim doc As New PdfDocument(input)

			'set xmpMetadata 
			Dim meta As XmpMetadata = doc.XmpMetaData
			meta.SetAuthor("E-iceblue")
			meta.SetTitle("Set XMP Metadata in PDF")
			meta.SetSubject("XMP Metadata")
			meta.SetProducer("E-icenlue Co,.Ltd")
			meta.SetCreateDate(Date.Today)
			meta.SetCreator("Spire.PDF")
			meta.SetKeywords("XMP")
			meta.SetModifyDate(Date.Today)
			meta.SetCustomProperty("Field1", "NewValue")

			Dim output As String = "SetXMPMetadata.pdf"

			'save pdf document
			doc.SaveToFile(output)

			'Launching the Pdf file
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
