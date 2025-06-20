Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SplitFileByParticularPage
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of PdfDocument object for the original PDF
            Dim oldPdf As New PdfDocument()

            ' Load the original PDF file from the specified path
            oldPdf.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

            ' Create a new instance of PdfDocument object for the modified PDF
            Dim newPdf As New PdfDocument()

            ' Declare a variable to store the PdfPageBase object
            Dim page As PdfPageBase

            ' Iterate through pages 1 and 2 of the original PDF
            For i As Integer = 1 To 2
                ' Add a new page to the modified PDF with the same size as the current page in the original PDF, and set margins to 0
                page = newPdf.Pages.Add(oldPdf.Pages(i).Size, New PdfMargins(0))

                ' Draw the template of the current page in the original PDF onto the new page at coordinates (0, 0)
                oldPdf.Pages(i).CreateTemplate().Draw(page, New PointF(0, 0))
            Next i

            ' Specify the filename for the output PDF
            Dim result As String = "SplitFileByParticularPage_out.pdf"

            ' Save the modified PDF document to the output file
            newPdf.SaveToFile(result)

            ' Close the modified PDF document
            newPdf.Close()

            ' Close the original PDF document
            oldPdf.Close()

            ' Launch the Pdf file
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
