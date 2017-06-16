Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace XPStoPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            'xps file
            Dim file As String = "..\..\..\..\..\..\Data\Sample4.xps"

            'open xps document
            Dim doc As New PdfDocument()
            doc.LoadFromXPS(file)

            'convert to pdf file.
            doc.SaveToFile("Sample4.pdf")
            doc.Close()

            'Launching the Pdf file.
            PDFDocumentViewer("Sample4.pdf")
		End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

	End Class
End Namespace
