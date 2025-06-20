Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddSVGToPDF
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim existingPDF As New PdfDocument()

            ' Load an existing PDF document from file
            existingPDF.LoadFromFile("..\..\..\..\..\..\Data\SampleB_1.pdf")

            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load an SVG file as a document template
            doc.LoadFromSvg("..\..\..\..\..\..\Data\template.svg")

            ' Create a template from the first page of the document
            Dim template As PdfTemplate = doc.Pages(0).CreateTemplate()

            ' Draw the template onto the canvas of the first page of the existing PDF
            existingPDF.Pages(0).Canvas.DrawTemplate(doc.Pages(0).CreateTemplate(), New PointF(50, 250), New SizeF(200, 200))

            ' Specify the output file name
            Dim result As String = "AddSVGToPDF_out.pdf"

            ' Save the modified existing PDF to a new file
            existingPDF.SaveToFile(result, FileFormat.PDF)

            ' Close the PDF document
            existingPDF.Close()

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
