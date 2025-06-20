Imports System.Text
Imports Spire.Pdf
Imports System.IO
Imports Spire.Pdf.Interchange.Metadata

Namespace GetXMPMetadata
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path
			Dim input As String = "..\..\..\..\..\..\Data\GetXMPMetadata.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the document from the input file
			doc.LoadFromFile(input)

			' Get the XMP metadata of the document
			Dim xmpMetadata As PdfXmpMetadata = doc.Metadata

			' Create a StringBuilder object to store the XMP metadata
			Dim builder As New StringBuilder()

			' Specify the namespace for PDF properties
			Const NsPdf As String = "http://ns.adobe.com/pdf/1.3/"

			' Check if the "Author" property exists in the XMP metadata and append it to the StringBuilder
			If xmpMetadata.ExistProperty(NsPdf, "Author") Then
				builder.AppendLine("Author: " & xmpMetadata.GetPropertyString(NsPdf, "Author"))
			End If

			' Check if the "Title" property exists in the XMP metadata and append it to the StringBuilder
			If xmpMetadata.ExistProperty(NsPdf, "Title") Then
				builder.AppendLine("Title: " & xmpMetadata.GetPropertyString(NsPdf, "Title"))
			End If

			' Check if the "Subject" property exists in the XMP metadata and append it to the StringBuilder
			If xmpMetadata.ExistProperty(NsPdf, "Subject") Then
				builder.AppendLine("Subject: " & xmpMetadata.GetPropertyString(NsPdf, "Subject"))
			End If

			' Check if the "Producer" property exists in the XMP metadata and append it to the StringBuilder
			If xmpMetadata.ExistProperty(NsPdf, "Producer") Then
				builder.AppendLine("Producer: " & xmpMetadata.GetPropertyString(NsPdf, "Producer"))
			End If

			' Check if the "Creator" property exists in the XMP metadata and append it to the StringBuilder
			If xmpMetadata.ExistProperty(NsPdf, "Creator") Then
				builder.AppendLine("Creator: " & xmpMetadata.GetPropertyString(NsPdf, "Creator"))
			End If

			' Check if the "Keywords" property exists in the XMP metadata and append it to the StringBuilder
			If xmpMetadata.ExistProperty(NsPdf, "Keywords") Then
				builder.AppendLine("Keywords: " & xmpMetadata.GetPropertyString(NsPdf, "Keywords"))
			End If

			' Specify the output file path
			Dim result As String = "GetXMPMetadata_out.txt"

			' Write the contents of the StringBuilder to the output file
			File.WriteAllText(result, builder.ToString())

			' Close the PDF document
			doc.Close()

			' Launch the result file
			DocumentViewer(result)
		End Sub

		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				System.Diagnostics.Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
