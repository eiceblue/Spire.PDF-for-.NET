Imports System.Data.OleDb
Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace ActionChain
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object.
            Dim doc As New PdfDocument()

            ' Draw pages and assign the last page to a variable.
            Dim lastPage As PdfPageBase = DrawPages(doc)

            ' Define a JavaScript script for displaying an alert message.
            Dim script As String = "app.alert({" & "    cMsg: ""I'll lead; you must follow me.""," & "    nIcon: 3," & "    cTitle: ""JavaScript Action""" & "});"

            ' Create a PdfJavaScriptAction with the script and set it as the document's AfterOpenAction.
            Dim action1 As New PdfJavaScriptAction(script)
            doc.AfterOpenAction = action1

            ' Define another JavaScript script for displaying an alert message.
            script = "app.alert({" & "    cMsg: ""The first page!""," & "    nIcon: 3," & "    cTitle: ""JavaScript Action""" & "});"

            ' Create a PdfJavaScriptAction with the script.
            Dim action2 As New PdfJavaScriptAction(script)

            ' Set action2 as the next action after action1.
            action1.NextAction = action2

            ' Create a PdfDestination with the last page and set the zoom level.
            Dim dest As New PdfDestination(lastPage)
            dest.Zoom = 1

            ' Create a PdfGoToAction with the destination.
            Dim action3 As New PdfGoToAction(dest)

            ' Set action3 as the next action after action2.
            action2.NextAction = action3

            ' Define another JavaScript script for displaying an alert message.
            script = "app.alert({" & "    cMsg: ""Oh sorry, it's the last page. I'm missing!""," & "    nIcon: 3," & "    cTitle: ""JavaScript Action""" & "});"

            ' Create a PdfJavaScriptAction with the script.
            Dim action4 As New PdfJavaScriptAction(script)

            ' Set action4 as the next action after action3.
            action3.NextAction = action4

            ' Save the document to a file.
            doc.SaveToFile("ActionChain.pdf")

            ' Close the document.
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("ActionChain.pdf")
        End Sub

        Private Function DrawPages(ByVal doc As PdfDocument) As PdfPageBase
            ' Create a new instance of PdfUnitConvertor
            Dim unitCvtr As New PdfUnitConvertor()

            ' Create a new instance of PdfMargins
            Dim margin As New PdfMargins()

            ' Set the top margin by converting 2.54 centimeters to points
            margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

            ' Set the bottom margin equal to the top margin
            margin.Bottom = margin.Top

            ' Set the left margin by converting 3.17 centimeters to points
            margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

            ' Set the right margin equal to the left margin
            margin.Right = margin.Left

            ' Add a new page with A4 size and the calculated margins
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

            ' Set the initial y-coordinate for drawing elements on the page
            Dim y As Single = 10

            ' Define the brush and font for the text
            Dim brush1 As PdfBrush = PdfBrushes.Black
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))

            ' Define the string format for center-aligned text
            Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)

            ' Draw the "Part List" title on the page
            page.Canvas.DrawString("Part List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)

            ' Update the y-coordinate based on the height of the drawn text
            y = y + font1.MeasureString("Part List", format1).Height

            ' Add a spacing of 5 units
            y = y + 5

            ' Create a new instance of PdfTable
            Dim table As New PdfTable()

            ' Set the cell padding to 2 units
            table.Style.CellPadding = 2

            ' Set the border pen for the table
            table.Style.BorderPen = New PdfPen(brush1, 0.75F)

            ' Set the default background brush and font for the table cells
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
            table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))

            ' Set the alternate background brush and font for the table cells
            table.Style.AlternateStyle = New PdfCellStyle()
            table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow
            table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))

            ' Set the header source to use column captions
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions

            ' Set the background brush and font for the table header cells
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
            table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 11.0F, FontStyle.Bold))

            ' Set the string format for center-aligned header text
            table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)

            ' Enable showing the header in the table
            table.Style.ShowHeader = True

            ' Open a new database connection
            Using conn As New OleDbConnection()

                ' Set the connection string for the database
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"

                ' Create a new command for selecting data from the parts table
                Dim command As New OleDbCommand()
                command.CommandText = "SELECT Description, OnHand, OnOrder, Cost, ListPrice FROM parts"
                command.Connection = conn

                ' Use a data adapter to fill a data table with the query results
                Using dataAdapter As New OleDbDataAdapter(command)
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)

                    ' Set the table data source type and assign the data table as the data source
                    table.DataSourceType = PdfTableDataSourceType.TableDirect
                    table.DataSource = dataTable
                End Using
            End Using

            ' Calculate the available width for the table based on the page size and margins
            Dim width As Single = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width

            ' Set the column widths and string formats for the table columns
            For i As Integer = 0 To table.Columns.Count - 1
                If i = 0 Then
                    ' Set the width and alignment for the first column
                    table.Columns(i).Width = width * 0.4F * width
                    table.Columns(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
                Else
                    ' Set the width and alignment for the remaining columns
                    table.Columns(i).Width = width * 0.15F * width
                    table.Columns(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
                End If
            Next i

            ' Define the table layout format
            Dim tableLayout As New PdfTableLayoutFormat()
            tableLayout.Break = PdfLayoutBreakType.FitElement
            tableLayout.Layout = PdfLayoutType.Paginate

            ' Draw the table on the page using the specified location and layout format
            Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y), tableLayout)

            ' Update the y-coordinate for subsequent elements
            y = result.Bounds.Bottom + 3

            ' Define the brush and font for the text below the table
            Dim brush2 As PdfBrush = PdfBrushes.Gray
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9.0F))

            ' Draw the text indicating the number of parts in the list
            result.Page.Canvas.DrawString(String.Format("* {0} parts in the list.", table.Rows.Count), font2, brush2, 5, y)

            ' Return the page containing the table
            Return result.Page
        End Function

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
