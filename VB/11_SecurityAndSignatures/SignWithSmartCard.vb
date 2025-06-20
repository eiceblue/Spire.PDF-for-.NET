Imports Spire.Pdf
Imports Spire.Pdf.Security
Imports Spire.Pdf.Graphics
Imports System.Security.Cryptography.X509Certificates

Namespace SignWithSmartCard
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Define the input file path.
            Dim input As String = "../../../../../../Data/PDFTemplate_HF.pdf"

            ' Create a new PdfDocument object.
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified input file.
            doc.LoadFromFile(input)

            ' Open the Windows certificate store for certificate selection.
            Dim store As New X509Store(StoreLocation.CurrentUser)
            store.Open(OpenFlags.ReadOnly)

            ' Manually choose a certificate from the store.
            Dim sel As X509Certificate2Collection = X509Certificate2UI.SelectFromCollection(store.Certificates, Nothing, Nothing, X509SelectionFlag.SingleSelection)

            ' Create a certificate using the certificate data from the store.
            Dim cert As New PdfCertificate(sel(0).RawData)

            ' Create a new signature object for the document using the selected certificate.
            Dim signature As New PdfSignature(doc, doc.Pages(0), cert, "signature0")

            ' Set the bounds of the signature on the page.
            signature.Bounds = New RectangleF(New PointF(250, 660), New SizeF(250, 90))

            ' Load the sign image source.
            signature.SignImageSource = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png")

            ' Set the display mode of the graphics.
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail

            ' Set the label and value for the signer name.
            signature.NameLabel = "Signer:"
            signature.Name = sel(0).GetNameInfo(X509NameType.SimpleName, True)

            ' Set the label and value for the contact information.
            signature.ContactInfoLabel = "ContactInfo:"
            signature.ContactInfo = signature.Certificate.GetNameInfo(X509NameType.SimpleName, True)

            ' Set the label and value for the date.
            signature.DateLabel = "Date:"
            signature.Date = Date.Now

            ' Set the label and value for the location.
            signature.LocationInfoLabel = "Location:"
            signature.LocationInfo = "Chengdu"

            ' Set the label and value for the reason.
            signature.ReasonLabel = "Reason: "
            signature.Reason = "The certificate of this document"

            ' Set the label and value for the distinguished name.
            signature.DistinguishedNameLabel = "DN: "
            signature.DistinguishedName = signature.Certificate.IssuerName.Name

            ' Set the document permissions and certification status.
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges
            signature.Certificated = True

            ' Set the fonts for sign details and sign name.
            signature.SignDetailsFont = New PdfFont(PdfFontFamily.TimesRoman, 10.0F)
            signature.SignNameFont = New PdfFont(PdfFontFamily.Courier, 15)

            ' Set the sign image layout mode.
            signature.SignImageLayout = SignImageLayout.None

            ' Save the PDF file with the specified output file name.
            Dim output As String = "SignWithSmartCardUsingPdfFileSignature_out.pdf"
            doc.SaveToFile(output, FileFormat.PDF)

            ' Close the PDF document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
