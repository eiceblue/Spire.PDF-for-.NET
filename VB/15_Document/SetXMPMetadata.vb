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
			'Pdf file 
			Dim input As String = "..\..\..\..\..\..\Data\SetXMPMetadata.pdf"

			'Open a pdf document
			Dim doc As New PdfDocument()
		 doc.LoadFromFile(input)

			'Set XMP Metadata  
      doc.DocumentInformation.Author = "E-iceblue"
      doc.DocumentInformation.Creator = "Spire.PDF"
      doc.DocumentInformation.SetCustomProperty("Field1", "NewValue")
      doc.DocumentInformation.Keywords = "XMP"
      doc.DocumentInformation.Producer = "E-icenlue Co,.Ltd"
      doc.DocumentInformation.Subject = "XMP Metadata"
      doc.DocumentInformation.Title = "Set XMP Metadata in PDF"

			Dim output As String = "SetXMPMetadata.pdf"

			'Save pdf document
			doc.SaveToFile(output)

			'Launch the Pdf file
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
