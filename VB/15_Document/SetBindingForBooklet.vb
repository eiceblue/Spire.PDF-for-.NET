Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Utilities

Namespace SetBindingForBooklet
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified file path
            doc.LoadFromFile("..\..\..\..\..\..\Data\SetBindingForBooklet.pdf")

            ' Specify the output file path for saving the booklet result
            Dim outputFile As String = "result.pdf"

            ' Open a stream to create the output file
            Dim outputStream As Stream = File.Open(outputFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read)

            ' Create booklet options
            Dim bookletOptions As New BookletOptions()
            bookletOptions.BookletBinding = PdfBookletBindingMode.Left

            ' Calculate the width and height of the booklet pages
            Dim width As Single = PdfPageSize.A4.Width * 2
            Dim height As Single = PdfPageSize.A4.Height
            Dim size As New SizeF(width, height)

            ' Create the booklet using the input document, output stream, page size, and booklet options
            PdfBookletCreator.CreateBooklet(doc, outputStream, size, bookletOptions)

            ' Close the input document
            doc.Close()
            ' Close the stream
            outputStream.Close()

            ' Launch the result booklet file
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
