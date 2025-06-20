Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Attachments

Namespace GetAllAttachments
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object 
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified input file
            pdf.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_2.pdf")

            ' Get the collection of attachments from the PDF document
            Dim collection As PdfAttachmentCollection = pdf.Attachments

            ' Iterate through each attachment in the collection
            For i As Integer = 0 To collection.Count - 1
                ' Write the data of the attachment to a file using its original filename
                File.WriteAllBytes(collection(i).FileName, collection(i).Data)
            Next i

            ' Close the PDF document
            pdf.Close()
        End Sub
    End Class
End Namespace
