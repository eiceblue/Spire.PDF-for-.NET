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
            page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
			y = y + font1.MeasureString("Country List", format1).Height
			y = y + 5

			'create data table
			Dim table As New PdfTable()
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

			Using conn As New OleDbConnection()
				conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"
				Dim command As New OleDbCommand()
				command.CommandText = " select Name, '' as Flag, Capital, Continent, Area, Population, Flag as FlagData from country "
				command.Connection = conn
				Using dataAdapter As New OleDbDataAdapter(command)
					Dim dataTable As New DataTable()
					dataAdapter.Fill(dataTable)
					dataTable.Columns.Add(New DataColumn("FlagImage", GetType(PdfImage)))
					table.DataSourceType = PdfTableDataSourceType.TableDirect
					table.DataSource = dataTable
				End Using
			End Using
			Dim width As Single = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width
			table.Columns(0).Width = width * 0.21f
			table.Columns(0).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
			table.Columns(1).Width = width * 0.10f
			table.Columns(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
			table.Columns(2).Width = width * 0.19f
			table.Columns(2).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
			table.Columns(3).Width = width * 0.21f
			table.Columns(3).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
			table.Columns(4).Width = width * 0.12f
			table.Columns(4).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
			table.Columns(5).Width = width * 0.17f
			table.Columns(5).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)

			AddHandler table.BeginRowLayout, AddressOf table_BeginRowLayout
			AddHandler table.EndCellLayout, AddressOf table_EndCellLayout

			Dim tableLayout As New PdfTableLayoutFormat()
			tableLayout.Break = PdfLayoutBreakType.FitElement
			tableLayout.Layout = PdfLayoutType.Paginate
			tableLayout.EndColumnIndex = table.Columns.Count - 2 - 1

			Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y), tableLayout)
			y = y + result.Bounds.Height + 5

			Dim brush2 As PdfBrush = PdfBrushes.Gray
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9f))
			page.Canvas.DrawString(String.Format("* {0} countries in the list.", table.Rows.Count), font2, brush2, 5, y)

			'Save pdf file.
			doc.SaveToFile("ImageTable.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("ImageTable.pdf")
		End Sub

		Private Sub table_EndCellLayout(ByVal sender As Object, ByVal args As EndCellLayoutEventArgs)
			If args.RowIndex < 0 Then
				'header
				Return
			End If
			If args.CellIndex = 1 Then
				Dim dataTable As DataTable = TryCast((TryCast(sender, PdfTable)).DataSource, DataTable)
				Dim image As PdfImage = TryCast(dataTable.Rows(args.RowIndex)(7), PdfImage)
				Dim x As Single = (args.Bounds.Width - image.PhysicalDimension.Width) / 2 + args.Bounds.X
				Dim y As Single = (args.Bounds.Height - image.PhysicalDimension.Height) / 2 + args.Bounds.Y
				args.Graphics.DrawImage(image, x, y)
			End If
		End Sub

		Private Sub table_BeginRowLayout(ByVal sender As Object, ByVal args As BeginRowLayoutEventArgs)
			If args.RowIndex < 0 Then
				'header
				Return
			End If
			Dim dataTable As DataTable = TryCast((TryCast(sender, PdfTable)).DataSource, DataTable)
			Dim imageData() As Byte = TryCast(dataTable.Rows(args.RowIndex)(6), Byte())
			Using stream As New MemoryStream(imageData)
				Dim image As PdfImage = PdfImage.FromStream(stream)
				args.MinimalHeight = 4 + image.PhysicalDimension.Height
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
