Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid

Namespace EmbedGridInCell
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load an existing PDF document from file
            doc.LoadFromFile("..\..\..\..\..\..\Data\EmbedGridInCell.pdf")

            ' Get the first page of the loaded document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a new PdfGrid object
            Dim grid As New PdfGrid()

            ' Add a row to the grid
            Dim row As PdfGridRow = grid.Rows.Add()

            ' Add two columns to the grid
            grid.Columns.Add(2)

            ' Set the width of the first column
            grid.Columns(0).Width = 120

            ' Set the width of the second column
            grid.Columns(1).Width = 300

            ' Specify the size of the image to be embedded in the cell
            Dim imageSize As New SizeF(70, 70)

            ' Calculate the left and right padding for the cell
            Dim LR As Single = (grid.Columns(0).Width - imageSize.Width) / 2

            ' Set the cell padding for the grid
            grid.Style.CellPadding = New PdfPaddings(LR, LR, 1, 1)

            ' Create a PdfGridCellContentList object to hold the content of the cell
            Dim list As New PdfGridCellContentList()

            ' Create a PdfGridCellContent object for the image
            Dim textAndStyle As New PdfGridCellContent()
            textAndStyle.Image = PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png")
            textAndStyle.ImageSize = imageSize

            ' Add the image content to the list
            list.List.Add(textAndStyle)

            ' Set the value of the cell to the content list
            row.Cells(0).Value = list

            ' Create another PdfGrid object for embedding within a cell
            Dim grid2 As New PdfGrid()

            ' Add two columns to the second grid
            grid2.Columns.Add(2)

            ' Add a row to the second grid
            Dim newrow As PdfGridRow = grid2.Rows.Add()

            ' Set the widths of the columns in the second grid
            grid2.Columns(0).Width = 120
            grid2.Columns(1).Width = 120

            ' Set the value and string format for the cells in the second grid's row
            newrow.Cells(0).Value = "Embeded grid"
            newrow.Cells(0).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
            newrow.Cells(1).Value = "Embeded grid"
            newrow.Cells(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

            ' Set the value and string format for the cell in the first row, second column
            row.Cells(1).Value = grid2
            row.Cells(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

            ' Define an array of data strings
            Dim data() As String = {
    "VendorName;Address1 & City & State & Country",
    "Cacor Corporation;161 Southfield Rd  & Southfield & OH & U.S.A.",
    "Underwater; 50 N 3rd Street & Indianapolis & IN & U.S.A.",
    "J.W. Luscher;65 Addams Street & Berkely & MA & U.S.A.",
    "Scuba;3105 East Brace & Rancho Dominguez & CA & U.S.A.",
    "Divers Supply;5208 University Dr & Macon & GA & U.S.A.",
    "Techniques;52 Dolphin Drive & Redwood City & CA & U.S.A.",
    "Perry Scuba;3443 James Ave & Hapeville & GA & U.S.A.",
    "Beauchat, Inc.;45900 SW 2nd Ave & Ft Lauderdale & FL & U.S.A.",
    "Amor Aqua;42 West 29th Street & New York & NY & U.S.A.",
    "Aqua Research;P.O. Box 998 & Cornish & NH & U.S.A.",
    "B&K Undersea;116 W 7th Street & New York & NY & U.S.A.",
    "Diving;1148 David Drive & San Diego & DA & U.S.A.",
    "Nautical;65 NW 167 Street & Miami & FL & U.S.A.",
    "Glen Specialties;17663 Campbell Lane & Huntington Beach & CA & U.S.A.",
    "Dive Time;20 Miramar Ave & Long Beach & CA & U.S.A.",
    "Undersea Systems;18112 Gotham Street & Huntington Beach & C & U.S.A."
}
            ' Iterate over the data array to populate the grid with rows and cells
            For r As Integer = 0 To data.Length - 1
                ' Add a new row to the grid
                Dim row1 As PdfGridRow = grid.Rows.Add()

                ' Split the data string into an array of values using the ";" delimiter
                Dim rowData() As String = data(r).Split(";"c)

                ' Iterate over each value in the rowData array
                For c As Integer = 0 To rowData.Length - 1
                    ' Set the value of the cell in the current row and column
                    row1.Cells(c).Value = rowData(c)

                    ' Set the string format for the cell to center align horizontally and middle align vertically
                    row1.Cells(c).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
                Next c
            Next r

            ' Draw the grid on the specified page at the given position
            grid.Draw(page, New PointF(50, 330))

            ' Save the modified document
            doc.SaveToFile("EmbedGridInCell.pdf")

            ' Close the document
            doc.Close()

            ' Launch the document
            PDFDocumentViewer("EmbedGridInCell.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
