Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ToXPS
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            'pdf file
            Dim file As String = "..\..\..\..\..\..\Data\Sample4.pdf"

            'open pdf document
            Dim doc As New PdfDocument()
            doc.LoadFromFile(file)

            'convert to xps file.
            doc.SaveToFile("Sample4.xps", FileFormat.XPS)
            doc.Close()

            'Launching the xps file.
            System.Diagnostics.Process.Start("Sample4.xps")
		End Sub
	End Class
End Namespace
