Imports System.Data.OleDb
Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Bookmarks
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid
Imports Spire.Pdf.Tables

Namespace Bookmark
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Create a unit converter for converting measurement units
            Dim unitCvtr As New PdfUnitConvertor()

            ' Set the margins for the document
            Dim margin As New PdfMargins()
            margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Bottom = margin.Top
            margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Right = margin.Left

            ' Create a section in the document
            Dim section As PdfSection = doc.Sections.Add()
            section.PageSettings.Size = PdfPageSize.A4
            section.PageSettings.Margins = margin

            ' Add a page to the section
            Dim page As PdfPageBase = section.Pages.Add()

            ' Set the initial position for drawing content on the page
            Dim y As Single = 10

            ' Set the brush, font, and format for the title text
            Dim brush1 As PdfBrush = PdfBrushes.Black
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))
            Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)

            ' Draw the title text on the page
            page.Canvas.DrawString("Sales Report", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
            y = y + font1.MeasureString("Sales Report", format1).Height
            y = y + 5

            ' Set the fonts for the content text
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 11.0F, FontStyle.Bold))
            Dim font3 As New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Bold))

            ' Open a database connection
            Using conn As New OleDbConnection()
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"
                conn.Open()

                ' Prepare database commands for retrieving data
                Dim partQueryCommand As OleDbCommand = PreparePartQueryCommand(conn)
                Dim orderItemQueryCommand As OleDbCommand = PrepareOrderItemQueryCommand(conn)

                ' Get the vendors from the database
                Dim vendors As DataTable = GetVendors(conn)

                ' Iterate over the vendors
                For i As Integer = 0 To vendors.Rows.Count - 1
                    ' If not the first vendor, add a new page
                    If i > 0 Then
                        page = section.Pages.Add()
                        y = 0
                    End If

                    ' Get the title and layout result for the current vendor
                    Dim vendorTitle As String = String.Format("{0}. {1}", i + 1, vendors.Rows(i).ItemArray(1))
                    Dim drawVendorLayoutResult As PdfLayoutResult = DrawVendor(page, vendors, i, vendorTitle, y)

                    ' Create a bookmark for the vendor
                    Dim vendorBookmarkDest As New PdfDestination(page, New PointF(0, y))
                    Dim vendorBookmark As PdfBookmark = doc.Bookmarks.Add(vendorTitle)
                    vendorBookmark.Color = Color.SaddleBrown
                    vendorBookmark.DisplayStyle = PdfTextStyle.Bold
                    vendorBookmark.Action = New PdfGoToAction(vendorBookmarkDest)

                    ' Update the position and page for drawing content
                    y = drawVendorLayoutResult.Bounds.Bottom + 5
                    page = drawVendorLayoutResult.Page

                    ' Get the parts for the current vendor
                    Dim parts As DataTable = GetParts(partQueryCommand, CDbl(vendors.Rows(i).ItemArray(0)))

                    ' Iterate over the parts
                    For j As Integer = 0 To parts.Rows.Count - 1
                        ' If not the first part, add a new page
                        If j > 0 Then
                            page = section.Pages.Add()
                            y = 0
                        End If

                        ' Get the title and layout result for the current part
                        Dim partTitle As String = String.Format("{0}.{1}. {2}", i + 1, j + 1, parts.Rows(j).ItemArray(1))
                        Dim drawPartLayoutResult As PdfLayoutResult = DrawPart(page, parts, j, partTitle, y)

                        ' Create a bookmark for the part under the vendor's bookmark
                        Dim partBookmarkDest As New PdfDestination(page, New PointF(0, y))
                        Dim partBookmark As PdfBookmark = vendorBookmark.Add(partTitle)
                        partBookmark.Color = Color.Coral
                        partBookmark.DisplayStyle = PdfTextStyle.Italic
                        partBookmark.Action = New PdfGoToAction(partBookmarkDest)

                        ' Update the position and page for drawing content
                        y = drawPartLayoutResult.Bounds.Bottom + 5
                        page = drawPartLayoutResult.Page

                        'Get order items
                        Dim orderItemsTitle As String = String.Format("{0} - Order Items", parts.Rows(j).ItemArray(1))
                        Dim orderItems As DataTable = GetOrderItems(orderItemQueryCommand, CDbl(parts.Rows(j).ItemArray(0)))
                        DrawOrderItems(page, orderItems, orderItemsTitle, y)
                    Next j
                Next i
            End Using

            ' Save the document
            doc.SaveToFile("Bookmark.pdf")

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("Bookmark.pdf")
        End Sub
        Private Function GetVendors(ByVal conn As OleDbConnection) As DataTable
            ' SQL query to select vendor information
            Dim query As String = "SELECT VendorNo, VendorName, Address1, City, State, Zip, Country, Phone, FAX FROM vendors"

            ' Use DataAdapter to fill a DataTable with the query results
            Using adapter As New OleDbDataAdapter(query, conn)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                Return dataTable
            End Using
        End Function
        Private Function GetParts(ByVal query As OleDbCommand, ByVal vendorId As Double) As DataTable
            ' Set the parameter value for the vendor ID in the query command
            query.Parameters(0).Value = vendorId

            ' Use DataAdapter to fill a DataTable with the query results
            Using adapter As New OleDbDataAdapter(query)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                Return dataTable
            End Using
        End Function
        Private Function GetOrderItems(ByVal query As OleDbCommand, ByVal partId As Double) As DataTable
            ' Set the parameter value for the part ID in the query command
            query.Parameters(0).Value = partId

            ' Use DataAdapter to fill a DataTable with the query results
            Using adapter As New OleDbDataAdapter(query)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                Return dataTable
            End Using
        End Function
        Private Function DrawVendor(ByVal page As PdfPageBase, ByVal vendors As DataTable, ByVal index As Integer, ByVal title As String, ByVal y As Single) As PdfLayoutResult
            ' Create a font for the title using Arial with size 11 and bold style
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 11.0F, FontStyle.Bold))
            ' Get the DataRow at the specified index from the vendors DataTable
            Dim row As DataRow = vendors.Rows(index)
            ' Draw the title on the page at position (0, y) using the font
            page.Canvas.DrawString(title, font1, PdfBrushes.Black, 0, y)
            ' Increment y by the height of the title text
            y = y + font1.MeasureString(title).Height + 1

            ' Prepare data for the PdfGrid
            Dim data(vendors.Columns.Count - 1)() As Object
            ' Iterate through each column in the vendors DataTable
            For i As Integer = 0 To vendors.Columns.Count - 1
                ' Create a new array to hold the column name and value
                data(i) = New Object(1) {}
                ' Set the first element of the array as the column name
                data(i)(0) = vendors.Columns(i).ColumnName
                ' Set the second element of the array as the value from the current row and column
                data(i)(1) = vendors.Rows(index).ItemArray(i)
            Next i

            ' Create a new PdfGrid instance to display the vendor information
            Dim grid As New PdfGrid()
            grid.Style.CellPadding = New PdfPaddings(2, 2, 1, 1)
            grid.DataSource = data

            ' Calculate the width available for the grid based on the page size and margin
            Dim width As Single = page.Canvas.ClientSize.Width - (grid.Columns.Count + 1) * 0.75F
            ' Set the column widths of the grid
            grid.Columns(0).Width = width * 0.2F
            grid.Columns(1).Width = width * 0.8F

            ' Create fonts for styling
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Bold))
            Dim font3 As New PdfTrueTypeFont(New Font("Arial", 10.0F))
            ' Apply styles to rows and cells in the grid
            For i As Integer = 0 To grid.Rows.Count - 1
                grid.Rows(i).Style.Font = font2
                grid.Rows(i).Cells(0).Style.BackgroundBrush = PdfBrushes.CadetBlue
                grid.Rows(i).Cells(1).Style.BackgroundBrush = PdfBrushes.SkyBlue
            Next i

            ' Create a layout format for the grid
            Dim layout As New PdfGridLayoutFormat()
            layout.Break = PdfLayoutBreakType.FitPage
            layout.Layout = PdfLayoutType.Paginate

            ' Draw the grid on the page at position (0, y) using the layout format
            Return grid.Draw(page, New PointF(0, y), layout)
        End Function
        Private Function DrawPart(ByVal page As PdfPageBase, ByVal parts As DataTable, ByVal index As Integer, ByVal title As String, ByVal y As Single) As PdfLayoutResult
            ' Create a font for the title using Arial with size 10 and bold style
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Bold))
            ' Get the DataRow at the specified index from the parts DataTable
            Dim row As DataRow = parts.Rows(index)
            ' Draw the title on the page at position (0, y) using the font
            page.Canvas.DrawString(title, font1, PdfBrushes.Black, 0, y)
            ' Increment y by the height of the title text
            y = y + font1.MeasureString(title).Height + 1

            ' Create a two-dimensional array to hold the data for the PdfTable
            Dim data(1)() As Object
            data(0) = New String(parts.Columns.Count - 1) {}
            ' Populate the first row of the data array with column names
            For i As Integer = 0 To parts.Columns.Count - 1
                data(0)(i) = parts.Columns(i).ColumnName
            Next i
            ' Populate the second row of the data array with the values from the DataRow
            data(1) = row.ItemArray

            ' Create a new PdfTable instance to display the part information
            Dim table As New PdfTable()
            table.Style.CellPadding = 2
            table.Style.BorderPen = New PdfPen(PdfBrushes.Black, 0.75F)
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.GreenYellow
            table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 9.0F))
            table.Style.HeaderSource = PdfHeaderSource.Rows
            table.Style.HeaderRowCount = 1
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.ForestGreen
            table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Bold))
            table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
            table.Style.ShowHeader = True
            table.DataSource = data

            ' Calculate the width available for the table based on the page size and border pen width
            Dim width As Single = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width
            ' Set the column widths of the table
            For i As Integer = 0 To table.Columns.Count - 1
                table.Columns(i).Width = If(i = 1, width * 0.35F, width * 0.13F)
            Next i

            ' Create a layout format for the table
            Dim tableLayout As New PdfTableLayoutFormat()
            tableLayout.Break = PdfLayoutBreakType.FitPage
            tableLayout.Layout = PdfLayoutType.Paginate

            ' Draw the table on the page at position (0, y) using the layout format
            Return table.Draw(page, New PointF(0, y), tableLayout)
        End Function
        Private Function DrawOrderItems(ByVal page As PdfPageBase, ByVal orderItems As DataTable, ByVal title As String, ByVal y As Single) As PdfLayoutResult
            ' Create a font for the title using Arial with size 9 and bold style
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Bold))
            ' Draw the title on the page at position (0, y) using the font
            page.Canvas.DrawString(title, font1, PdfBrushes.Black, 0, y)
            ' Increment y by the height of the title text
            y = y + font1.MeasureString(title).Height + 1

            ' Create a new PdfTable instance to display the order items data
            Dim table As New PdfTable()
            table.Style.CellPadding = 2
            table.Style.BorderPen = New PdfPen(PdfBrushes.Black, 0.75F)
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.MediumTurquoise
            table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 8.0F))
            table.Style.AlternateStyle = New PdfCellStyle()
            table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.PaleTurquoise
            table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 8.0F))
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.Teal
            table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 8.0F, FontStyle.Bold))
            table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
            table.Style.ShowHeader = True
            table.DataSource = orderItems
            For i As Integer = 2 To table.Columns.Count - 1
                table.Columns(0).StringFormat = New PdfStringFormat(PdfTextAlignment.Right)
            Next i

            ' Create a layout format for the table
            Dim tableLayout As New PdfTableLayoutFormat()
            tableLayout.Break = PdfLayoutBreakType.FitPage
            tableLayout.Layout = PdfLayoutType.Paginate

            ' Draw the table on the page at position (0, y) using the layout format
            Return table.Draw(page, New PointF(0, y), tableLayout)
        End Function
        Private Function PreparePartQueryCommand(ByVal conn As OleDbConnection) As OleDbCommand
            ' Create a new OleDbCommand instance
            Dim command As New OleDbCommand()
            ' Set the command text to retrieve part information from the parts table based on VendorNo
            command.CommandText = "SELECT PartNo, Description, OnHand, OnOrder, Cost, ListPrice FROM parts WHERE VendorNo = @VendorNo"
            ' Create a parameter for the VendorNo value
            Dim param As New OleDbParameter("@VendorNo", OleDbType.Double)
            command.Parameters.Add(param)
            ' Set the connection for the command
            command.Connection = conn
            ' Return the prepared command
            Return command
        End Function
        Private Function PrepareOrderItemQueryCommand(ByVal conn As OleDbConnection) As OleDbCommand
            ' Create a new OleDbCommand instance
            Dim command As New OleDbCommand()
            ' Set the command text to retrieve order item information from the items table based on PartNo
            command.CommandText = "SELECT OrderNo, ItemNo, Qty, Discount FROM items WHERE PartNo = @PartNo"
            ' Create a parameter for the PartNo value
            Dim param As New OleDbParameter("@PartNo", OleDbType.Double)
            command.Parameters.Add(param)
            ' Set the connection for the command
            command.Connection = conn
            ' Return the prepared command
            Return command
        End Function

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
