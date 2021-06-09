Imports Spire.Pdf
Imports Spire.Pdf.Print
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text

Namespace GetAndSetResolutionKind
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			 Dim input As String = "..\..\..\..\..\..\Data\CustomDocumentProperties.pdf"
			'Create a document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)
			'Set PrinterResolutionKind
			doc.PrintSettings.PrinterResolutionKind = PdfPrinterResolutionKind.High

			'Get PrinterResolutionKind
			Dim kind As PdfPrinterResolutionKind = doc.PrintSettings.PrinterResolutionKind
			Dim builder As New StringBuilder()
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

			'Write information to a txt file
			Dim result As String = "GetAndSetResolutionKind_out.txt"
			File.WriteAllText(result, builder.ToString())

			'Launch the file
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
