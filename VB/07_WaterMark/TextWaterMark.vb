Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace TextWaterMark
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

            Dim brush As New PdfTilingBrush(New SizeF(page.Canvas.ClientSize.Width / 2, page.Canvas.ClientSize.Height / 3))
			brush.Graphics.SetTransparency(0.3f)
			brush.Graphics.Save()
            brush.Graphics.TranslateTransform(brush.Size.Width / 2, brush.Size.Height / 2)
			brush.Graphics.RotateTransform(-45)
			brush.Graphics.DrawString("Spire.Pdf Demo", New PdfFont(PdfFontFamily.Helvetica, 24), PdfBrushes.Violet, 0, 0, New PdfStringFormat(PdfTextAlignment.Center))
			brush.Graphics.Restore()
			brush.Graphics.SetTransparency(1)
			page.Canvas.DrawRectangle(brush, New RectangleF(New PointF(0, 0), page.Canvas.ClientSize))

			'Draw the page
			DrawPage(page)

			'Save pdf file.
			doc.SaveToFile("TextWaterMark.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("TextWaterMark.pdf")
		End Sub

		Private Sub DrawPage(ByVal page As PdfPageBase)
			Dim y As Single = 10

			'title
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
            page.Canvas.DrawString("Category Sales by Year", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
			y = y + font1.MeasureString("Category Sales by Year", format1).Height
			y = y + 5

			Dim data()() As String = { New String(){"Category Name", "1994 Sale Amount", "1995 Sale Amount", "1996 Sale Amount"}, New String(){"Beverages", "38,487.20", "102,479.46", "126,901.53"}, New String(){"Condiments", "16,402.95", "51,041.83", "38,602.31"}, New String(){"Confections", "23,812.90", "79,752.25", "63,792.07"}, New String(){"Dairy Products", "30,027.79", "116,495.45", "87,984.05"}, New String(){"Grains/Cereals", "7,313.92", "53,823.48", "34,607.19"}, New String(){"Meat/Poultry", "19,856.86", "77,164.75", "66,000.75"}, New String(){"Produce", "10,694.96", "45,973.69", "43,315.93"}, New String(){"Seafood", "16,247.77", "64,195.51", "50,818.46"} }

			Dim table As New PdfTable()
			table.Style.CellPadding = 2
			table.Style.BorderPen = New PdfPen(brush1, 0.75f)
			table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
			table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10f))
			table.Style.HeaderSource = PdfHeaderSource.Rows
			table.Style.HeaderRowCount = 1
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
			table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 11f, FontStyle.Bold))
			table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
			table.Style.ShowHeader = True
			table.DataSource = data

			Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y))
			y = y + result.Bounds.Height + 5

			Dim brush2 As PdfBrush = PdfBrushes.LightGray
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9f))
			page.Canvas.DrawString("* All data from NorthWind", font2, brush2, 5, y)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
