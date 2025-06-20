Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Security
Imports Spire.Pdf.Graphics
Imports System.Security.Cryptography.X509Certificates

Namespace SignInSignatureField
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified file path
            doc.LoadFromFile("../../../../../../Data/SignatureField.pdf")

            ' Get the form widget from the document
            Dim widgets As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

            ' Iterate through each field widget in the form
            For i As Integer = 0 To widgets.FieldsWidget.List.Count - 1
                Dim widget As PdfFieldWidget = TryCast(widgets.FieldsWidget.List(i), PdfFieldWidget)
                If TypeOf widget Is PdfSignatureFieldWidget Then
                    ' Get the field name
                    Dim name As String = widget.Name
                    Dim signWidget As PdfSignatureFieldWidget = TryCast(widget, PdfSignatureFieldWidget)

                    ' Open the windows certificate store in read-only mode
                    Dim store As New X509Store(StoreLocation.CurrentUser)
                    store.Open(OpenFlags.ReadOnly)

                    ' Manually select the certificate from the store
                    Dim sel As X509Certificate2Collection = X509Certificate2UI.SelectFromCollection(store.Certificates, Nothing, Nothing, X509SelectionFlag.SingleSelection)

                    ' Create a certificate using the selected certificate data
                    Dim cert As New PdfCertificate(sel(0).RawData)

                    ' Create a signature with the certificate and the signature field
                    Dim signature As New PdfSignature(doc, signWidget.Page, cert, name, signWidget)

                    ' Load the sign image source
                    signature.SignImageSource = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png")

                    ' Set the graphics display mode (default if not set)
                    signature.GraphicsMode = GraphicMode.SignImageAndSignDetail
                    signature.NameLabel = "Signer:"

                    ' Set the signer name and contact information
                    signature.Name = sel(0).GetNameInfo(X509NameType.SimpleName, True)
                    signature.ContactInfoLabel = "ContactInfo:"
                    signature.ContactInfo = signature.Certificate.GetNameInfo(X509NameType.SimpleName, True)

                    ' Set the date of the signature
                    signature.DateLabel = "Date:"
                    signature.Date = Date.Now

                    ' Set the location information
                    signature.LocationInfoLabel = "Location:"
                    signature.LocationInfo = "Chengdu"

                    ' Set the reason for the signature
                    signature.ReasonLabel = "Reason: "
                    signature.Reason = "The certificate of this document"

                    ' Set the distinguished name label and value
                    signature.DistinguishedNameLabel = "DN: "
                    signature.DistinguishedName = signature.Certificate.IssuerName.Name

                    ' Set the document permissions and mark as certified
                    signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges
                    signature.Certificated = True

                    ' Set custom fonts for sign details and sign name (default if not set)
                    signature.SignDetailsFont = New PdfFont(PdfFontFamily.TimesRoman, 10.0F)
                    signature.SignNameFont = New PdfFont(PdfFontFamily.Courier, 15)

                    ' Set the sign image layout mode to None
                    signature.SignImageLayout = SignImageLayout.None
                End If
            Next i

            ' Save the modified PDF document to the specified output file path
            Dim output As String = "SignWithSmartCardUsingSignatureField_out.pdf"
            doc.SaveToFile(output)

            ' Close the PDF document
            doc.Close()

            ' Launch the result file
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
