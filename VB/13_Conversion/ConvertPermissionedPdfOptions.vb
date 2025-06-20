Imports Spire.Pdf
Imports Spire.Pdf.Security
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Namespace ConvertPermissionedPdfOptions
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a PdfDocument object
			Dim doc As New PdfDocument()

			' Load a PDF file
			doc.LoadFromFile("..\..\..\..\..\..\Data\ConvertPermissionedPdf.pdf", "e-iceblue")

			' Apply permissions options to the conversion options.
			' When the option parameter is true, the PDF cannot be converted to other formats if permission Settings are set.
			doc.ConvertOptions.ApplyPermissionsOptions(True)

			' Create a StringBuilder object for storing results
			Dim sb As New StringBuilder()

			' Iterate over each FileFormat value in the enumeration
			For Each type As FileFormat In System.Enum.GetValues(GetType(FileFormat))
				Try
					' Check the current FileFormat value and save the document accordingly
					If type.ToString().Equals("PPTX") Then
						doc.SaveToFile("result_PPT.pptx", type)
					ElseIf type.ToString().Equals("DOCX") Then
						doc.SaveToFile("result_Docx.docx", type)
					ElseIf type.ToString().Equals("XLSX") Then
						doc.SaveToFile("result_Xlsx.xlsx", type)
					End If
				Catch ex As Exception
					' Append any exception message to the StringBuilder
					sb.AppendLine("save to: " & type & "  :" & ex.Message)
				End Try
			Next type

			' Append the contents of the StringBuilder to ConvertResult.txt file
			File.AppendAllText("ConvertResult.txt", sb.ToString())

			' Dispose of the PdfDocument object to release resources
			doc.Dispose()
		End Sub
	End Class
End Namespace
