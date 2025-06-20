Imports Spire.Pdf
Imports Spire.Pdf.Interactive.DigitalSignatures
Imports System.Security.Cryptography.X509Certificates

Namespace AddInvisibleSignature
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the PFX certificate file path
			Dim pfxPath As String = "..\..\..\..\..\..\Data\gary.pfx"

			' Specify the input PDF file path
			Dim inputPdf As String = "..\..\..\..\..\..\Data\AddInvisibleSignature.pdf"

			' Specify the output PDF file path
			Dim outputPdf As String = "AddInvisibleSignature_result.pdf"

			' Create a new instance of PdfDocument
			Dim pdf As New PdfDocument()

			' Load the PDF document from the specified input file path
			pdf.LoadFromFile(inputPdf)

			' Create a new X509Certificate2 object using the PFX certificate file and password
			Dim x509 As New X509Certificate2(pfxPath, "e-iceblue")

			' Create a PdfOrdinarySignatureMaker object for the document with the X509 certificate
			Dim signatureMaker As New PdfOrdinarySignatureMaker(pdf, x509)

			' Make an invisible signature in the PDF document with the specified field name
			signatureMaker.MakeSignature("signName")

			' Save the modified PDF document to the specified output file path
			pdf.SaveToFile(outputPdf, FileFormat.PDF)

			' Close the PDF document
			pdf.Close()

			' Launch the pdf file
			FileViewer(outputPdf)
		End Sub
		Private Sub FileViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
