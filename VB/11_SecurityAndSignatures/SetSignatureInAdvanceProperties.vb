Imports System.Security.Cryptography.X509Certificates
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security

Imports System.Runtime.InteropServices

Namespace SetSignatureInAdvanceProperties
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Load the input file path
			Dim input As String = "..\..\..\..\..\..\Data\SampleB_1.pdf"

			' Load the input image file path
			Dim inputFile_img As String = "..\..\..\..\..\..\Data\logo.png"

			' Set the output file name and path for the result
			Dim result As String = "SetDetailsOfSignatureInAdvanceProperties_result.pdf"

			' Set the path of the pfx file containing the certificate
			Dim pfxPath As String = "..\..\..\..\..\..\Data\gary.pfx"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the input file path
			doc.LoadFromFile(input)

			' Open the X509Store in read-only mode
			Dim store As New X509Store(StoreLocation.CurrentUser)
			store.Open(OpenFlags.ReadOnly)

			' Load the certificate from the specified pfx file path
			Dim cert As New X509Certificate2(pfxPath, "e-iceblue")

			' Create a new instance of the custom PKCS7 signature formatter with the certificate
			Dim customPKCS7SignatureFormatter As New CustomPKCS7SignatureFormatterWithAPI(cert)

			' Create a new PdfSignature object with the document, first page, custom formatter, and signature name
			Dim signature As New PdfSignature(doc, doc.Pages(0), customPKCS7SignatureFormatter, "signature0")

			' Set the bounds of the signature field on the page
			signature.Bounds = New RectangleF(New PointF(250, 660), New SizeF(250, 90))

			' Load the sign image source
			signature.SignImageSource = PdfImage.FromFile(inputFile_img)

			' Set the graphics mode for display
			signature.GraphicsMode = GraphicMode.SignImageAndSignDetail

			' Set the label for the signer's name
			signature.NameLabel = "Signer:"

			' Set the signer's name from the certificate
			signature.Name = cert.GetNameInfo(X509NameType.SimpleName, True)

			' Set the label for the contact information
			signature.ContactInfoLabel = "ContactInfo:"

			' Set the contact information from the certificate
			signature.ContactInfo = cert.GetNameInfo(X509NameType.SimpleName, True)

			' Set the label for the date
			signature.DateLabel = "Date:"

			' Set the current date as the signing date
			signature.Date = Date.Now

			' Set the label for the location
			signature.LocationInfoLabel = "Location:"

			' Set the location information
			signature.LocationInfo = "Chengdu"

			' Set the label for the reason
			signature.ReasonLabel = "Reason: "

			' Set the reason for signing
			signature.Reason = "The certificate of this document"

			' Set the label for the distinguished name
			signature.DistinguishedNameLabel = "DN: "

			' Get the issuer's name from the certificate and set it as the distinguished name
			signature.DistinguishedName = cert.IssuerName.Name

			' Set the document permissions for the certification
			signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges

			' Enable certification
			signature.Certificated = True

			' Set the font for the sign details
			signature.SignDetailsFont = New PdfFont(PdfFontFamily.TimesRoman, 10.0F)

			' Set the font for the sign name
			signature.SignNameFont = New PdfFont(PdfFontFamily.Courier, 15)

			' Set the sign image layout mode
			signature.SignImageLayout = SignImageLayout.None

			' Save the PDF document with the digital signature
			doc.SaveToFile(result, FileFormat.PDF)

			' Close the PDF document
			doc.Close()

			'Show the result file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
'''    
'''    * Custom class 
'''    * 
	Friend Class CustomPKCS7SignatureFormatterWithAPI
		Implements IPdfSignatureFormatter
		<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
		Public Structure CRYPTOAPI_BLOB
			Public cbData As Integer
			Public pbData As IntPtr
		End Structure

		<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
		Public Structure CRYPT_ALGORITHM_IDENTIFIER
			Public pszObjId As String
			Public Parameters As CRYPTOAPI_BLOB
		End Structure

		<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
		Public Structure CRYPT_SIGN_MESSAGE_PARA
			Public cbSize As UInt32
			Public dwMsgEncodingType As UInt32
			Public pSigningCert As IntPtr
			Public HashAlgorithm As CRYPT_ALGORITHM_IDENTIFIER
			Public pvHashAuxInfo As IntPtr
			Public cMsgCert As UInt32
			Public rgpMsgCert As IntPtr
			Public cMsgCrl As UInt32
			Public rgpMsgCrl As IntPtr
			Public cAuthAttr As UInt32
			Public rgAuthAttr As IntPtr
			Public cUnauthAttr As UInt32
			Public rgUnauthAttr As IntPtr
			Public dwFlags As UInt32
			Public dwInnerContentType As UInt32
			Public HashEncryptionAlgorithm As CRYPT_ALGORITHM_IDENTIFIER
			Public pvHashEncryptionAuxInfo As IntPtr
		End Structure

		<Flags>
		Public Enum FormatMessageFlags
			AllocateBuffer = &H100
			IgnoreInserts = &H200
			FromString = &H400
			FromHmodule = &H800
			FromSystem = &H1000
			ArgumentArray = &H2000
		End Enum

		<DllImport("kernel32.dll")>
		Shared Function GetLastError() As UInteger
		End Function

		<DllImport("kernel32.dll", EntryPoint := "FormatMessage", CharSet := CharSet.Ansi)>
		Shared Function FormatMessage(ByVal dwFlags As FormatMessageFlags, ByVal lpSource As IntPtr, ByVal messageId As UInteger, ByVal dwLanguageId As UInteger, ByRef lpBuffer As IntPtr, ByVal nSize As UInteger, ByVal Arguments As IntPtr) As UInteger
		End Function

		<DllImport("Crypt32.dll", EntryPoint:="CryptSignMessage", CharSet:=CharSet.Ansi)>
		Shared Function CryptSignMessage(ByRef pSignPara As CRYPT_SIGN_MESSAGE_PARA, ByVal fDetachedSignature As Boolean, ByVal cToBeSigned As UInt32, ByVal rgpbToBeSigned() As IntPtr, ByVal rgcbToBeSigned() As Integer, ByVal pbSignedBlob As IntPtr, ByRef pcbSignedBlob As UInt32) As Boolean
		End Function

		Private Const CRYPT_USER_KEYSET As UInteger = &H1000
		Private Const CERT_SYSTEM_STORE_CURRENT_USER As UInteger = &H10000
		Private Const CERT_SYSTEM_STORE_LOCAL_MACHINE As UInteger = &H20000
		Private Const CERT_STORE_READONLY_FLAG As UInteger = &H8000
		Private Const CERT_STORE_OPEN_EXISTING_FLAG As UInteger = &H4000
		Private Const X509_ASN_ENCODING As UInteger = &H1
		Private Const PKCS_7_ASN_ENCODING As UInteger = &H10000
		Private Const OID_SHA As String = "1.3.14.3.2.26"

		Private m_certificate As X509Certificate2 = Nothing

		Public m_parameters As New Dictionary(Of String, Object)()
		''' <summary>
		''' Parameters for the encoding of the signature.
		''' 1.Key:Filter,String
		'''   Required
		'''   The name of the preferred signature handler to use when validating this signature.
		''' 2.SubFilter,String
		'''   Required
		'''   A name that describes the encoding of the signature value.
		'''   PDF 1.6 defines the following values for public-key cryptographic signatures: adbe.x509.rsa_sha1, adbe.pkcs7.detached, and adbe.pkcs7.sha1
		''' 3.Cert,X509Certificate2
		'''   Required when SubFilter is adbe.x509.rsa_sha1
		''' </summary>
		Public ReadOnly Property Parameters() As Dictionary(Of String, Object) Implements IPdfSignatureFormatter.Parameters
			Get
				Return m_parameters
			End Get
		End Property

		''' <summary>
		''' Construct a new instance.
		''' </summary>
		''' <param name="certificate">The signing certificate.</param>
		Public Sub New(ByVal certificate As X509Certificate2)
			If Nothing Is certificate Then
				Throw New ArgumentNullException("certificate")
			End If
			m_certificate = certificate
			'Set the details of signature
			Parameters.Add("Filter", "Adobe.PPKMS")
			Parameters.Add("SubFilter", "adbe.pkcs7.detached")
			Parameters.Add("SignatureLength", 9999)
			Parameters.Add("SoftwareModuleName", "Spire.Pdf")
		End Sub

		''' <summary>
		''' Sign.
		''' </summary>
		''' <param name="content">The data to be signed.</param>
		''' <returns>The signature.</returns>
		Public Function Sign(ByVal content() As Byte) As Byte() Implements IPdfSignatureFormatter.Sign
			Dim signatureLength As UInteger = GetSignatureLength()

			Dim signParams As CRYPT_SIGN_MESSAGE_PARA = CreateSignParams()
			Dim toBeSignedDataBlockCount As UInteger = 1
			Dim toBeSignedDataBlocks(0) As IntPtr
			toBeSignedDataBlocks(0) = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(content.Length)
			System.Runtime.InteropServices.Marshal.Copy(content, 0, toBeSignedDataBlocks(0), content.Length)
			Dim toBeSignedDataBlockSizes(0) As Integer
			toBeSignedDataBlockSizes(0) = content.Length
			Dim signature As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(CInt(signatureLength))

			CryptSignMessage(signParams, True, CUInt(toBeSignedDataBlockCount), toBeSignedDataBlocks, toBeSignedDataBlockSizes, signature, signatureLength)

			Dim result(signatureLength - 1) As Byte
			System.Runtime.InteropServices.Marshal.Copy(signature, result, 0, result.Length)

			System.Runtime.InteropServices.Marshal.FreeCoTaskMem(toBeSignedDataBlocks(0))
			System.Runtime.InteropServices.Marshal.FreeCoTaskMem(signature)
			Return result
		End Function

		Private Function GetSignatureLength() As UInteger
			' NOTE: We just have to pass in the method any string, it doesn't
			' matter which exactly.
			Dim text As String = Environment.CurrentDirectory

			Dim data() As Byte = System.Text.Encoding.UTF8.GetBytes(text)
			Dim lengthConvertedString() As Integer = { data.Length }
			Dim ptr As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(data.Length)
			System.Runtime.InteropServices.Marshal.Copy(data, 0, ptr, data.Length)
			Dim res() As IntPtr = { ptr }

			Dim signParams As CRYPT_SIGN_MESSAGE_PARA = CreateSignParams()
			Dim signatureLength As UInteger = 0

			Dim failed As Boolean = Not CryptSignMessage(signParams, True, 1, res, lengthConvertedString, IntPtr.Zero, signatureLength)

			If failed Then
				Dim lastError As UInteger = GetLastError()
				Dim lpMsgBuf As IntPtr = IntPtr.Zero
				Dim dwChars As UInteger = FormatMessage(FormatMessageFlags.AllocateBuffer Or FormatMessageFlags.FromSystem Or FormatMessageFlags.IgnoreInserts, IntPtr.Zero, lastError, 0, lpMsgBuf, 0, IntPtr.Zero)
				If dwChars = 0 Then
					Return 0
				End If
			End If

			Return signatureLength
		End Function

		Private Function CreateSignParams() As CRYPT_SIGN_MESSAGE_PARA
			Dim signParams As New CRYPT_SIGN_MESSAGE_PARA()
			signParams.cbSize = CUInt(System.Runtime.InteropServices.Marshal.SizeOf(GetType(CRYPT_SIGN_MESSAGE_PARA)))
			signParams.dwMsgEncodingType = PKCS_7_ASN_ENCODING Or X509_ASN_ENCODING
			signParams.pSigningCert = m_certificate.Handle
			signParams.HashAlgorithm.pszObjId = OID_SHA
			signParams.HashAlgorithm.Parameters.cbData = 0
			signParams.pvHashAuxInfo = New IntPtr(0)
			signParams.cMsgCert = 1
			signParams.rgpMsgCert = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(GetType(IntPtr)))
			System.Runtime.InteropServices.Marshal.StructureToPtr(m_certificate.Handle, signParams.rgpMsgCert, True)
			signParams.cMsgCrl = 0
			signParams.rgpMsgCrl = New IntPtr(0)
			signParams.cAuthAttr = 0
			signParams.rgAuthAttr = New IntPtr(0)
			signParams.cUnauthAttr = 0
			signParams.rgUnauthAttr = New IntPtr(0)
			signParams.dwFlags = 0
			signParams.dwInnerContentType = 0
			Return signParams
		End Function

	End Class
End Namespace
