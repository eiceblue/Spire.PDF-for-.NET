Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid

Namespace MergeCells
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load an existing PDF document from a file
            doc.LoadFromFile("..\..\..\..\..\..\Data\MergeCells.pdf")
            ' Get the first page of the loaded document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a new PdfGrid object
            Dim grid As New PdfGrid()

            ' Add 5 columns to the grid
            grid.Columns.Add(5)

            ' Set the width of each column in the grid
            For j As Integer = 0 To grid.Columns.Count - 1
                grid.Columns(j).Width = 100
            Next j

            ' Create two rows in the grid
            Dim row0 As PdfGridRow = grid.Rows.Add()
            Dim row1 As PdfGridRow = grid.Rows.Add()

            ' Set the height of each row in the grid
            Dim height As Single = 21.0F
            For i As Integer = 0 To grid.Rows.Count - 1
                grid.Rows(i).Height = height
            Next i

            ' Draw the grid on the page at a specified location
            grid.Draw(page, New PointF(50, 410))

            ' Customize the font style for the cells in row0 and row1
            row0.Style.Font = New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold), True)
            row1.Style.Font = New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Italic), True)

            ' Set the cell values and formatting for row0
            row0.Cells(0).Value = "Corporation"
            row0.Cells(0).RowSpan = 2

            row0.Cells(1).Value = "B&K Undersea Photo"
            row0.Cells(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
            row0.Cells(1).ColumnSpan = 3

            row0.Cells(4).Value = "World"
            row0.Cells(4).Style.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Bold Or FontStyle.Italic), True)
            row0.Cells(4).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
            row0.Cells(4).Style.BackgroundBrush = PdfBrushes.LightGreen

            ' Set the cell values and formatting for row1
            row1.Cells(1).Value = "Diving International Unlimited"
            row1.Cells(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
            row1.Cells(1).ColumnSpan = 4

            ' Draw the grid with the updated cell values and formatting
            grid.Draw(page, New PointF(50, 480))

            ' Save the modified document to a file
            doc.SaveToFile("MergeCells.pdf")

            ' Close the document
            doc.Close()

            ' Launch the document
            PDFDocumentViewer("MergeCells.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
