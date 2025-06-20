Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace AddRepeatingHeader
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Create a PdfUnitConvertor object for unit conversion
			Dim unitCvtr As New PdfUnitConvertor()

			' Create a PdfMargins object and set the top, bottom, left, and right margins using unit conversion
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			' Add a new page to the PdfDocument with A4 size and specified margins
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			' Set the initial y-coordinate position
			Dim y As Single = 10

			' Create a PdfBrush object for text drawing
			Dim brush As PdfBrush = PdfBrushes.Black

			' Create a PdfTrueTypeFont object for the font
			Dim font As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))

			' Create a PdfStringFormat object for text alignment
			Dim format As New PdfStringFormat(PdfTextAlignment.Center)

			' Draw the title "Country List" on the page canvas
			page.Canvas.DrawString("Country List", font, brush, page.Canvas.ClientSize.Width / 2, y, format)

			' Update the y-coordinate position
			y = y + font.MeasureString("Country List", format).Height
			y = y + 5

			' Create a new PdfTable object
			Dim table As New PdfTable()

			' Configure the style settings of the table
			table.Style.BorderPen = New PdfPen(brush, 0.5F)
			table.Style.HeaderSource = PdfHeaderSource.Rows
			table.Style.HeaderRowCount = 1
			table.Style.ShowHeader = True
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue
			table.Style.HeaderStyle.Font = New PdfTrueTypeFont(New Font("Arial", 14.0F, FontStyle.Bold))
			table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			table.Style.RepeatHeader = True
			table.Style.DefaultStyle.BackgroundBrush = PdfBrushes.SkyBlue
			table.Style.DefaultStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))
			table.Style.AlternateStyle = New PdfCellStyle()
			table.Style.AlternateStyle.BackgroundBrush = PdfBrushes.LightYellow
			table.Style.AlternateStyle.Font = New PdfTrueTypeFont(New Font("Arial", 10.0F))

			' Set the data source of the table using the 'GetData' function
			table.DataSource = GetData()

			' Set the string format for each column in the table
			For Each column As PdfColumn In table.Columns
				column.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			Next column

			' Register the event handler for the BeginRowLayout event of the table
			AddHandler table.BeginRowLayout, AddressOf table_BeginRowLayout

			' Draw the table on the page at the specified position (0, y)
			Dim result As PdfLayoutResult = table.Draw(page, New PointF(0, y))

			' Update the y-coordinate position
			y = y + result.Bounds.Height + 5

			' Create a new PdfBrush object and PdfTrueTypeFont object for additional text
			Dim brush2 As PdfBrush = PdfBrushes.Gray
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9.0F))

			' Draw the additional text indicating the number of countries in the list
			page.Canvas.DrawString(String.Format("* {0} countries in the list.", table.Rows.Count), font2, brush2, 5, y)

			' Save the document
			doc.SaveToFile("AddRepeatingColumn_out.pdf")

			' Close the document
			doc.Close()

			'Launch the Pdf
			PDFDocumentViewer("AddRepeatingColumn_out.pdf")
		End Sub
		Private Sub table_BeginRowLayout(ByVal sender As Object, ByVal args As BeginRowLayoutEventArgs)
			args.MinimalHeight = 50f
		End Sub
		Private Function GetData() As String()()
			' Define an array of strings containing the data in a specific format
			Dim data() As String = {"Name;Capital;Continent;Area;Population", "Argentina;Buenos Aires;South America;2777815;32300003", "Bolivia;La Paz;South America;1098575;7300000", "Brazil;Brasilia;South America;8511196;150400000", "Canada;Ottawa;North America;9976147;26500000", "Chile;Santiago;South America;756943;13200000", "Colombia;Bagota;South America;1138907;33000000", "Cuba;Havana;North America;114524;10600000", "Ecuador;Quito;South America;455502;10600000", "El Salvador;San Salvador;North America;20865;5300000", "Guyana;Georgetown;South America;214969;800000", "Jamaica;Kingston;North America;11424;2500000", "Mexico;Mexico City;North America;1967180;88600000", "Nicaragua;Managua;North America;139000;3900000", "Paraguay;Asuncion;South America;406576;4660000", "Peru;Lima;South America;1285215;21600000", "United States of America;Washington;North America;9363130;249200000", "Uruguay;Montevideo;South America;176140;3002000", "Venezuela;Caracas;South America;912047;19700000"}

			' Create a 2D array to hold the parsed data from the 'data' array
			Dim dataSource(data.Length - 1)() As String

			' Split each string in the 'data' array using ';' as the delimiter and store the result in the 'dataSource' array
			For i As Integer = 0 To data.Length - 1
				dataSource(i) = data(i).Split(";"c)
			Next i
			Return dataSource
		End Function
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
