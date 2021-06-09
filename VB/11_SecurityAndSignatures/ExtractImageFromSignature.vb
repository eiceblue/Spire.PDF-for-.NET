Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Imports System.Drawing.Imaging
Imports Spire.Pdf.Widget
Namespace ExtractImageFromSignature
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\ExtractImageFromSignature.pdf"
			Dim doc As New PdfDocument()

			' Read a pdf file
			doc.LoadFromFile(input)

			'Get the existing form of the document
			Dim form As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			'Extract images from signatures in the existing form
			Dim images() As Image = form.ExtractSignatureAsImages()

			'Save the images to disk
			Dim i As Integer = 0
			For j As Integer = 0 To images.Length - 1
				images(j).Save(String.Format("Image-{0}.png", i), ImageFormat.Png)
				i += 1
			Next j
			MessageBox.Show("Images have been sucessfully extracted.")
		End Sub
	End Class
End Namespace
