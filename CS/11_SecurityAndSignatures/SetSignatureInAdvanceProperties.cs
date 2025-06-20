using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SetSignatureInAdvanceProperties
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Input and output file paths
            string input = @"..\..\..\..\..\..\Data\SampleB_1.pdf";
            string inputFile_img = @"..\..\..\..\..\..\Data\logo.png";
            string result = "SetDetailsOfSignatureInAdvanceProperties_result.pdf";
            string pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";

            // Create a new instance of the PdfDocument class
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified input file path
            doc.LoadFromFile(input);

            // Open the X509 certificate store in read-only mode
            System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);
            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);

            // Load the X509 certificate from the specified PFX file and its password
            X509Certificate2 cert = new X509Certificate2(pfxPath, "e-iceblue");

            // Create a custom PKCS7 signature formatter using the loaded certificate
            CustomPKCS7SignatureFormatterWithAPI customPKCS7SignatureFormatter = new CustomPKCS7SignatureFormatterWithAPI(cert);

            // Create a PdfSignature object for the first page of the document with the custom signature formatter and signature name
            PdfSignature signature = new PdfSignature(doc, doc.Pages[0], customPKCS7SignatureFormatter, "signature0");

            // Set the position and size of the signature appearance on the page
            signature.Bounds = new RectangleF(new PointF(250, 660), new SizeF(250, 90));

            // Load an image file as the sign image source
            signature.SignImageSource = PdfImage.FromFile(inputFile_img);

            // Set the display mode of graphics for the signature appearance
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

            // Set the label and value for the signer's name in the signature details
            signature.NameLabel = "Signer:";
            signature.Name = cert.GetNameInfo(X509NameType.SimpleName, true);

            // Set the label and value for the contact information in the signature details
            signature.ContactInfoLabel = "ContactInfo:";
            signature.ContactInfo = cert.GetNameInfo(X509NameType.SimpleName, true);

            // Set the label and value for the date in the signature details
            signature.DateLabel = "Date:";
            signature.Date = DateTime.Now;

            // Set the label and value for the location information in the signature details
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "Chengdu";

            // Set the label and value for the reason in the signature details
            signature.ReasonLabel = "Reason: ";
            signature.Reason = "The certificate of this document";

            // Set the label and value for the distinguished name in the signature details
            signature.DistinguishedNameLabel = "DN: ";
            signature.DistinguishedName = cert.IssuerName.Name;

            // Specify the document permissions for the certified PDF
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;

            // Set the Certificated property to true to enable certification
            signature.Certificated = true;

            // Set the fonts to be used for the signature details and signer's name
            signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
            signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);

            // Set the layout mode for the sign image
            signature.SignImageLayout = SignImageLayout.None;

            // Save the modified PDF document with the applied digital signature to the specified output file path
            doc.SaveToFile(result, FileFormat.PDF);

            // Close the PDF document
            doc.Close();

            //Show the result file
            PDFDocumentViewer(result);
        }
        private void PDFDocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
    /**
    * Custom class 
    * */
    // Define a class named CustomPKCS7SignatureFormatterWithAPI that implements the IPdfSignatureFormatter interface.
    class CustomPKCS7SignatureFormatterWithAPI : IPdfSignatureFormatter
    {
        // Define a struct named CRYPTOAPI_BLOB with two fields: cbData and pbData.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct CRYPTOAPI_BLOB
        {
            public int cbData;
            public IntPtr pbData;
        }

        // Define a struct named CRYPT_ALGORITHM_IDENTIFIER with two fields: pszObjId and Parameters.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct CRYPT_ALGORITHM_IDENTIFIER
        {
            public string pszObjId;
            public CRYPTOAPI_BLOB Parameters;
        }

        // Define a struct named CRYPT_SIGN_MESSAGE_PARA with multiple fields.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct CRYPT_SIGN_MESSAGE_PARA
        {
            public UInt32 cbSize;
            public UInt32 dwMsgEncodingType;
            public IntPtr pSigningCert;
            public CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;
            public IntPtr pvHashAuxInfo;
            public UInt32 cMsgCert;
            public IntPtr rgpMsgCert;
            public UInt32 cMsgCrl;
            public IntPtr rgpMsgCrl;
            public UInt32 cAuthAttr;
            public IntPtr rgAuthAttr;
            public UInt32 cUnauthAttr;
            public IntPtr rgUnauthAttr;
            public UInt32 dwFlags;
            public UInt32 dwInnerContentType;
            public CRYPT_ALGORITHM_IDENTIFIER HashEncryptionAlgorithm;
            public IntPtr pvHashEncryptionAuxInfo;
        }

        // Define an enum named FormatMessageFlags with multiple flag values.
        [Flags]
        enum FormatMessageFlags
        {
            AllocateBuffer = 0x00000100,
            IgnoreInserts = 0x00000200,
            FromString = 0x00000400,
            FromHmodule = 0x00000800,
            FromSystem = 0x00001000,
            ArgumentArray = 0x00002000
        }

        // Import external functions from kernel32.dll and Crypt32.dll using DllImport.
        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        [DllImport("kernel32.dll", EntryPoint = "FormatMessage", CharSet = CharSet.Ansi)]
        static extern uint FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource,
            uint messageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, IntPtr Arguments);

        [DllImport("Crypt32.dll", EntryPoint = "CryptSignMessage", CharSet = CharSet.Ansi)]
        static extern bool CryptSignMessage(
            ref CRYPT_SIGN_MESSAGE_PARA pSignPara,
            bool fDetachedSignature,
            UInt32 cToBeSigned,
            IntPtr[] rgpbToBeSigned,
            int[] rgcbToBeSigned,
            IntPtr pbSignedBlob,
            ref UInt32 pcbSignedBlob
        );

        // Define constants used in the class.
        private const uint CRYPT_USER_KEYSET = 0x00001000;
        private const uint CERT_SYSTEM_STORE_CURRENT_USER = 0x00010000;
        private const uint CERT_SYSTEM_STORE_LOCAL_MACHINE = 0x00020000;
        private const uint CERT_STORE_READONLY_FLAG = 0x00008000;
        private const uint CERT_STORE_OPEN_EXISTING_FLAG = 0x00004000;
        private const uint X509_ASN_ENCODING = 0x00000001;
        private const uint PKCS_7_ASN_ENCODING = 0x00010000;
        private const string OID_SHA = "1.3.14.3.2.26";

        private X509Certificate2 m_certificate = null;

        // Define a dictionary named m_parameters to store the signature parameters.
        public Dictionary<String, Object> m_parameters = new Dictionary<string, object>();

        // Define a property named Parameters that returns the m_parameters dictionary.
        public Dictionary<String, Object> Parameters { get { return m_parameters; } }

        // Constructor for the CustomPKCS7SignatureFormatterWithAPI class.
        public CustomPKCS7SignatureFormatterWithAPI(X509Certificate2 certificate)
        {
            // Check if the certificate parameter is null.
            if (null == certificate)
            {
                throw new ArgumentNullException("certificate");
            }

            // Set the certificate and initialize the signature parameters.
            m_certificate = certificate;
            Parameters.Add("Filter", "Adobe.PPKMS");
            Parameters.Add("SubFilter", "adbe.pkcs7.detached");
            Parameters.Add("SignatureLength", 9999);
            Parameters.Add("SoftwareModuleName", "Spire.Pdf");
        }


        /// <summary>
        /// Sign.
        /// </summary>
        /// <param name="content">The data to be signed.</param>
        /// <returns>The signature.</returns>
        // Sign method: Signs the provided content and returns the signature as a byte array.
        public byte[] Sign(byte[] content)
        {
            // Get the length of the signature.
            uint signatureLength = GetSignatureLength();

            // Create the parameters for signing.
            CRYPT_SIGN_MESSAGE_PARA signParams = CreateSignParams();

            // Prepare the data to be signed.
            uint toBeSignedDataBlockCount = 1;
            IntPtr[] toBeSignedDataBlocks = new IntPtr[1];
            toBeSignedDataBlocks[0] = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(content.Length);
            System.Runtime.InteropServices.Marshal.Copy(content, 0, toBeSignedDataBlocks[0], content.Length);
            int[] toBeSignedDataBlockSizes = new int[1];
            toBeSignedDataBlockSizes[0] = content.Length;

            // Allocate memory for the signature.
            IntPtr signature = System.Runtime.InteropServices.Marshal.AllocCoTaskMem((int)signatureLength);

            // Sign the message.
            CryptSignMessage(ref signParams, true, (uint)toBeSignedDataBlockCount, toBeSignedDataBlocks, toBeSignedDataBlockSizes,
                signature, ref signatureLength);

            // Copy the signature to a byte array.
            byte[] result = new byte[signatureLength];
            System.Runtime.InteropServices.Marshal.Copy(signature, result, 0, result.Length);

            // Free allocated memory.
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(toBeSignedDataBlocks[0]);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(signature);

            // Return the signature.
            return result;
        }

        // GetSignatureLength method: Retrieves the length of the signature.
        private uint GetSignatureLength()
        {
            // NOTE: We just have to pass in the method any string, it doesn't matter which exactly.
            string text = Environment.CurrentDirectory;

            // Convert the text to bytes.
            byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
            int[] lengthConvertedString = { data.Length };

            // Allocate memory for the converted string.
            IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(data.Length);
            System.Runtime.InteropServices.Marshal.Copy(data, 0, ptr, data.Length);
            IntPtr[] res = new IntPtr[] { ptr };

            // Create sign parameters.
            CRYPT_SIGN_MESSAGE_PARA signParams = CreateSignParams();

            // Initialize signature length as 0.
            uint signatureLength = 0;

            // Try to sign the message to get the required signature length.
            bool failed = !CryptSignMessage(ref signParams, true, 1, res, lengthConvertedString,
                IntPtr.Zero, ref signatureLength);

            // If signing failed, handle the error and return 0.
            if (failed)
            {
                uint lastError = GetLastError();
                IntPtr lpMsgBuf = IntPtr.Zero;
                uint dwChars =
                    FormatMessage(FormatMessageFlags.AllocateBuffer | FormatMessageFlags.FromSystem | FormatMessageFlags.IgnoreInserts,
                    IntPtr.Zero, lastError, 0, ref lpMsgBuf, 0, IntPtr.Zero);
                if (dwChars == 0)
                {
                    return 0;
                }
            }

            // Return the calculated signature length.
            return signatureLength;
        }

        // CreateSignParams method: Creates and initializes the sign parameters.
        private CRYPT_SIGN_MESSAGE_PARA CreateSignParams()
        {
            // Create a new instance of the CRYPT_SIGN_MESSAGE_PARA structure.
            CRYPT_SIGN_MESSAGE_PARA signParams = new CRYPT_SIGN_MESSAGE_PARA();

            // Set the size of the structure.
            signParams.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(CRYPT_SIGN_MESSAGE_PARA));

            // Set the message encoding type to PKCS#7 and X.509.
            signParams.dwMsgEncodingType = PKCS_7_ASN_ENCODING | X509_ASN_ENCODING;

            // Set the signing certificate handle.
            signParams.pSigningCert = m_certificate.Handle;

            // Set the hash algorithm to SHA-1.
            signParams.HashAlgorithm.pszObjId = OID_SHA;
            signParams.HashAlgorithm.Parameters.cbData = 0;

            // Set auxiliary information for hashing.
            signParams.pvHashAuxInfo = new IntPtr(0);

            // Set the number of certificates in the message.
            signParams.cMsgCert = 1;

            // Allocate memory for the certificate handle array.
            signParams.rgpMsgCert = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(typeof(IntPtr)));
            System.Runtime.InteropServices.Marshal.StructureToPtr(m_certificate.Handle, signParams.rgpMsgCert, true);
            signParams.cMsgCrl = 0;
            signParams.rgpMsgCrl = new IntPtr(0);
            signParams.cAuthAttr = 0;
            signParams.rgAuthAttr = new IntPtr(0);
            signParams.cUnauthAttr = 0;
            signParams.rgUnauthAttr = new IntPtr(0);
            signParams.dwFlags = 0;
            signParams.dwInnerContentType = 0;
            return signParams;
        }

    }
}
