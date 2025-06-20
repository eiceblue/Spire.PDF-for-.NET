Imports Spire.Pdf
Imports Spire.Pdf.Graphics.Layer

Namespace InvisibleAllPdfLayers
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_5.pdf")

			' Iterate through each layer in the document
			For i As Integer = 0 To doc.Layers.Count - 1

				' Show all the Pdf layers
				' doc.Layers(i).Visibility = PdfVisibility.On;

				' Set all the Pdf layers to be invisible
				doc.Layers(i).Visibility = PdfVisibility.Off

			Next i

			' Specify the output file path
			Dim result As String = "InvisibleAllPdfLayers_out.pdf"

			' Save the modified document to the output file
			doc.SaveToFile(result)

			' Close the PDF document
			doc.Close()

			' Launch the Pdf file
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
