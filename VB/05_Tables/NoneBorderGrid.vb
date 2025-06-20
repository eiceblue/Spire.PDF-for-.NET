Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid

Namespace NoneBorderGrid
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Add a new page to the document
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Create a new PdfGrid object
            Dim grid As New PdfGrid()

            ' Add a single row to the grid
            Dim row1 As PdfGridRow = grid.Rows.Add()

            ' Add 2 columns to the grid
            grid.Columns.Add(2)

            ' Set the dash style of the bottom, top, right, and left borders of the first cell in row1 to None
            row1.Cells(0).Style.Borders.Bottom.DashStyle = PdfDashStyle.None
            row1.Cells(0).Style.Borders.Top.DashStyle = PdfDashStyle.None
            row1.Cells(0).Style.Borders.Right.DashStyle = PdfDashStyle.None
            row1.Cells(0).Style.Borders.Left.DashStyle = PdfDashStyle.None

            ' Set the value of each cell in row1 to "Hello Word!"
            Dim str As String = "Hello Word!"
            For i As Integer = 0 To grid.Columns.Count - 1
                row1.Cells(i).Value = str
            Next i

            ' Draw the grid on the page at the specified location (0, 50)
            grid.Draw(page, New PointF(0, 50))

            ' Save the document to a file named "PDFNoneBorderGrid.pdf" in PDF format
            Dim result As String = "PDFNoneBorderGrid.pdf"
            doc.SaveToFile(result, FileFormat.PDF)

            ' Close the document
            doc.Close()

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
