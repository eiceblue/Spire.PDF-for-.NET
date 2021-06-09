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
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			'Create section
			Dim section As PdfSection = doc.Sections.Add()
			section.PageSettings.Size = PdfPageSize.A4
			section.PageSettings.Margins = margin

			'Create one page
			Dim page As PdfPageBase = section.Pages.Add()

			Dim y As Single = 10

			'Title
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
			page.Canvas.DrawString("Sales Report", font1, brush1, page.Canvas.ClientSize.Width \ 2, y, format1)
			y = y + font1.MeasureString("Sales Report", format1).Height
			y = y + 5

			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 11f, FontStyle.Bold))
			Dim font3 As New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Bold))
			Using conn As New OleDbConnection()
				conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"
				conn.Open()

				Dim partQueryCommand As OleDbCommand = PreparePartQueryCommand(conn)
				Dim orderItemQueryCommand As OleDbCommand = PrepareOrderItemQueryCommand(conn)

				Dim vendors As DataTable = GetVendors(conn)
				For i As Integer = 0 To vendors.Rows.Count - 1
					If i > 0 Then
						'Next page
						page = section.Pages.Add()
						y = 0
					End If
					'Draw vendor
					Dim vendorTitle As String = String.Format("{0}. {1}", i + 1, vendors.Rows(i).ItemArray(1))
					Dim drawVendorLayoutResult As PdfLayoutResult = DrawVendor(page, vendors, i, vendorTitle, y)

					'Add vendor bookmark
					Dim vendorBookmarkDest As New PdfDestination(page, New PointF(0, y))
					Dim vendorBookmark As PdfBookmark = doc.Bookmarks.Add(vendorTitle)
					vendorBookmark.Color = Color.SaddleBrown
					vendorBookmark.DisplayStyle = PdfTextStyle.Bold
					vendorBookmark.Action = New PdfGoToAction(vendorBookmarkDest)

					y = drawVendorLayoutResult.Bounds.Bottom + 5
					page = drawVendorLayoutResult.Page

					'Get parts of vendor
					Dim parts As DataTable = GetParts(partQueryCommand, CDbl(vendors.Rows(i).ItemArray(0)))
					For j As Integer = 0 To parts.Rows.Count - 1
						If j > 0 Then
							'Next page
							page = section.Pages.Add()
							y = 0
						End If
						'Draw part
						Dim partTitle As String = String.Format("{0}.{1}. {2}", i + 1, j + 1, parts.Rows(j).ItemArray(1))
						Dim drawPartLayoutResult As PdfLayoutResult = DrawPart(page, parts, j, partTitle, y)

						'Add part bookmark
						Dim partBookmarkDest As New PdfDestination(page, New PointF(0, y))
						Dim partBookmark As PdfBookmark = vendorBookmark.Add(partTitle)
						partBookmark.Color = Color.Coral
						partBookmark.DisplayStyle = PdfTextStyle.Italic
						partBookmark.Action = New PdfGoToAction(partBookmarkDest)

						y = drawPartLayoutResult.Bounds.Bottom + 5
						page = drawPartLayoutResult.Page

						'Get order items
						Dim orderItemsTitle As String = String.Format("{0} - Order Items", parts.Rows(j).ItemArray(1))
						Dim orderItems As DataTable = GetOrderItems(orderItemQueryCommand, CDbl(parts.Rows(j).ItemArray(0)))
						DrawOrderItems(page, orderItems, orderItemsTitle, y)
					Next j
				Next i
			End Using

			'Save pdf file
			doc.SaveToFile("Bookmark.pdf")
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer("Bookmark.pdf")
		End Sub

		Private Function GetVendors(ByVal conn As OleDbConnection) As DataTable
			Dim query As String = " SELECT VendorNo, VendorName, Address1, City, State, Zip, Country, Phone, FAX " & " FROM vendors "
			Using adapter As New OleDbDataAdapter(query, conn)
				Dim dataTable As New DataTable()
				adapter.Fill(dataTable)

				Return dataTable
			End Using
		End Function

		Private Function GetParts(ByVal query As OleDbCommand, ByVal vendorId As Double) As DataTable
			query.Parameters(0).Value = vendorId
			Using adapter As New OleDbDataAdapter(query)
				Dim dataTable As New DataTable()
				adapter.Fill(dataTable)

				Return dataTable
			End Using
		End Function

		Private Function GetOrderItems(ByVal query As OleDbCommand, ByVal partId As Double) As DataTable
			query.Parameters(0).Value = partId
			Using adapter As New OleDbDataAdapter(query)
				Dim dataTable As New DataTable()
				adapter.Fill(dataTable)

				Return dataTable
			End Using
		End Function

		Private Function DrawVendor(ByVal page As PdfPageBase, ByVal vendors As DataTable, ByVal index As Integer, ByVal title As String, ByVal y As Single) As PdfLayoutResult
			'Draw title
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 11f, FontStyle.Bold))
			Dim row As DataRow = vendors.Rows(index)
			page.Canvas.DrawString(title, font1, PdfBrushes.Black, 0, y)
			y = y + font1.MeasureString(title).Height + 1

			'Draw table
			Dim data(vendors.Columns.Count - 1)() As Object
			For i As Integer = 0 To vendors.Columns.Count - 1
				data(i) = New Object(1){}
				data(i)(0) = vendors.Columns(i).ColumnName
				data(i)(1) = vendors.Rows(index).ItemArray(i)
			Next i

			Dim grid As New PdfGrid()
			grid.Style.CellPadding = New PdfPaddings(2, 2, 1, 1)
			grid.DataSource = data

			Dim width As Single = page.Canvas.ClientSize.Width - (grid.Columns.Count + 1) * 0.75f
			grid.Columns(0).Width = width * 0.20f
			grid.Columns(1).Width = width * 0.80f

			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Bold))
			Dim font3 As New PdfTrueTypeFont(New Font("Arial", 10f))
			For i As Integer = 0 To grid.Rows.Count - 1
				grid.Rows(i).Style.Font = font2
				grid.Rows(i).Cells(0).Style.BackgroundBrush = PdfBrushes.CadetBlue
				grid.Rows(i).Cells(1).Style.BackgroundBrush = PdfBrushes.SkyBlue
			Next i

			Dim layout As New PdfGridLayoutFormat()
			layout.Break = PdfLayoutBreakType.FitPage
			layout.Layout = PdfLayoutType.Paginate

			Return grid.Draw(page, New PointF(0, y), layout)
		End Function

		Private Function DrawPart(ByVal page As PdfPageBase, ByVal parts As DataTable, ByVal index As Integer, ByVal title As String, ByVal y As Single) As PdfLayoutResult
			'Draw title
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Bold))
			Dim row As DataRow = parts.Rows(index)
			page.Canvas.DrawString(title, font1, PdfBrushes.Black, 0, y)
			y = y + font1.MeasureString(title).Height + 1

			'Draw table
			Dim data(1)() As Object
			data(0) = New String(parts.Columns.Count - 1){}
			For i As Integer = 0 To parts.Columns.Count - 1
				data(0)(i) = parts.Columns(i).ColumnName
			Next i
			data(1) = row.ItemArray

			Dim table As New PdfTable()
			table.Style.CellPadding = 2
			table.Style.BorderPen = New PdfPen(PdfBrushes.Black, 0.75f)
			table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.GreenYellow
			table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 9f))
			table.Style.HeaderSource = PdfHeaderSource.Rows
			table.Style.HeaderRowCount = 1
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.ForestGreen
			table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Bold))
			table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
			table.Style.ShowHeader = True
			table.DataSource = data

			Dim width As Single = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width
			For i As Integer = 0 To table.Columns.Count - 1
				table.Columns(i).Width = If(i = 1, width * 0.35f, width * 0.13f)
			Next i

			Dim tableLayout As New PdfTableLayoutFormat()
			tableLayout.Break = PdfLayoutBreakType.FitPage
			tableLayout.Layout = PdfLayoutType.Paginate

			Return table.Draw(page, New PointF(0, y), tableLayout)
		End Function

		Private Function DrawOrderItems(ByVal page As PdfPageBase, ByVal orderItems As DataTable, ByVal title As String, ByVal y As Single) As PdfLayoutResult
			'Draw title
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Bold))
			page.Canvas.DrawString(title, font1, PdfBrushes.Black, 0, y)
			y = y + font1.MeasureString(title).Height + 1

			Dim table As New PdfTable()
			table.Style.CellPadding = 2
			table.Style.BorderPen = New PdfPen(PdfBrushes.Black, 0.75f)
			table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.MediumTurquoise
			table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 8f))
			table.Style.AlternateStyle = New PdfCellStyle()
			table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.PaleTurquoise
			table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 8f))
			table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.Teal
			table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 8f, FontStyle.Bold))
			table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
			table.Style.ShowHeader = True
			table.DataSource = orderItems
			For i As Integer = 2 To table.Columns.Count - 1
				table.Columns(0).StringFormat = New PdfStringFormat(PdfTextAlignment.Right)
			Next i

			Dim tableLayout As New PdfTableLayoutFormat()
			tableLayout.Break = PdfLayoutBreakType.FitPage
			tableLayout.Layout = PdfLayoutType.Paginate

			Return table.Draw(page, New PointF(0, y), tableLayout)
		End Function

		Private Function PreparePartQueryCommand(ByVal conn As OleDbConnection) As OleDbCommand
			Dim command As New OleDbCommand()
			command.CommandText = " SELECT PartNo, Description, OnHand, OnOrder, Cost, ListPrice " & " FROM parts WHERE VendorNo = @VendorNo"
			Dim param As New OleDbParameter("@VendorNo", OleDbType.Double)
			command.Parameters.Add(param)
			command.Connection = conn
			Return command
		End Function

		Private Function PrepareOrderItemQueryCommand(ByVal conn As OleDbConnection) As OleDbCommand
			Dim command As New OleDbCommand()
			command.CommandText = " SELECT OrderNo, ItemNo, Qty, Discount " & " FROM items WHERE PartNo = @PartNo"
			Dim param As New OleDbParameter("@PartNo", OleDbType.Double)
			command.Parameters.Add(param)
			command.Connection = conn
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
