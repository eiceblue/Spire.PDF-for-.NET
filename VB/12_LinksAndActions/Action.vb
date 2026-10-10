Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Destinations
Imports Spire.Pdf.Tables

Namespace Action
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a pdf document
            Dim doc As PdfDocument = New PdfDocument()

            'Set margin
            Dim unitCvtr As PdfUnitConvertor = New PdfUnitConvertor()
            Dim margin As PdfMargins = New PdfMargins()
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Bottom = margin.Top
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Right = margin.Left

            'Create one page
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

            Dim y As Single = 10

            'Title
            Dim brush1 As PdfBrush = PdfBrushes.Black
            Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
            Dim format1 As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Center)
            page.Canvas.DrawString("Part List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
            y = y + font1.MeasureString("Part List", format1).Height
            y = y + 2

            'Table top
            Dim tableTopDest As PdfXYZExplicitDestination = New PdfXYZExplicitDestination(page, 0, y, 1f)
            'tableTopDest.Location = new PointF(0, y);
            'tableTopDest.Mode = PdfDestinationMode.Location;
            'tableTopDest.Zoom = 1f;

            'Draw table            
            Dim buttonFont As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Bold))
            Dim buttonWidth As Single = 70
            Dim buttonHeight As Single = buttonFont.Height * 1.5f
            Dim tableTop As Single = y
            Dim tableLayoutResult As PdfLayoutResult = DrawTable(page, y + buttonHeight + 5)

            'Table bottom
            Dim tableBottomDest As PdfXYZExplicitDestination = New PdfXYZExplicitDestination(tableLayoutResult.Page, 0, tableLayoutResult.Bounds.Bottom, 1f)
            'tableBottomDest.Location = new PointF(0, tableLayoutResult.Bounds.Bottom);
            'tableBottomDest.Mode = PdfDestinationMode.Location;
            'tableBottomDest.Zoom = 1f;

            'Go to table bottom
            Dim x As Single = page.Canvas.ClientSize.Width - buttonWidth
            Dim format2 As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
            Dim buttonBounds As RectangleF = New RectangleF(x, tableTop, buttonWidth, buttonHeight)
            page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds)
            page.Canvas.DrawString("To Bottom", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2)
            Dim action1 As PdfGoToAction = New PdfGoToAction(tableBottomDest)
            Dim annotation1 As PdfLinkAnnotation = New PdfLinkAnnotation(page, buttonBounds, action1)
            annotation1.Border.Width = 0.75f
            annotation1.Color = Color.LightGray
            PdfAnnotationCollection.Create(page).Add(annotation1)

            'Go to table top
            Dim tableBottom As Single = tableLayoutResult.Bounds.Bottom + 5
            buttonBounds = New RectangleF(x, tableBottom, buttonWidth, buttonHeight)
            tableLayoutResult.Page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds)
            tableLayoutResult.Page.Canvas.DrawString("To Top", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2)
            Dim action2 As PdfGoToAction = New PdfGoToAction(tableTopDest)
            Dim annotation2 As PdfLinkAnnotation = New PdfLinkAnnotation(page, buttonBounds, action2)
            annotation2.Border.Width = 0.75f
            annotation2.Color = Color.LightGray
            PdfAnnotationCollection.Create(tableLayoutResult.Page).Add(annotation2)

            'Go to last page
            Dim action3 As PdfNamedAction = New PdfNamedAction(PdfPredefinedAction.LastPage)
            doc.AfterOpenAction = action3

            'Script
            Dim script As String
                = "app.alert({"
                + "    cMsg: \"Oh no, you want to leave me.\","
                + "    nIcon: 3,"
                + "    cTitle: \"JavaScript Action\""
                + "});"
            Dim action4 As PdfJavaScriptAction = New PdfJavaScriptAction(script)
            doc.BeforeCloseAction = action4

            'Save pdf file
            doc.SaveToFile("Action.pdf")
            doc.Close()

            'Launch the Pdf file
            PDFDocumentViewer("Action.pdf")
        End Sub

        Private Function DrawTable(ByVal page As PdfPageBase, ByVal y As Single) As PdfLayoutResult
            Dim brush1 As PdfBrush = PdfBrushes.Black

            'Create data table
            Dim table As PdfTable = New PdfTable()
            table.Style.CellPadding = 2
            table.Style.BorderPen = New PdfPen(brush1, 0.75f)
            table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
            table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10f))
            table.Style.AlternateStyle = New PdfCellStyle()
            table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow
            table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10f))
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
            table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 11f, FontStyle.Bold))
            table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
            table.Style.ShowHeader = True

            using (OleDbConnection conn = New OleDbConnection())
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"
                Dim command As OleDbCommand = New OleDbCommand()
                command.CommandText
                    = " select Description, OnHand, OnOrder, Cost, ListPrice from parts "
                command.Connection = conn
                using (OleDbDataAdapter dataAdapter = New OleDbDataAdapter(command))
                    Dim dataTable As DataTable = New DataTable()
                    dataAdapter.Fill(dataTable)
                    table.DataSourceType = PdfTableDataSourceType.TableDirect
                    table.DataSource = dataTable
        End Function
    End Class
            Dim width As Single
                = page.Canvas.ClientSize.Width
                    - (table.Columns.Count + 1) * table.Style.BorderPen.Width
            Dim i As Integer = 0
            While i < table.Columns.Count
                If i == 0 Then
                    table.Columns[i].Width = width * 0.40f * width
                    table.Columns[i].StringFormat
                        = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
                End If
                Else
                    table.Columns[i].Width = width * 0.15f * width
                    table.Columns[i].StringFormat
                        = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
            Next
End Namespace

            Dim tableLayout As PdfTableLayoutFormat = New PdfTableLayoutFormat()
            tableLayout.Break = PdfLayoutBreakType.FitElement
            tableLayout.Layout = PdfLayoutType.Paginate

            Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y), tableLayout)
            y = result.Bounds.Bottom + 3

            Dim brush2 As PdfBrush = PdfBrushes.Gray
            Dim font2 As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 9f))
            result.Page.Canvas.DrawString(String.Format("* {0} parts in the list.", table.Rows.Count),
                font2, brush2, 5, y)

            Return result

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub

