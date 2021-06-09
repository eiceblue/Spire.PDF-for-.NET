Imports Spire.Pdf
Imports Spire.Pdf.Print

Namespace BookletLayoutSettings
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a PDF file
			Dim pdf As New PdfDocument()

			'Load a PDF file from disk
			pdf.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

			'If the printer can print with Duplex
			Dim isDuplex As Boolean = pdf.PrintSettings.CanDuplex
			If isDuplex Then
				'Set PdfBookletSubsetMode as "BothSides" and PdfBookletBindingMode as "Left"
				pdf.PrintSettings.SelectBookletLayout(PdfBookletSubsetMode.BothSides, PdfBookletBindingMode.Left)

				'Print the PDF
				pdf.Print()
			End If
			'Close 
			Me.Close()
		End Sub
	End Class
End Namespace
