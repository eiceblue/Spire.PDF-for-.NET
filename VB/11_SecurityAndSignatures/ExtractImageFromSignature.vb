Imports Spire.Pdf
Imports System.Drawing.Imaging
Imports Spire.Pdf.Widget
Namespace ExtractImageFromSignature
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input PDF file path
			Dim input As String = "..\..\..\..\..\..\Data\ExtractImageFromSignature.pdf"

			' Create a new instance of PdfDocument
			Dim doc As New PdfDocument()

			' Read a PDF file
			doc.LoadFromFile(input)

			' Get the existing form of the document
			Dim form As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			' Extract images from signatures in the existing form
			Dim images() As Image = form.ExtractSignatureAsImages()
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim images() As System.IO.Stream = form.ExtractSignatureAsImages()
			' =============================================================================

			' Save the images to disk
			Dim i As Integer = 0
			For j As Integer = 0 To images.Length - 1
				images(j).Save(String.Format("Image-{0}.png", i), ImageFormat.Png)
				i += 1
			Next j

			' Display a message indicating successful extraction
			MessageBox.Show("Images have been successfully extracted.")

			' Close the PDF document
			doc.Close()
		End Sub
	End Class
End Namespace
