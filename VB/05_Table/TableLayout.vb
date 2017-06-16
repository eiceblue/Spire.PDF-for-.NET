Imports System.Data.OleDb
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace TableLayout
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()

			'margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			' Create one page
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			Dim y As Single = 10

			'title
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
            page.Canvas.DrawString("Part List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
			y = y + font1.MeasureString("Part List", format1).Height
			y = y + 5

			'create data table
			Dim table As New PdfTable()
			table.Style.CellPadding = 1
			table.Style.BorderPen = New PdfPen(brush1, 0.75f)
			table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
			table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10f), True)
			table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
			table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 11f, FontStyle.Bold), True)
			table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
			table.Style.ShowHeader = True
			table.Style.RepeatHeader = True
			Using conn As New OleDbConnection()
				conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"
				Dim command As New OleDbCommand()
				command.CommandText = " select * from parts "
				command.Connection = conn
				Using dataAdapter As New OleDbDataAdapter(command)
					Dim dataTable As New DataTable()
					dataAdapter.Fill(dataTable)
					dataTable.Columns.RemoveAt(1)
					table.DataSourceType = PdfTableDataSourceType.TableDirect
					table.DataSource = dataTable
				End Using
			End Using
			Dim width As Single = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width
			For i As Integer = 0 To table.Columns.Count - 1
				If i = 1 Then
					table.Columns(i).Width = width * 0.4f * width
					table.Columns(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
				Else
					table.Columns(i).Width = width * 0.12f * width
					table.Columns(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
				End If
			Next i
			AddHandler table.BeginRowLayout, AddressOf table_BeginRowLayout

			Dim tableLayout As New PdfTableLayoutFormat()
			tableLayout.Break = PdfLayoutBreakType.FitElement
			tableLayout.Layout = PdfLayoutType.Paginate
			Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y), tableLayout)
			y = result.Bounds.Bottom + 5

			Dim brush2 As PdfBrush = PdfBrushes.Gray
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9f))
			result.Page.Canvas.DrawString(String.Format("* All {0} parts in the list", table.Rows.Count), font2, brush2, 5, y)

			'Save pdf file.
			doc.SaveToFile("TableLayout.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("TableLayout.pdf")
		End Sub

		Private Sub table_BeginRowLayout(ByVal sender As Object, ByVal args As BeginRowLayoutEventArgs)
			If args.RowIndex < 0 Then
				'header
				Return
			End If
			If args.RowIndex Mod 3 = 0 Then
				args.CellStyle.BackgroundBrush = PdfBrushes.LightYellow
			Else
				args.CellStyle.BackgroundBrush = PdfBrushes.SkyBlue
			End If
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
