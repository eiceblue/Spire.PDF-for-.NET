Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables


Namespace InsertPageBreak
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a Pdf document
			Dim doc As New PdfDocument()

			'Add a page
			Dim page As PdfPageBase = doc.Pages.Add()

			Dim y As Single=10

			'Title
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
			page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width \ 2, y, format1)
			y = y + font1.MeasureString("Country List", format1).Height
			y = y + 5

			'Create a table
			Dim table As New PdfTable()
			table.Style.BorderPen = New PdfPen(brush1, 0.5f)

			'Header style
			table.Style.HeaderSource = PdfHeaderSource.Rows
			table.Style.HeaderRowCount = 1
			table.Style.ShowHeader = True
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
			table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 14f, FontStyle.Bold))
			table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			'Repeat header
			table.Style.RepeatHeader = True

			'Body style
			table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
			table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10f))
			table.Style.DefaultStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			table.Style.AlternateStyle = New PdfCellStyle()
			table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow
			table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10f))
			table.Style.AlternateStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

			table.DataSource = GetData()

			'Set the Pdf table layout and specify the paginate bounds
			Dim tableLayout As New PdfTableLayoutFormat()
			tableLayout.Break = PdfLayoutBreakType.FitElement
			tableLayout.Layout = PdfLayoutType.Paginate
			tableLayout.PaginateBounds = New RectangleF(0, y, page.ActualSize.Width-100, page.ActualSize.Height \ 3)

			'Set the row height
			AddHandler table.BeginRowLayout, AddressOf table_BeginRowLayout

			'Drow the table in page
			Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y), tableLayout)

			'Save the document
			Dim output As String = "InsertPageBreak_out.pdf"
			doc.SaveToFile(output)
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer(output)
		End Sub

		Private Function GetData() As String()()
			Dim data() As String = { "Name;Capital;Continent;Area;Population", "Argentina;Buenos Aires;South America;2777815;32300003", "Bolivia;La Paz;South America;1098575;7300000", "Brazil;Brasilia;South America;8511196;150400000", "Canada;Ottawa;North America;9976147;26500000", "Chile;Santiago;South America;756943;13200000", "Colombia;Bagota;South America;1138907;33000000", "Cuba;Havana;North America;114524;10600000", "Ecuador;Quito;South America;455502;10600000", "El Salvador;San Salvador;North America;20865;5300000", "Guyana;Georgetown;South America;214969;800000", "Jamaica;Kingston;North America;11424;2500000", "Mexico;Mexico City;North America;1967180;88600000", "Nicaragua;Managua;North America;139000;3900000", "Paraguay;Asuncion;South America;406576;4660000", "Peru;Lima;South America;1285215;21600000", "United States of America;Washington;North America;9363130;249200000", "Uruguay;Montevideo;South America;176140;3002000", "Venezuela;Caracas;South America;912047;19700000" }

			Dim dataSource(data.Length - 1)() As String
			For i As Integer = 0 To data.Length - 1
				dataSource(i) = data(i).Split(";"c)
			Next i
			Return dataSource
		End Function
		Private Sub table_BeginRowLayout(ByVal sender As Object, ByVal args As BeginRowLayoutEventArgs)
			args.MinimalHeight = 50f
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
