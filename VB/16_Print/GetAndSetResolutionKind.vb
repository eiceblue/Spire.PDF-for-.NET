Imports Spire.Pdf
Imports Spire.Pdf.Print
Imports System.IO
Imports System.Text

Namespace GetAndSetResolutionKind
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Define the input file path
			Dim input As String = "..\..\..\..\..\..\Data\CustomDocumentProperties.pdf"

			' Create a new instance of PdfDocument
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified input file
			doc.LoadFromFile(input)

			' Set the printer resolution kind to High
			doc.PrintSettings.PrinterResolutionKind = PdfPrinterResolutionKind.High

			' Get the current printer resolution kind
			Dim kind As PdfPrinterResolutionKind = doc.PrintSettings.PrinterResolutionKind

			' Create a StringBuilder to store the resolution kind information
			Dim builder As New StringBuilder()

			' Check the value of the printer resolution kind and append the corresponding information to the StringBuilder
			Select Case kind
				Case PdfPrinterResolutionKind.High
					builder.AppendLine("High")
				Case PdfPrinterResolutionKind.Medium
					builder.AppendLine("Medium")
				Case PdfPrinterResolutionKind.Low
					builder.AppendLine("Low")
				Case PdfPrinterResolutionKind.Draft
					builder.AppendLine("Draft")
				Case PdfPrinterResolutionKind.Custom
					builder.AppendLine("Custom")
			End Select

			' Define the output file path for the resolution kind information
			Dim result As String = "GetAndSetResolutionKind_out.txt"

			' Write the resolution kind information to the output file
			File.WriteAllText(result, builder.ToString())

			' Close the PDF document
			doc.Close()

			' Launch the file
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
