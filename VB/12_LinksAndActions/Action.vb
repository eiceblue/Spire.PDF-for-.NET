Imports System.Data.OleDb
Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace Action
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of PdfDocument
            Dim doc As New PdfDocument()

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

            ' Add a spacing of 2 units
            y = y + 2

            ' Create a new PdfDestination for the top of the table
            Dim tableTopDest As New PdfDestination(page)
            tableTopDest.Location = New PointF(0, y)
            tableTopDest.Mode = PdfDestinationMode.Location
            tableTopDest.Zoom = 1.0F

            ' Define the font and dimensions for the buttons
            Dim buttonFont As New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Bold))
            Dim buttonWidth As Single = 70
            Dim buttonHeight As Single = buttonFont.Height * 1.5F

            ' Store the y-coordinate of the table top
            Dim tableTop As Single = y

            ' Draw the table and get the layout result
            Dim tableLayoutResult As PdfLayoutResult = DrawTable(page, y + buttonHeight + 5)

            ' Create a PdfDestination for the bottom of the table
            Dim tableBottomDest As New PdfDestination(tableLayoutResult.Page)
            tableBottomDest.Location = New PointF(0, tableLayoutResult.Bounds.Bottom)
            tableBottomDest.Mode = PdfDestinationMode.Location
            tableBottomDest.Zoom = 1.0F

            ' Calculate the x-coordinate for the buttons
            Dim x As Single = page.Canvas.ClientSize.Width - buttonWidth

            ' Define the string format for center-aligned button text
            Dim format2 As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

            ' Define the bounding rectangle for the "To Bottom" button
            Dim buttonBounds As New RectangleF(x, tableTop, buttonWidth, buttonHeight)

            ' Draw the "To Bottom" button
            page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds)
            page.Canvas.DrawString("To Bottom", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2)

            ' Create a PdfGoToAction for scrolling to the bottom of the table
            Dim action1 As New PdfGoToAction(tableBottomDest)

            ' Create a PdfActionAnnotation for the "To Bottom" button
            Dim annotation1 As New PdfActionAnnotation(buttonBounds, action1)
            annotation1.Border = New PdfAnnotationBorder(0.75F)
            annotation1.Color = Color.LightGray

            ' Add the annotation to the page's annotations collection
            TryCast(page, PdfNewPage).Annotations.Add(annotation1)

            ' Store the y-coordinate of the table bottom
            Dim tableBottom As Single = tableLayoutResult.Bounds.Bottom + 5

            ' Update the bounding rectangle for the "To Top" button
            buttonBounds = New RectangleF(x, tableBottom, buttonWidth, buttonHeight)

            ' Draw the "To Top" button on the table layout result page
            tableLayoutResult.Page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds)
            tableLayoutResult.Page.Canvas.DrawString("To Top", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2)

            ' Create a PdfGoToAction for scrolling to the top of the table
            Dim action2 As New PdfGoToAction(tableTopDest)

            ' Create a PdfActionAnnotation for the "To Top" button
            Dim annotation2 As New PdfActionAnnotation(buttonBounds, action2)

            ' Set the border width for the annotation
            annotation2.Border = New PdfAnnotationBorder(0.75F)

            ' Set the color of the annotation
            annotation2.Color = Color.LightGray

            ' Add the annotation to the page's annotations collection
            TryCast(tableLayoutResult.Page, PdfNewPage).Annotations.Add(annotation2)

            ' Create a PdfNamedAction for navigating to the last page
            Dim action3 As New PdfNamedAction(PdfActionDestination.LastPage)

            ' Set the action to be executed after opening the document
            doc.AfterOpenAction = action3

            ' Define a JavaScript script for displaying an alert dialog
            Dim script As String = "app.alert({" & "    cMsg: ""Oh no, you want to leave me.""," & "    nIcon: 3," & "    cTitle: ""JavaScript Action""" & "});"

            ' Create a PdfJavaScriptAction with the script
            Dim action4 As New PdfJavaScriptAction(script)

            ' Set the action to be executed before closing the document
            doc.BeforeCloseAction = action4

            ' Save the document to a file named "Action.pdf"
            doc.SaveToFile("Action.pdf")

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("Action.pdf")
        End Sub

        Private Function DrawTable(ByVal page As PdfPageBase, ByVal y As Single) As PdfLayoutResult
            ' Define the brush for the table
            Dim brush1 As PdfBrush = PdfBrushes.Black

            ' Create a new instance of PdfTable
            Dim table As New PdfTable()

            ' Set the cell padding for the table
            table.Style.CellPadding = 2

            ' Set the border pen for the table
            table.Style.BorderPen = New PdfPen(brush1, 0.75F)

            ' Set the default style for table cells
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
            table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))

            ' Set the alternate style for table cells
            table.Style.AlternateStyle = New PdfCellStyle()
            table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow
            table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))

            ' Set the header source and style for the table
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
            table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 11.0F, FontStyle.Bold))
            table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
            table.Style.ShowHeader = True

            ' Create a new instance of OleDbConnection and set the connection string
            Using conn As New OleDbConnection()
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"

                ' Create a new instance of OleDbCommand and set the command text and connection
                Dim command As New OleDbCommand()
                command.CommandText = " select Description, OnHand, OnOrder, Cost, ListPrice from parts "
                command.Connection = conn

                ' Create a new instance of OleDbDataAdapter and set the command
                Using dataAdapter As New OleDbDataAdapter(command)

                    ' Create a new instance of DataTable and fill it with data from the data adapter
                    Dim dataTable As New DataTable()
                    dataAdapter.Fill(dataTable)

                    ' Set the data source type and data source of the table
                    table.DataSourceType = PdfTableDataSourceType.TableDirect
                    table.DataSource = dataTable
                End Using
            End Using

            ' Calculate the available width for the table
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

            ' Return the result page
            Return result
        End Function

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
