Imports Spire.Pdf
Imports Spire.Pdf.Graphics.Layer
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace InvisibleAllPdfLayers
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document.
			Dim doc As New PdfDocument()

			'Load the file from disk.
			doc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_5.pdf")

			For i As Integer = 0 To doc.Layers.Count - 1
				'Show all the Pdf layers.
				'doc.Layers[i].Visibility = PdfVisibility.On;

				'Set all the Pdf layers invisible.
				doc.Layers(i).Visibility = PdfVisibility.Off
			Next i

			Dim result As String = "InvisibleAllPdfLayers_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
