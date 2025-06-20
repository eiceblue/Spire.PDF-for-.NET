Imports System.Data.OleDb
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid

Namespace Grid
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Create a PdfUnitConvertor object for unit conversion
            Dim unitCvtr As New PdfUnitConvertor()

            ' Create a PdfMargins object for setting the margins of the document
            Dim margin As New PdfMargins()

            ' Set the top margin using unit conversion from centimeters to points
            margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

            ' Set the bottom margin equal to the top margin
            margin.Bottom = margin.Top

            ' Set the left margin using unit conversion from centimeters to points
            margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

            ' Set the right margin equal to the left margin
            margin.Right = margin.Left

            ' Add a new page to the document with A4 size
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4)

            ' Initialize variables for positioning and formatting
            Dim y As Single = 10
            Dim x1 As Single = page.Canvas.ClientSize.Width

            ' Define a black brush and a bold Arial font
            Dim brush1 As PdfBrush = PdfBrushes.Black
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold), True)

            ' Create a PdfStringFormat object for center alignment
            Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)

            ' Draw the text "Vendor List" on the page using the defined font, brush, and format
            page.Canvas.DrawString("Vendor List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)

            ' Update the y position based on the height of the drawn text
            y = y + font1.MeasureString("Vendor List", format1).Height
            y = y + 5

            ' Define an array of strings representing the data
            Dim data() As String = {"VendorName;Address1;City;State;Country", "Cacor Corporation;161 Southfield Rd;Southfield;OH;U.S.A.", "Underwater;50 N 3rd Street;Indianapolis;IN;U.S.A.", "J.W.  Luscher Mfg.;65 Addams Street;Berkely;MA;U.S.A.", "Scuba Professionals;3105 East Brace;Rancho Dominguez;CA;U.S.A.", "Divers'  Supply Shop;5208 University Dr;Macon;GA;U.S.A.", "Techniques;52 Dolphin Drive;Redwood City;CA;U.S.A.", "Perry Scuba;3443 James Ave;Hapeville;GA;U.S.A.", "Beauchat, Inc.;45900 SW 2nd Ave;Ft Lauderdale;FL;U.S.A.", "Amor Aqua;42 West 29th Street;New York;NY;U.S.A.", "Aqua Research Corp.;P.O. Box 998;Cornish;NH;U.S.A.", "B&K Undersea Photo;116 W 7th Street;New York;NY;U.S.A.", "Diving International Unlimited;1148 David Drive;San Diego;DA;U.S.A.", "Nautical Compressors;65 NW 167 Street;Miami;FL;U.S.A.", "Glen Specialties, Inc.;17663 Campbell Lane;Huntington Beach;CA;U.S.A.", "Dive Time;20 Miramar Ave;Long Beach;CA;U.S.A.", "Undersea Systems, Inc.;18112 Gotham Street;Huntington Beach;CA;U.S.A.", "Felix Diving;310 S Michigan Ave;Chicago;IL;U.S.A.", "Central Valley Skin Divers;160 Jameston Ave;Jamaica;NY;U.S.A.", "Parkway Dive Shop;241 Kelly Street;South Amboy;NJ;U.S.A.", "Marine Camera & Dive;117 South Valley Rd;San Diego;CA;U.S.A.", "Dive Canada;275 W Ninth Ave;Vancouver;British Columbia;Canada", "Dive & Surf;P.O. Box 20210;Indianapolis;IN;U.S.A.", "Fish Research Labs;29 Wilkins Rd Dept. SD;Los Banos;CA;U.S.A."}

            ' Create a PdfGrid object for displaying tabular data
            Dim grid As New PdfGrid()

            ' Set the cell padding of the grid
            grid.Style.CellPadding = New PdfPaddings(1, 1, 1, 1)

            ' Split the header row using semicolon as the delimiter and add columns to the grid
            Dim header() As String = data(0).Split(";"c)
            grid.Columns.Add(header.Length)

            ' Calculate the width of each column based on the available space on the page
            Dim width As Single = page.Canvas.ClientSize.Width - (grid.Columns.Count + 1)
            grid.Columns(0).Width = width * 0.25F
            grid.Columns(1).Width = width * 0.25F
            grid.Columns(2).Width = width * 0.25F
            grid.Columns(3).Width = width * 0.15F
            grid.Columns(4).Width = width * 0.1F

            ' Add a header row to the grid and customize its style
            Dim headerRow As PdfGridRow = grid.Headers.Add(1)(0)
            headerRow.Style.Font = New PdfTrueTypeFont(New Font("Arial", 11.0F, FontStyle.Bold), True)
            headerRow.Style.BackgroundBrush = New PdfLinearGradientBrush(New PointF(0, 0), New PointF(x1, 0), Color.Red, Color.Blue)

            ' Populate the header cells with the values from the header array
            For i As Integer = 0 To header.Length - 1
                ' Set the value of the cell to the corresponding header value
                headerRow.Cells(i).Value = header(i)
                ' Set the string format of the cell to center alignment and middle vertical alignment
                headerRow.Cells(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
                ' Set the background brush of the first cell to gray
                If i = 0 Then
                    headerRow.Cells(i).Style.BackgroundBrush = PdfBrushes.Gray
                End If
            Next i

            ' Create a random object and a dictionary for grouping by country
            Dim random As New Random()
            Dim groupByCountry As New Dictionary(Of String, Integer)()

            ' Iterate through the data rows
            For r As Integer = 1 To data.Length - 1
                ' Add a new row to the grid
                Dim row As PdfGridRow = grid.Rows.Add()
                ' Set the font style of the row
                row.Style.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F), True)

                ' Generate random colors for the gradient background of each row
                Dim buffer(5) As Byte
                random.NextBytes(buffer)
                Dim color1 As New PdfRGBColor(buffer(0), buffer(1), buffer(2))
                Dim color2 As New PdfRGBColor(buffer(3), buffer(4), buffer(5))
                ' Set the background brush of the row to a linear gradient brush using the generated colors
                row.Style.BackgroundBrush = New PdfLinearGradientBrush(New PointF(0, 0), New PointF(x1, 0), color1, color2)

                ' Split the data row using semicolon as the delimiter
                Dim rowData() As String = data(r).Split(";"c)
                ' Iterate through the cells of the row
                For c As Integer = 0 To rowData.Length - 1
                    ' Set the value of the cell to the corresponding data value
                    row.Cells(c).Value = rowData(c)

                    ' Set the background brush of the first cell to gray
                    If c = 0 Then
                        row.Cells(c).Style.BackgroundBrush = PdfBrushes.Gray
                    End If

                    ' Set the string format of the cells based on their position in the row
                    If c < 3 Then
                        ' Set left alignment and middle vertical alignment for the first three cells
                        row.Cells(c).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
                    Else
                        ' Set center alignment and middle vertical alignment for the last two cells
                        row.Cells(c).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
                    End If

                    ' Update the count in the groupByCountry dictionary based on the country value in the fourth cell
                    If c = 4 Then
                        If groupByCountry.ContainsKey(rowData(c)) Then
                            groupByCountry(rowData(c)) = groupByCountry(rowData(c)) + 1
                        Else
                            groupByCountry(rowData(c)) = 1
                        End If
                    End If
                Next c
            Next r

            ' Create a StringBuilder to store the total amount information
            Dim totalAmount As New StringBuilder()

            ' Iterate through the groupByCountry dictionary and append the country and count to the StringBuilder
            For Each country As KeyValuePair(Of String, Integer) In groupByCountry
                totalAmount.AppendFormat("{0}:" & vbTab & "{1}", country.Key, country.Value)
                totalAmount.AppendLine()
            Next country

            ' Add a row to the grid for displaying the total amount information
            Dim totalAmountRow As PdfGridRow = grid.Rows.Add()
            totalAmountRow.Style.BackgroundBrush = PdfBrushes.Plum
            totalAmountRow.Cells(0).Value = "Total Amount"
            totalAmountRow.Cells(0).Style.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Bold), True)
            totalAmountRow.Cells(0).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
            totalAmountRow.Cells(1).ColumnSpan = 4
            totalAmountRow.Cells(1).Value = totalAmount.ToString()
            totalAmountRow.Cells(1).Style.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Bold Or FontStyle.Italic), True)
            totalAmountRow.Cells(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)

            ' Create a new PdfGrid object for the product list
            Dim productList As New PdfGrid()
            productList.Style.Font = New PdfTrueTypeFont(New Font("Arial", 8.0F), True)

            ' Establish a connection to the database using OleDbConnection
            Using conn As New OleDbConnection()
                ' Set the connection string to access the demo.mdb file
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"
                Dim command As New OleDbCommand()
                ' Define the SQL command to select descriptions from vendors and parts tables
                command.CommandText = "SELECT p.Description FROM vendors v " & "INNER JOIN parts p ON v.VendorNo = p.VendorNo " & "WHERE v.VendorName = 'Cacor Corporation'"
                command.Connection = conn
                ' Use OleDbDataAdapter to fill a DataTable with the result of the query
                Using dataAdapter As New OleDbDataAdapter(command)
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)
                    ' Set the DataTable as the data source for the productList grid
                    productList.DataSource = dataTable
                End Using
            End Using

            ' Set the value and styling of the header cell in the productList grid
            productList.Headers(0).Cells(0).Value = "Cacor Corporation"
            productList.Headers(0).Cells(0).Style.Font = New PdfTrueTypeFont(New Font("Arial", 8.0F, FontStyle.Bold), True)
            productList.Headers(0).Cells(0).Style.Borders.All = New PdfPen(New PdfTilingBrush(New SizeF(1, 1)), 0)

            ' Embed the productList grid into a cell of the main grid
            grid.Rows(0).Cells(0).Value = productList
            grid.Rows(0).Cells(0).StringFormat.Alignment = PdfTextAlignment.Left

            ' Draw the main grid on the page and calculate the new y coordinate
            Dim result As PdfLayoutResult = grid.Draw(page, New PointF(0, y))
            y = y + result.Bounds.Height + 5

            ' Set the brush and font for drawing additional text on the page
            Dim brush2 As PdfBrush = PdfBrushes.Gray
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9.0F))

            ' Draw additional text on the page, including the number of vendors in the list
            result.Page.Canvas.DrawString(String.Format("* All {0} vendors in the list", grid.Rows.Count - 1), font2, brush2, 5, y)

            'Save the document
            doc.SaveToFile("Grid.pdf")

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("Grid.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
