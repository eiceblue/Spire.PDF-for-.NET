Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.DigitalSignatures
Imports Spire.Pdf.Widget
Imports System.ComponentModel
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Namespace SignSignatureFieldWithSignatureMaker
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the path of the input files
			Dim inputFile As String = "..\..\..\..\..\..\Data\SignatureField.pdf"
			Dim inputFile_pfx As String= "..\..\..\..\..\..\Data\gary.pfx"
			Dim inputFile_Img As String = "..\..\..\..\..\..\Data\logo.png"

			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(inputFile)
			Dim widgets As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)
			For i As Integer = 0 To widgets.FieldsWidget.List.Count - 1
				Dim widget As PdfFieldWidget = TryCast(widgets.FieldsWidget.List(i), PdfFieldWidget)
				If TypeOf widget Is PdfSignatureFieldWidget Then
					Dim originalName As String = widget.Name
					Dim cert As New X509Certificate2(inputFile_pfx, "e-iceblue")
					Dim formatter As IPdfSignatureFormatter = New PdfPKCS7Formatter(cert, False)

					' PdfMDPSignatureMaker signatureMaker = new PdfMDPSignatureMaker(pdf, formatter);
					Dim signatureMaker As New PdfOrdinarySignatureMaker(pdf, formatter)

					Dim signature As PdfSignature = signatureMaker.Signature
					signature.Name = "E-iceblue"
					signature.ContactInfo = "028-81705109"
					signature.Location = "Cheng Du"
					signature.Reason = "Ensure document integrity"

					Dim appearance As New PdfSignatureAppearance(signature)
					appearance.NameLabel = "Signer: "
					appearance.ContactInfoLabel = "ContactInfo: "
					appearance.LocationLabel = "Loaction: "
					appearance.ReasonLabel = "Reason: "
					appearance.SignatureImage = PdfImage.FromFile(inputFile_Img)
					appearance.GraphicMode = GraphicMode.SignImageAndSignDetail

					signatureMaker.MakeSignature(originalName, appearance)
				End If
			Next i

			' Define the output file name for the signed PDF.
			Dim outputFile As String = "SignSignatureFieldWithSignatureMaker.pdf"

			' Save the signed PDF document to the specified output path.
			pdf.SaveToFile(outputFile, FileFormat.PDF)

			' Dispose of the PDF document to release resources.
			pdf.Dispose()

			' Launch the result file.
			PDFDocumentViewer(outputFile)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
