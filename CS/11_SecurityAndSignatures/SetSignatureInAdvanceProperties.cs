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
            //Input and output file paths
            string input = @"..\..\..\..\..\..\Data\SampleB_1.pdf";
            string inputFile_img = @"..\..\..\..\..\..\Data\logo.png";
            string result = "SetDetailsOfSignatureInAdvanceProperties_result.pdf";
            string pfxPath = @"..\..\..\..\..\..\Data\gary.pfx";

            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);
            System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);
            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);

            X509Certificate2 cert = new X509Certificate2(pfxPath, "e-iceblue");
            CustomPKCS7SignatureFormatterWithAPI customPKCS7SignatureFormatter = new CustomPKCS7SignatureFormatterWithAPI(cert);
            
            PdfSignature signature = new PdfSignature(doc, doc.Pages[0], customPKCS7SignatureFormatter, "signature0");
            signature.Bounds = new RectangleF(new PointF(250, 660), new SizeF(250, 90));
            //Load sign image source.
            signature.SignImageSource = PdfImage.FromFile(inputFile_img);
            //Set the dispay mode of graphics, if not set any, the default one will be applied
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
            signature.NameLabel = "Signer:";
            signature.Name = cert.GetNameInfo(X509NameType.SimpleName, true);
            signature.ContactInfoLabel = "ContactInfo:";
            signature.ContactInfo = cert.GetNameInfo(X509NameType.SimpleName, true);
            signature.DateLabel = "Date:";
            signature.Date = DateTime.Now;
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "Chengdu";
            signature.ReasonLabel = "Reason: ";
            signature.Reason = "The certificate of this document";
            signature.DistinguishedNameLabel = "DN: ";
            signature.DistinguishedName = cert.IssuerName.Name;
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
            signature.Certificated = true;
            //Set fonts, if not set, default ones will be applied
            signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
            signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);
            //Set the sign image layout mode
            signature.SignImageLayout = SignImageLayout.None;
            //Save pdf file.
            doc.SaveToFile(result, FileFormat.PDF);
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
    class CustomPKCS7SignatureFormatterWithAPI : IPdfSignatureFormatter
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct CRYPTOAPI_BLOB
        {
            public int cbData;
            public IntPtr pbData;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct CRYPT_ALGORITHM_IDENTIFIER
        {
            public string pszObjId;
            public CRYPTOAPI_BLOB Parameters;
        }

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

        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        [DllImport("kernel32.dll", EntryPoint = "FormatMessage", CharSet = CharSet.Ansi)]
        static extern uint FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource,
            uint messageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, IntPtr Arguments);

        [DllImport("Crypt32.dll", EntryPoint = "CryptSignMessage", CharSet = CharSet.Ansi)]
        static extern bool CryptSignMessage
            (
            ref CRYPT_SIGN_MESSAGE_PARA pSignPara,
            bool fDetachedSignature,
            UInt32 cToBeSigned,
            IntPtr[] rgpbToBeSigned,
            int[] rgcbToBeSigned,
            IntPtr pbSignedBlob,
            ref UInt32 pcbSignedBlob
            );

        private const uint CRYPT_USER_KEYSET = 0x00001000;
        private const uint CERT_SYSTEM_STORE_CURRENT_USER = 0x00010000;
        private const uint CERT_SYSTEM_STORE_LOCAL_MACHINE = 0x00020000;
        private const uint CERT_STORE_READONLY_FLAG = 0x00008000;
        private const uint CERT_STORE_OPEN_EXISTING_FLAG = 0x00004000;
        private const uint X509_ASN_ENCODING = 0x00000001;
        private const uint PKCS_7_ASN_ENCODING = 0x00010000;
        private const string OID_SHA = "1.3.14.3.2.26";

        private X509Certificate2 m_certificate = null;

        public Dictionary<String, Object> m_parameters = new Dictionary<string, object>();
        /// <summary>
        /// Parameters for the encoding of the signature.
        /// 1.Key:Filter,String
        ///   Required
        ///   The name of the preferred signature handler to use when validating this signature.
        /// 2.SubFilter,String
        ///   Required
        ///   A name that describes the encoding of the signature value.
        ///   PDF 1.6 defines the following values for public-key cryptographic signatures: adbe.x509.rsa_sha1, adbe.pkcs7.detached, and adbe.pkcs7.sha1
        /// 3.Cert,X509Certificate2
        ///   Required when SubFilter is adbe.x509.rsa_sha1
        /// </summary>
        public Dictionary<String, Object> Parameters { get { return m_parameters; } }

        /// <summary>
        /// Construct a new instance.
        /// </summary>
        /// <param name="certificate">The signing certificate.</param>
        public CustomPKCS7SignatureFormatterWithAPI(X509Certificate2 certificate)
        {
            if (null == certificate)
            {
                throw new ArgumentNullException("certificate");
            }
            m_certificate = certificate;
            //Set the details of signature
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
        public byte[] Sign(byte[] content)
        {
            uint signatureLength = GetSignatureLength();

            CRYPT_SIGN_MESSAGE_PARA signParams = CreateSignParams();
            uint toBeSignedDataBlockCount = 1;
            IntPtr[] toBeSignedDataBlocks = new IntPtr[1];
            toBeSignedDataBlocks[0] = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(content.Length);
            System.Runtime.InteropServices.Marshal.Copy(content, 0, toBeSignedDataBlocks[0], content.Length);
            int[] toBeSignedDataBlockSizes = new int[1];
            toBeSignedDataBlockSizes[0] = content.Length;
            IntPtr signature = System.Runtime.InteropServices.Marshal.AllocCoTaskMem((int)signatureLength);

            CryptSignMessage(ref signParams, true, (uint)toBeSignedDataBlockCount, toBeSignedDataBlocks, toBeSignedDataBlockSizes,
                signature, ref signatureLength);

            byte[] result = new byte[signatureLength];
            System.Runtime.InteropServices.Marshal.Copy(signature, result, 0, result.Length);

            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(toBeSignedDataBlocks[0]);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(signature);
            return result;
        }

        private uint GetSignatureLength()
        {
            // NOTE: We just have to pass in the method any string, it doesn't
            // matter which exactly.
            string text = Environment.CurrentDirectory;

            byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
            int[] lengthConvertedString = { data.Length };
            IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(data.Length);
            System.Runtime.InteropServices.Marshal.Copy(data, 0, ptr, data.Length);
            IntPtr[] res = new IntPtr[] { ptr };

            CRYPT_SIGN_MESSAGE_PARA signParams = CreateSignParams();
            uint signatureLength = 0;

            bool failed = !CryptSignMessage(ref signParams, true, 1, res, lengthConvertedString,
                IntPtr.Zero, ref signatureLength);

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

            return signatureLength;
        }

        private CRYPT_SIGN_MESSAGE_PARA CreateSignParams()
        {
            CRYPT_SIGN_MESSAGE_PARA signParams = new CRYPT_SIGN_MESSAGE_PARA();
            signParams.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(CRYPT_SIGN_MESSAGE_PARA));
            signParams.dwMsgEncodingType = PKCS_7_ASN_ENCODING | X509_ASN_ENCODING;
            signParams.pSigningCert = m_certificate.Handle;
            signParams.HashAlgorithm.pszObjId = OID_SHA;
            signParams.HashAlgorithm.Parameters.cbData = 0;
            signParams.pvHashAuxInfo = new IntPtr(0);
            signParams.cMsgCert = 1;
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
