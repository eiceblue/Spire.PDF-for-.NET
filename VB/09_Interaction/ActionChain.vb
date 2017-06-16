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
			'Create a pdf document.
			Dim doc As New PdfDocument()

			'Draw pages
			Dim lastPage As PdfPageBase = DrawPages(doc)

			'script
			Dim script As String = "app.alert({" & "    cMsg: ""I'll lead; you must follow me.""," & "    nIcon: 3," & "    cTitle: ""JavaScript Action""" & "});"
			Dim action1 As New PdfJavaScriptAction(script)
			doc.AfterOpenAction = action1

			'script
			script = "app.alert({" & "    cMsg: ""The firt page!""," & "    nIcon: 3," & "    cTitle: ""JavaScript Action""" & "});"
			Dim action2 As New PdfJavaScriptAction(script)
			action1.NextAction = action2

			Dim dest As New PdfDestination(lastPage)
			dest.Zoom = 1
			Dim action3 As New PdfGoToAction(dest)
			action2.NextAction = action3

			'script
			script = "app.alert({" & "    cMsg: ""Oh sorry, it's the last page. I'm missing!""," & "    nIcon: 3," & "    cTitle: ""JavaScript Action""" & "});"
			Dim action4 As New PdfJavaScriptAction(script)
			action3.NextAction = action4

			'Save pdf file.
			doc.SaveToFile("ActionChain.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("ActionChain.pdf")
		End Sub

		Private Function DrawPages(ByVal doc As PdfDocument) As PdfPageBase
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
				command.CommandText = " select Description, OnHand, OnOrder, Cost, ListPrice from parts "
				command.Connection = conn
				Using dataAdapter As New OleDbDataAdapter(command)
					Dim dataTable As New DataTable()
					dataAdapter.Fill(dataTable)
					table.DataSourceType = PdfTableDataSourceType.TableDirect
					table.DataSource = dataTable
				End Using
			End Using
			Dim width As Single = page.Canvas.ClientSize.Width - (table.Columns.Count + 1) * table.Style.BorderPen.Width
			For i As Integer = 0 To table.Columns.Count - 1
				If i = 0 Then
					table.Columns(i).Width = width * 0.40f * width
					table.Columns(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
				Else
					table.Columns(i).Width = width * 0.15f * width
					table.Columns(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
				End If
			Next i

			Dim tableLayout As New PdfTableLayoutFormat()
			tableLayout.Break = PdfLayoutBreakType.FitElement
			tableLayout.Layout = PdfLayoutType.Paginate

			Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y), tableLayout)
            y = result.Bounds.Bottom + 3

			Dim brush2 As PdfBrush = PdfBrushes.Gray
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9f))
			result.Page.Canvas.DrawString(String.Format("* {0} parts in the list.", table.Rows.Count), font2, brush2, 5, y)

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
