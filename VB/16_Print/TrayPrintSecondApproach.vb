Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Imports System.Drawing.Printing
Imports Spire.Pdf.Print
Namespace TrayPrintSecondApproach
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Initialize an object of PdfDocument class
			Dim doc As New PdfDocument()
			'Load the PDF document
			doc.LoadFromFile("..\..\..\..\..\..\Data\PrintPdfDocument.pdf")

			' Set colour printing. If false, printing in black and white
			doc.PrintSettings.Color = True

			' Set landscape orientation printing. If false, printing in portrait orientation
			doc.PrintSettings.Landscape = True


			' Set duplex printing.
			doc.PrintSettings.Duplex = Duplex.Horizontal

			'Set Paper source
			AddHandler doc.PrintSettings.PaperSettings, Sub(sender1 As Object, e1 As PdfPaperSettingsEventArgs)
				'Set the paper source of page 1-50 as tray 1
				If 1 <= e1.CurrentPaper AndAlso e1.CurrentPaper <= 50 Then
					e1.CurrentPaperSource = e1.PaperSources(0)
				'Set the paper source of the rest of pages as tray 2
				Else
					e1.CurrentPaperSource = e1.PaperSources(1)
				End If
			End Sub
			'Print the document
			doc.Print()
		End Sub
	End Class
End Namespace
