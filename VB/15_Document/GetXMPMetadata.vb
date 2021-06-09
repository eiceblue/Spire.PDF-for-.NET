Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Xmp
Imports System.IO

Namespace GetXMPMetadata
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\GetXMPMetadata.pdf"
			Dim doc As New PdfDocument()
			' Read a pdf file
			doc.LoadFromFile(input)

			Dim xmpMetadata As XmpMetadata = doc.XmpMetaData

			' Create a StringBuilder object to put the details
			Dim builder As New StringBuilder()

			builder.AppendLine("Author:" & xmpMetadata.GetAuthor())
			builder.AppendLine("Title: " & xmpMetadata.GetTitle())
			builder.AppendLine("Creation Date: " & xmpMetadata.GetCreateDate())
			builder.AppendLine("Subject: " & xmpMetadata.GetSubject())
			builder.AppendLine("Producer: " & xmpMetadata.GetProducer())
			builder.AppendLine("Creator: " & xmpMetadata.GetCreator())
			builder.AppendLine("Keywords: " & xmpMetadata.GetKeywords())
			builder.AppendLine("Modify Date: " & xmpMetadata.GetModifyDate())
			builder.AppendLine("Customed Property's value: " & xmpMetadata.GetCustomProperty("Field1"))

			Dim result As String = "GetXMPMetadata_out.txt"

			File.WriteAllText(result, builder.ToString())
			'Launch the result file
			DocumentViewer(result)
		End Sub

		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
