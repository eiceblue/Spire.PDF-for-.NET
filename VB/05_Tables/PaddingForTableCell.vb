Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid

Namespace PaddingForTableCell
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Add a new page to the document with A4 size and 5-unit margins
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, New PdfMargins(5))

            ' Create a new PdfGrid object
            Dim grid As New PdfGrid()

            ' Set the cell padding for the grid to 10 units on all sides
            grid.Style.CellPadding = New PdfPaddings(10, 10, 10, 10)

            ' Set the data source for the grid
            grid.DataSource = GetData()

            ' Set the string format for each cell in the grid to center alignment and middle vertical alignment
            For Each row As PdfGridRow In grid.Rows
                For Each cell As PdfGridCell In row.Cells
                    cell.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
                Next cell
            Next row

            ' Draw the grid on the page at the specified location (0, 0)
            grid.Draw(page, New PointF(0, 0))

            ' Save the document
            Dim result As String = "PaddingForTableCell_out.pdf"
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

            ' Launch the document
            PDFDocumentViewer(result)
        End Sub
        Private Function GetData() As String()()
            Dim data() As String = {"Name;Capital;Continent;Area;Population", "Argentina;Buenos Aires;South America;2777815;32300003", "Bolivia;La Paz;South America;1098575;7300000", "Brazil;Brasilia;South America;8511196;150400000", "Canada;Ottawa;North America;9976147;26500000", "Chile;Santiago;South America;756943;13200000", "Colombia;Bagota;South America;1138907;33000000", "Cuba;Havana;North America;114524;10600000", "Ecuador;Quito;South America;455502;10600000", "El Salvador;San Salvador;North America;20865;5300000", "Guyana;Georgetown;South America;214969;800000", "Jamaica;Kingston;North America;11424;2500000", "Mexico;Mexico City;North America;1967180;88600000", "Nicaragua;Managua;North America;139000;3900000", "Paraguay;Asuncion;South America;406576;4660000", "Peru;Lima;South America;1285215;21600000", "United States of America;Washington;North America;9363130;249200000", "Uruguay;Montevideo;South America;176140;3002000", "Venezuela;Caracas;South America;912047;19700000"}

            ' Declare a 2-dimensional array of strings
            Dim dataSource(data.Length - 1)() As String

            ' Iterate over each element
            For i As Integer = 0 To data.Length - 1
                ' Split the current element of "data" using ";" as the delimiter
                dataSource(i) = data(i).Split(";"c)
            Next i
            Return dataSource
        End Function
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
