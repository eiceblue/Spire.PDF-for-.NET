Imports System.Security.Cryptography.X509Certificates
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.DigitalSignatures

Namespace AddImageSignature
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument
			Dim doc As New PdfDocument()

			' Load the PDF file from a specified path
			doc.LoadFromFile("..\..\..\..\..\..\Data\AddImageSignature.pdf")

			' Create a new X509Certificate2 object for the signature using a certificate file and password
			Dim x509 As New X509Certificate2("..\..\..\..\..\..\Data\gary.pfx", "e-iceblue")

			' Create a PdfOrdinarySignatureMaker object for the document with the X509 certificate
			Dim signatureMaker As New PdfOrdinarySignatureMaker(doc, x509)

			' Create a PdfCustomSignatureAppearance object for the signature appearance
			Dim signatureAppearance As IPdfSignatureAppearance = New PdfCustomSignatureAppearance()

			' Apply the signature to the document with the given field name and appearance
			signatureMaker.MakeSignature("Signature", signatureAppearance)

			' Specify the output file name for the modified PDF document
			Dim output As String = "output.pdf"

			' Save the modified PDF document to the specified output file using Spire.Pdf library
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the PDF document
			doc.Close()

			' Launch the result Pdf file
			PDFDocumentViewer(output)
		End Sub

		Public Class PdfCustomSignatureAppearance
			Implements IPdfSignatureAppearance
			Public Sub Generate(ByVal g As PdfCanvas) Implements IPdfSignatureAppearance.Generate
				' Create an Image object from a specified image file
				Dim image As Image = Image.FromFile("..\..\..\..\..\..\Data\AddImageSignature.png")

				' Draw the image on the PdfCanvas at the specified position
				g.DrawImage(PdfImage.FromImage(image), New PointF(0, 0))
			End Sub
		End Class

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
