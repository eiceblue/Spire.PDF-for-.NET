Imports Spire.Pdf.Conversion

Namespace ConvertToGrayPdf
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the output file name for the resulting gray PDF
            Dim output As String = "ConvertToGrayPdf-result.pdf"

            ' Create a new instance of PdfGrayConverter and specify the input file path
            Dim converter As New PdfGrayConverter("..\..\..\..\..\..\Data\ConvertToGrayPdf.pdf")

            ' Convert the file to a gray-scale PDF and save it to the specified output file
            converter.ToGrayPdf(output)

            ' Dispose the convertor
            converter.Dispose()

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
