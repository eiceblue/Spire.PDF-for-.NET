Imports System.Text
Imports Spire.Pdf
Imports System.IO

Namespace GetDocumentProperties
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\PDFTemplate-Az.pdf"

            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the document from the input file
            doc.LoadFromFile(input)

            ' Get the document information
            Dim docInfo As PdfDocumentInformation = doc.DocumentInformation

            ' Create a StringBuilder object to store the document properties
            Dim builder As New StringBuilder()

            ' Append the author property to the StringBuilder
            builder.AppendLine("Author: " & docInfo.Author)

            ' Append the creation date property to the StringBuilder
            builder.AppendLine("Creation Date: " & docInfo.CreationDate)

            ' Append the keywords property to the StringBuilder
            builder.AppendLine("Keywords: " & docInfo.Keywords)

            ' Append the modification date property to the StringBuilder
            builder.AppendLine("Modify Date: " & docInfo.ModificationDate)

            ' Append the subject property to the StringBuilder
            builder.AppendLine("Subject: " & docInfo.Subject)

            ' Append the title property to the StringBuilder
            builder.AppendLine("Title: " & docInfo.Title)

            ' Specify the output file path
            Dim result As String = "GetDocumentProperties_out.txt"

            ' Write the contents of the StringBuilder to the output file
            File.WriteAllText(result, builder.ToString())

            ' Close the PDF document
            doc.Close()

            ' Launch the result file
            DocumentViewer(result)
        End Sub

        Private Sub DocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
