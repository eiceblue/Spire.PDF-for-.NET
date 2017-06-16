Imports System.Data.OleDb
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Lists

Namespace List
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
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold), True)
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
            page.Canvas.DrawString("Categories List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
			y = y + font1.MeasureString("Categories List", format1).Height
			y = y + 5

			Dim rctg As New RectangleF(New PointF(0, 0), page.Canvas.ClientSize)
			Dim brush2 As New PdfLinearGradientBrush(rctg, Color.Navy, Color.OrangeRed, PdfLinearGradientMode.Vertical)
			Dim brush3 As New PdfLinearGradientBrush(rctg, Color.OrangeRed, Color.Navy, PdfLinearGradientMode.Vertical)
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 10f), True)
			Dim font3 As New PdfTrueTypeFont(New Font("Arial", 8f), True)

			Dim marker1 As New PdfOrderedMarker(PdfNumberStyle.LowerRoman, New PdfFont(PdfFontFamily.Helvetica, 10f))
			Dim marker2 As New PdfOrderedMarker(PdfNumberStyle.Numeric, New PdfFont(PdfFontFamily.Helvetica, 8f))

			Dim vendorList As New PdfSortedList(font2)
			vendorList.Indent = 0
			vendorList.TextIndent = 5
			vendorList.Brush = brush2
			vendorList.Marker = marker1
			Using conn As New OleDbConnection()
				conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\..\..\Data\demo.mdb"
				Dim command As New OleDbCommand()
				command.CommandText = " select VendorNo, VendorName from vendors "
				command.Connection = conn

				Dim command2 As New OleDbCommand()
				command2.CommandText = " select Description from parts where VendorNo = @VendorNo"
				command2.Connection = conn
				Dim param As New OleDbParameter("@VendorNo", OleDbType.Double)
				command2.Parameters.Add(param)

				conn.Open()

				Dim reader As OleDbDataReader = command.ExecuteReader()
				Do While reader.Read()
					Dim id As Double = reader.GetDouble(0)
					Dim item As PdfListItem = vendorList.Items.Add(reader.GetString(1))
					Dim subList As New PdfSortedList(font3)
					subList.Marker = marker2
					subList.Brush = brush3
                    item.SubList = subList
                    subList.TextIndent = 20
					command2.Parameters(0).Value = id
					Using reader2 As OleDbDataReader = command2.ExecuteReader()
						Do While reader2.Read()
							subList.Items.Add(reader2.GetString(0))
						Loop
                    End Using
                    Dim maxNumberLabel As String = Convert.ToString(subList.Items.Count)
                    subList.Indent = 30 - font3.MeasureString(maxNumberLabel).Width
				Loop
            End Using

            Dim textLayout As New PdfTextLayout()
            textLayout.Break = PdfLayoutBreakType.FitPage
            textLayout.Layout = PdfLayoutType.Paginate
            vendorList.Draw(page, New PointF(0, y), textLayout)

			'Save pdf file.
			doc.SaveToFile("List.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("List.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
