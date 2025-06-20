Imports Spire.Pdf
Imports Spire.Pdf.Graphics.Layer

Namespace InvisibleParticularPdfLayers
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

			' Set the visibility of the first layer in the document to "Off" (invisible)
			doc.Layers(0).Visibility = PdfVisibility.Off

			' Set the visibility of a particular layer named "blue line" to "Off" (invisible)
			doc.Layers("blue line").Visibility = PdfVisibility.Off

			' Specify the output file path
			Dim result As String = "InvisibleParticularPdfLayers_out.pdf"

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
