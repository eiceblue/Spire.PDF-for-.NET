Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace SimpleTable
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load an existing PDF document from a file
			doc.LoadFromFile("..\..\..\..\..\..\Data\SimpleTable.pdf")

			' Get the first page of the loaded document
			Dim page As PdfPageBase = doc.Pages(0)

			' Set the initial Y-coordinate position for drawing content on the page
			Dim y As Single = 320

			' Set the brush and font for the title "Country List"
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)

			' Draw the title "Country List" at the center of the page with specified font and formatting
			page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
			y = y + font1.MeasureString("Country List", format1).Height
			y = y + 5

			' Define the data for the table as an array of strings
			Dim data() As String = {"Name;Capital;Continent;Area;Population", "Argentina;Buenos Aires;South America;2777815;32300003", "Bolivia;La Paz;South America;1098575;7300000", "Brazil;Brasilia;South America;8511196;150400000", "Canada;Ottawa;North America;9976147;26500000", "Chile;Santiago;South America;756943;13200000", "Colombia;Bagota;South America;1138907;33000000", "Cuba;Havana;North America;114524;10600000", "Ecuador;Quito;South America;455502;10600000", "El Salvador;San Salvador;North America;20865;5300000", "Guyana;Georgetown;South America;214969;800000", "Jamaica;Kingston;North America;11424;2500000", "Mexico;Mexico City;North America;1967180;88600000", "Nicaragua;Managua;North America;139000;3900000", "Paraguay;Asuncion;South America;406576;4660000", "Peru;Lima;South America;1285215;21600000", "United States of America;Washington;North America;9363130;249200000", "Uruguay;Montevideo;South America;176140;3002000", "Venezuela;Caracas;South America;912047;19700000"}

			' Create a multidimensional array to store the data for the table
			Dim dataSource(data.Length - 1)() As String

			' Split each data string by semicolon (;) and store it in the dataSource array
			For i As Integer = 0 To data.Length - 1
				dataSource(i) = data(i).Split(";"c)
			Next i

			' Create a new PdfTable object
			Dim table As New PdfTable()

			' Set the cell padding for the table
			table.Style.CellPadding = 2

			' Set the source of the table header rows
			table.Style.HeaderSource = PdfHeaderSource.Rows

			' Set the number of header rows in the table
			table.Style.HeaderRowCount = 1

			' Set whether to show the header row in the table
			table.Style.ShowHeader = True

			' Set the data source for the table
			table.DataSource = dataSource

			' Draw the table on the page at the specified location (60, y) and get the layout result
			Dim result As PdfLayoutResult = table.Draw(page, New PointF(60, y))
			y = y + result.Bounds.Height + 5

			' Set the brush and font for the footnote
			Dim brush2 As PdfBrush = PdfBrushes.Gray
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 9.0F))

			' Draw the footnote indicating the number of countries in the list
			page.Canvas.DrawString(String.Format("* {0} countries in the list.", data.Length - 1), font2, brush2, 65, y)

			' Save the modified document to a file
			doc.SaveToFile("SimpleTable.pdf")

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("SimpleTable.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
