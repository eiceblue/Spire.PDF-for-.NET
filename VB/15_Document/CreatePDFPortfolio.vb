Imports Spire.Pdf
Imports Spire.Pdf.Collections
Imports System.IO

Namespace CreatePDFPortfolio
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Get an array of file paths from the specified directory.
            Dim files() As String = Directory.GetFiles("..\..\..\..\..\..\Data\CreatePDFPortfolio")

            ' Specify the target file path for the PDF portfolio.
            Dim targetFile As String = "..\..\..\..\..\..\Data\Sample.pdf"

            ' Create a new PdfDocument object with the target file path.
            Dim doc As New PdfDocument(targetFile)

            ' Iterate through the files array and add each file to the document's collection.
            For i As Integer = 0 To files.Length - 1
                doc.Collection.Folders.AddFile(files(i))

                ' Create a subfolder for each file and add the file to it.
                Dim folder As PdfFolder = doc.Collection.Folders.CreateSubfolder("SubFolder" & (i + 1))
                folder.AddFile(files(i))
            Next i

            ' Specify the file name for the resulting PDF portfolio.
            Dim result As String = "CreatePDFPortfolio_out.pdf"

            ' Save the document as a PDF portfolio to the specified file.
            doc.SaveToFile(result)

            ' Close the document.
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub

        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub
    End Class
End Namespace
