Imports Spire.Pdf.Conversion

Namespace OFDToPDF
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input OFD file path
            Dim inputFile As String = "..\..\..\..\..\..\Data\Sample.ofd"

            ' Create a new instance of OfdConverter and specify the input file path
            Dim converter As New OfdConverter(inputFile)

            ' Specify the output PDF file name
            Dim result As String = "OFDToPDF.pdf"

            ' Call the ToPdf method to convert OFD to PDF and save it to the specified output file
            converter.ToPdf(result)

            ' Dispose the convertor
            converter.Dispose()

            ' Launch the result file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
