Imports Spire.Pdf
Imports Spire.Pdf.Attachments
Imports Spire.Pdf.Collections

Namespace SortFileInPdf
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Add a custom field with the name "No", label "number", and type NumberField to the collection
            doc.Collection.AddCustomField("No", "number", CustomFieldType.NumberField)

            ' Add a file-related field with the name "Desc", label "desc", and type Desc to the collection
            doc.Collection.AddFileRelatedField("Desc", "desc", FileRelatedFieldType.Desc)

            ' Sort the collection based on the fields "No" (ascending) and "Desc" (ascending)
            doc.Collection.Sort(New String() {"No", "Desc"}, New Boolean() {True, True})

            ' Create a new PdfAttachment object
            Dim pdfAttachment As New PdfAttachment("..\..\..\..\..\..\Data\SampleB_1.pdf")

            ' Add the attachment to the collection
            doc.Collection.AddAttachment(pdfAttachment)

            ' Create and add more PdfAttachment objects to the collection
            pdfAttachment = New PdfAttachment("..\..\..\..\..\..\Data\SampleB_2.pdf")
            doc.Collection.AddAttachment(pdfAttachment)
            pdfAttachment = New PdfAttachment("..\..\..\..\..\..\Data\SampleB_3.pdf")
            doc.Collection.AddAttachment(pdfAttachment)

            ' Set field values for each attached file in the collection
            Dim i As Integer = 1
            For Each attachment As PdfAttachment In doc.Collection.AssociatedFiles
                attachment.SetFieldValue("No", i)
                attachment.SetFieldValue("Desc", attachment.FileName)
                i += 1
            Next attachment

            ' Specify the output file name for the sorted PDF document
            Dim output As String = "SortFileInPdf.pdf"

            ' Save the modified PDF document to the output file
            doc.SaveToFile(output, FileFormat.PDF)

            ' Close the PdfDocument object
            doc.Close()

            ' Launch the file
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
