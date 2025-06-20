Imports System.Data.OleDb
Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace ImageTable
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

            ' Create a PdfMargins object to set margin values
            Dim margin As New PdfMargins()

            ' Set the top margin using unit conversion
            margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

            ' Set the bottom margin equal to the top margin
            margin.Bottom = margin.Top

            ' Set the left margin using unit conversion
            margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

            ' Set the right margin equal to the left margin
            margin.Right = margin.Left

            ' Add a new page to the document with specified page size and margins
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

            ' Initialize the y coordinate for drawing elements on the page
            Dim y As Single = 10

            ' Define brush and font for the title
            Dim brush1 As PdfBrush = PdfBrushes.Black
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))

            ' Create a PdfStringFormat object for center alignment
            Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)

            ' Draw the title "Country List" on the page
            page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width \ 2, y, format1)

            ' Update the y coordinate to position the next element
            y = y + font1.MeasureString("Country List", format1).Height
            y = y + 5

            ' Create a new PdfTable object for displaying tabular data
            Dim table As New PdfTable()

            ' Set the cell padding and border style for the table
            table.Style.CellPadding = 2
            table.Style.BorderPen = New PdfPen(brush1, 0.75F)

            ' Set the default background brush and font for table cells
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
            table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))

            ' Set the alternate background brush and font for table cells
            table.Style.AlternateStyle = New PdfCellStyle()
            table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow
            table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))

            ' Set the header source as column captions and set the style for header cells
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
            table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 11.0F, FontStyle.Bold))
            table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)

            ' Display the header row in the table
            table.Style.ShowHeader = True

            ' Create a new OleDbConnection object for database connectivity
            Using conn As New OleDbConnection()

                ' Set the connection string for the database
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"

                ' Create a new OleDbCommand object for executing SQL queries
                Dim command As New OleDbCommand()

                ' Set the SQL query to fetch data from the country table
                command.CommandText = " select Name, '' as Flag, Capital, Continent, Area, Population, Flag as FlagData from country "

                ' Set the connection for the command
                command.Connection = conn

                ' Create a new OleDbDataAdapter object for filling the data into a DataTable
                Using dataAdapter As New OleDbDataAdapter(command)

                    ' Create a new DataTable object to hold the fetched data
                    Dim dataTable As New DataTable()

                    ' Fill the DataTable with data from the database using the data adapter
                    dataAdapter.Fill(dataTable)

                    ' Add a new DataColumn for storing flag images (PdfImage)
                    dataTable.Columns.Add(New DataColumn("FlagImage", GetType(PdfImage)))

                    ' Set the data source type and data source for the PdfTable
                    table.DataSourceType = PdfTableDataSourceType.TableDirect
                    table.DataSource = dataTable

                End Using
            End Using

            ' Calculate the width available for the table on the page
            Dim width As Single = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width
            ' Set the width and string format of columns 
            table.Columns(0).Width = width * 0.21F
            table.Columns(0).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
            table.Columns(1).Width = width * 0.1F
            table.Columns(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
            table.Columns(2).Width = width * 0.19F
            table.Columns(2).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
            table.Columns(3).Width = width * 0.21F
            table.Columns(3).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
            table.Columns(4).Width = width * 0.12F
            table.Columns(4).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
            table.Columns(5).Width = width * 0.17F
            table.Columns(5).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)

            ' Attach event handlers for customizing the table layout
            AddHandler table.BeginRowLayout, AddressOf table_BeginRowLayout
            AddHandler table.EndCellLayout, AddressOf table_EndCellLayout

            ' Create a PdfTableLayoutFormat object to control the table layout
            Dim tableLayout As New PdfTableLayoutFormat()
            tableLayout.Break = PdfLayoutBreakType.FitElement
            tableLayout.Layout = PdfLayoutType.Paginate
            tableLayout.EndColumnIndex = table.Columns.Count - 2 - 1

            ' Draw the table on the page and get the resulting layout information
            Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y), tableLayout)

            ' Update the y coordinate after drawing the table
            y = y + result.Bounds.Height + 5

            ' Set the brush and font for displaying additional information
            Dim brush2 As PdfBrush = PdfBrushes.Gray
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9.0F))

            ' Display the number of countries in the list below the table
            page.Canvas.DrawString(String.Format("* {0} countries in the list.", table.Rows.Count), font2, brush2, 5, y)

            ' Save the document to a file
            doc.SaveToFile("ImageTable.pdf")

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("ImageTable.pdf")
        End Sub

        Private Sub table_EndCellLayout(ByVal sender As Object, ByVal args As EndCellLayoutEventArgs)
            ' Check if the current row index is a header row (negative row index)
            If args.RowIndex < 0 Then
                ' This is a header row, so no further action is required
                Return
            End If

            ' Check if the current cell index is 1 (second column)
            If args.CellIndex = 1 Then
                ' Retrieve the DataTable from the PdfTable's DataSource
                Dim dataTable As DataTable = TryCast((TryCast(sender, PdfTable)).DataSource, DataTable)

                ' Retrieve the image from the DataTable corresponding to the current row and column index
                Dim image As PdfImage = TryCast(dataTable.Rows(args.RowIndex)(7), PdfImage)

                ' Calculate the x and y coordinates to position the image in the cell
                Dim x As Single = (args.Bounds.Width - image.PhysicalDimension.Width) / 2 + args.Bounds.X
                Dim y As Single = (args.Bounds.Height - image.PhysicalDimension.Height) / 2 + args.Bounds.Y

                ' Draw the image on the graphics of the current cell
                args.Graphics.DrawImage(image, x, y)
            End If
        End Sub

        Private Sub table_BeginRowLayout(ByVal sender As Object, ByVal args As BeginRowLayoutEventArgs)
            ' Check if the current row index is a header row (negative row index)
            If args.RowIndex < 0 Then
                ' This is a header row, so no further action is required
                Return
            End If

            ' Retrieve the DataTable from the PdfTable's DataSource
            Dim dataTable As DataTable = TryCast((TryCast(sender, PdfTable)).DataSource, DataTable)

            ' Retrieve the image data from the DataTable corresponding to the current row and column index
            Dim imageData() As Byte = TryCast(dataTable.Rows(args.RowIndex)(6), Byte())

            ' Create a MemoryStream from the image data
            Using stream As New MemoryStream(imageData)
                ' Create a PdfImage from the MemoryStream
                Dim image As PdfImage = PdfImage.FromStream(stream)

                ' Set the minimal height of the cell to accommodate the image
                args.MinimalHeight = 4 + image.PhysicalDimension.Height

                ' Update the image data in the DataTable for later use (if needed)
                dataTable.Rows(args.RowIndex)(7) = image
            End Using
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
