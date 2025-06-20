Imports Spire.Pdf.Conversion

Namespace ConvertToDocxSettingProperties
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the output file path
			Dim output As String = "ConvertToWordSettingProperties-result.docx"

			' Specify the input PDF file path
			Dim input As String = "..\..\..\..\..\..\Data\ConvertToWordSettingProperties.pdf"

			' Create a new instance of PdfToDocConverter and specify the input file path
			Dim converter As New PdfToDocConverter(input)

			' Set properties for the resulting .docx document
			converter.DocxOptions.Title = "PDFTODOCX"
			converter.DocxOptions.Subject = "Set document properties."
			converter.DocxOptions.Tags = "Test Tags"
			converter.DocxOptions.Categories = "PDF"
			converter.DocxOptions.Commments = "This document is just for testing the properties"
			converter.DocxOptions.Authors = "E-iceblue Support Team"
			converter.DocxOptions.LastSavedBy = "E-iceblue Support Team"
			converter.DocxOptions.Revision = 8
			converter.DocxOptions.Version = "csharp V4.0"
			converter.DocxOptions.ProgramName = "Spire.Pdf for .NET"
			converter.DocxOptions.Company = "E-iceblue"
			converter.DocxOptions.Manager = "E-iceblue"

			' Convert the PDF to DOCX format and save it to the specified output file
			converter.SaveToDocx(output)

			' Launch the docx file
			FileViewer(output)
		End Sub
		Private Sub FileViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
