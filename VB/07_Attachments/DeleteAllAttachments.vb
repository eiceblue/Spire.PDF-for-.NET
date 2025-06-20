Imports Spire.Pdf
Imports Spire.Pdf.Attachments

Namespace DeleteAllAttachments
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Set the input file path for the PDF document
            Dim input As String = "..\..\..\..\..\..\Data\DeleteAllAttachments.pdf"

            ' Create a new PdfDocument object 
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified input file
            doc.LoadFromFile(input)

            ' Get the collection of attachments from the PDF document
            Dim attachments As PdfAttachmentCollection = doc.Attachments

            ' Clear all attachments from the collection
            attachments.Clear()

            ' Set the output file path for the modified PDF document
            Dim output As String = "DeleteAllAttachments.pdf"

            ' Save the modified PDF document to the specified output file
            doc.SaveToFile(output)

            ' Close the PDF document
            doc.Close()

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
