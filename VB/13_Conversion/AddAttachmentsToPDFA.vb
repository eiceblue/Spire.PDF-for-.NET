Imports Spire.Pdf
Imports Spire.Pdf.Attachments
Imports Spire.Pdf.Conversion
Imports System.IO

Namespace AddAttachmentsToPDFA
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input PDF file path
            Dim input As String = "..\..\..\..\..\..\Data\SampleB_2.pdf"

            ' Create a new MemoryStream object
            Dim ms As New MemoryStream()

            ' Create a new instance of PdfStandardsConverter and specify the input file path
            Dim converter As New PdfStandardsConverter(input)

            ' Convert the PDF to PDF/A-1b standard and save it to the MemoryStream
            converter.ToPdfA1B(ms)

            ' Create a new PdfDocument object
            Dim newDoc As New PdfDocument()

            ' Load the converted PDF document from the MemoryStream
            newDoc.LoadFromStream(ms)

            ' Load files and add them as attachments to the PDF document
            Dim data() As Byte = File.ReadAllBytes("..\..\..\..\..\..\Data\SampleB_1.png")
            Dim attach1 As New PdfAttachment("attachment1.png", data)
            Dim data2() As Byte = File.ReadAllBytes("..\..\..\..\..\..\Data\SampleB_1.pdf")
            Dim attach2 As New PdfAttachment("attachment2.pdf", data2)
            newDoc.Attachments.Add(attach1)
            newDoc.Attachments.Add(attach2)

            ' Specify the output file name for the resulting PDF with attachments
            Dim output As String = "ToPDFAWithAttachments-result.pdf"

            ' Save the modified PDF document with attachments to a file
            newDoc.SaveToFile(output)

            ' Close the PdfDocument object
            newDoc.Close()

            ' Dispose the convertor
            converter.Dispose()

            ' Close the stream
            ms.Close()

            ' Launch the reuslt file
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
