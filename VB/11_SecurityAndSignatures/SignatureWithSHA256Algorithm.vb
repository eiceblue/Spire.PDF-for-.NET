Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.DigitalSignatures
Imports System
Imports System.Drawing
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms

Namespace SignatureWithSHA256Algorithm
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Initialize a new PdfDocument instance
            Dim pdf As PdfDocument = New PdfDocument()

            ' Load the existing PDF file from the specified path
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\DigitalSignature.pdf")

            ' Load the X.509 certificate from a PFX file using the provided password
            Dim cert As X509Certificate2 = New X509Certificate2(@"..\..\..\..\..\..\Data\gary.pfx", "e-iceblue")

            ' Create a PKCS#7 signature formatter using the loaded certificate
            Dim formatter As IPdfSignatureFormatter = New PdfPKCS7Formatter(cert, False)

            ' Initialize the MDP signature maker with the PDF document and the formatter
            Dim pdfMDPSignatureMaker As PdfMDPSignatureMaker = New PdfMDPSignatureMaker(pdf, formatter)

            ' Get the signature object from the signature maker
            Dim signature As PdfSignature = pdfMDPSignatureMaker.Signature

            ' Set the name of the signer
            signature.Name = "e-iceblue"

            ' Set the contact information of the signer
            signature.ContactInfo = "028-81705109"

            ' Set the location where the document is signed
            signature.Location = "chengdu"

            ' Set the reason for signing the document
            signature.Reason = "Sign a pdf document."

            ' Create a signature appearance object to customize the visual layout
            Dim appearance As PdfSignatureAppearance = New PdfSignatureAppearance(signature)

            ' Set the custom label for the signer's name
            appearance.NameLabel = "Signer: "

            ' Set the custom label for the contact information
            appearance.ContactInfoLabel = "ContactInfo: "

            ' Set the custom label for the location
            appearance.LocationLabel = "Location: "

            ' Set the custom label for the signing reason
            appearance.ReasonLabel = "Reason: "

            ' Apply the signature to the first page at the specified coordinates and size
            pdfMDPSignatureMaker.MakeSignature("signName", pdf.Pages[0], 300, 550, 200, 100, appearance)

            ' Define the output file name for the signed PDF
            Dim result As String = "SignatureWithSHA256Algorithm.pdf"

            ' Set the current hash algorithm
            formatter.Properties.HashAlgorithm = HashAlgorithmType.SHA256

            ' Use a try-catch block to handle potential saving errors
            Try
                ' Save the signed PDF document to a file
                pdf.SaveToFile(result, FileFormat.PDF)
        Catch ex As Exception
                ' Print the error message to the console if saving fails
                Console.WriteLine($"error：{ex.Message}")
            End Try

            ' Dispose of the PDF document to release system resources
            pdf.Dispose()

            'Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub

    End Class
End Namespace
