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
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin, PdfPageRotateAngle.RotateAngle0, PdfPageOrientation.Landscape)

			Dim y As Single = 10
			Dim x1 As Single = page.Canvas.ClientSize.Width

			'title
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold), True)
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
            page.Canvas.DrawString("Vendor List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
			y = y + font1.MeasureString("Vendor List", format1).Height
			y = y + 5

			Dim data() As String = { "VendorName;Address1;City;State;Country", "Cacor Corporation;161 Southfield Rd;Southfield;OH;U.S.A.", "Underwater;50 N 3rd Street;Indianapolis;IN;U.S.A.", "J.W.  Luscher Mfg.;65 Addams Street;Berkely;MA;U.S.A.", "Scuba Professionals;3105 East Brace;Rancho Dominguez;CA;U.S.A.", "Divers'  Supply Shop;5208 University Dr;Macon;GA;U.S.A.", "Techniques;52 Dolphin Drive;Redwood City;CA;U.S.A.", "Perry Scuba;3443 James Ave;Hapeville;GA;U.S.A.", "Beauchat, Inc.;45900 SW 2nd Ave;Ft Lauderdale;FL;U.S.A.", "Amor Aqua;42 West 29th Street;New York;NY;U.S.A.", "Aqua Research Corp.;P.O. Box 998;Cornish;NH;U.S.A.", "B&K Undersea Photo;116 W 7th Street;New York;NY;U.S.A.", "Diving International Unlimited;1148 David Drive;San Diego;DA;U.S.A.", "Nautical Compressors;65 NW 167 Street;Miami;FL;U.S.A.", "Glen Specialties, Inc.;17663 Campbell Lane;Huntington Beach;CA;U.S.A.", "Dive Time;20 Miramar Ave;Long Beach;CA;U.S.A.", "Undersea Systems, Inc.;18112 Gotham Street;Huntington Beach;CA;U.S.A.", "Felix Diving;310 S Michigan Ave;Chicago;IL;U.S.A.", "Central Valley Skin Divers;160 Jameston Ave;Jamaica;NY;U.S.A.", "Parkway Dive Shop;241 Kelly Street;South Amboy;NJ;U.S.A.", "Marine Camera & Dive;117 South Valley Rd;San Diego;CA;U.S.A.", "Dive Canada;275 W Ninth Ave;Vancouver;British Columbia;Canada", "Dive & Surf;P.O. Box 20210;Indianapolis;IN;U.S.A.", "Fish Research Labs;29 Wilkins Rd Dept. SD;Los Banos;CA;U.S.A." }
			Dim grid As New PdfGrid()
			grid.Style.CellPadding = New PdfPaddings(1, 1, 1, 1)

			Dim header() As String = data(0).Split(";"c)
			grid.Columns.Add(header.Length)
			Dim width As Single = page.Canvas.ClientSize.Width - (grid.Columns.Count + 1)
			grid.Columns(0).Width = width * 0.25f
			grid.Columns(1).Width = width * 0.25f
			grid.Columns(2).Width = width * 0.25f
			grid.Columns(3).Width = width * 0.15f
			grid.Columns(4).Width = width * 0.10f
			Dim headerRow As PdfGridRow = grid.Headers.Add(1)(0)
			headerRow.Style.Font = New PdfTrueTypeFont(New Font("Arial", 11f, FontStyle.Bold), True)
			headerRow.Style.BackgroundBrush = New PdfLinearGradientBrush(New PointF(0, 0), New PointF(x1, 0), Color.Red, Color.Blue)
			For i As Integer = 0 To header.Length - 1
				headerRow.Cells(i).Value = header(i)
				headerRow.Cells(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
				If i = 0 Then
					headerRow.Cells(i).Style.BackgroundBrush = PdfBrushes.Gray
				End If
			Next i

			Dim random As New Random()
			Dim groupByCountry As New Dictionary(Of String, Integer)()
			For r As Integer = 1 To data.Length - 1
				Dim row As PdfGridRow = grid.Rows.Add()
				row.Style.Font = New PdfTrueTypeFont(New Font("Arial", 10f), True)
				Dim buffer(5) As Byte
				random.NextBytes(buffer)
				Dim color1 As New PdfRGBColor(buffer(0), buffer(1), buffer(2))
				Dim color2 As New PdfRGBColor(buffer(3), buffer(4), buffer(5))
				row.Style.BackgroundBrush = New PdfLinearGradientBrush(New PointF(0, 0), New PointF(x1, 0), color1, color2)
				Dim rowData() As String = data(r).Split(";"c)
				For c As Integer = 0 To rowData.Length - 1
					row.Cells(c).Value = rowData(c)
					If c = 0 Then
						row.Cells(c).Style.BackgroundBrush = PdfBrushes.Gray
					End If
					If c < 3 Then
						row.Cells(c).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
					Else
						row.Cells(c).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
					End If
					If c = 4 Then
						If groupByCountry.ContainsKey(rowData(c)) Then
							groupByCountry(rowData(c)) = groupByCountry(rowData(c)) + 1
						Else
							groupByCountry(rowData(c)) = 1
						End If
					End If
				Next c
			Next r
			Dim totalAmount As New StringBuilder()
			For Each country As KeyValuePair(Of String, Integer) In groupByCountry
				totalAmount.AppendFormat("{0}:" & vbTab & "{1}", country.Key, country.Value)
				totalAmount.AppendLine()
			Next country

			Dim totalAmountRow As PdfGridRow = grid.Rows.Add()
			totalAmountRow.Style.BackgroundBrush = PdfBrushes.Plum
			totalAmountRow.Cells(0).Value = "Total Amount"
			totalAmountRow.Cells(0).Style.Font = New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Bold), True)
			totalAmountRow.Cells(0).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
			totalAmountRow.Cells(1).ColumnSpan = 4
			totalAmountRow.Cells(1).Value = totalAmount.ToString()
			totalAmountRow.Cells(1).Style.Font = New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Bold Or FontStyle.Italic), True)
			totalAmountRow.Cells(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)

			'append product list
			Dim productList As New PdfGrid()
			productList.Style.Font = New PdfTrueTypeFont(New Font("Arial", 8f), True)
			Using conn As New OleDbConnection()
				conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"
				Dim command As New OleDbCommand()
				command.CommandText = " select p.Description " & " from vendors v " & "     inner join parts p " & "     on v.VendorNo = p.VendorNo " & " where v.VendorName = 'Cacor Corporation'"
				command.Connection = conn
				Using dataAdapter As New OleDbDataAdapter(command)
					Dim dataTable As New DataTable()
					dataAdapter.Fill(dataTable)
					productList.DataSource = dataTable
				End Using
			End Using
			productList.Headers(0).Cells(0).Value = "Cacor Corporation"
			productList.Headers(0).Cells(0).Style.Font = New PdfTrueTypeFont(New Font("Arial", 8f, FontStyle.Bold), True)
			productList.Headers(0).Cells(0).Style.Borders.All = New PdfPen(New PdfTilingBrush(New SizeF(1, 1)), 0)
			grid.Rows(0).Cells(0).Value = productList
			grid.Rows(0).Cells(0).StringFormat.Alignment = PdfTextAlignment.Left

			Dim result As PdfLayoutResult = grid.Draw(page, New PointF(0, y))
			y = y + result.Bounds.Height + 5

			Dim brush2 As PdfBrush = PdfBrushes.Gray
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9f))
			result.Page.Canvas.DrawString(String.Format("* All {0} vendors in the list", grid.Rows.Count - 1), font2, brush2, 5, y)

			'Save pdf file.
			doc.SaveToFile("Grid.pdf")
			doc.Close()

			'Launching the Pdf file.
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
