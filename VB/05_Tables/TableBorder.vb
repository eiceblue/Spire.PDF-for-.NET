Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace TableBorder
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim data() As String = { "Name;Capital;Continent;Area;Population", "Argentina;Buenos Aires;South America;2777815;32300003", "Bolivia;La Paz;South America;1098575;7300000", "Brazil;Brasilia;South America;8511196;150400000", "Canada;Ottawa;North America;9976147;26500000", "Chile;Santiago;South America;756943;13200000", "Colombia;Bagota;South America;1138907;33000000", "Cuba;Havana;North America;114524;10600000", "Ecuador;Quito;South America;455502;10600000", "El Salvador;San Salvador;North America;20865;5300000", "Guyana;Georgetown;South America;214969;800000", "Jamaica;Kingston;North America;11424;2500000", "Mexico;Mexico City;North America;1967180;88600000", "Nicaragua;Managua;North America;139000;3900000", "Paraguay;Asuncion;South America;406576;4660000", "Peru;Lima;South America;1285215;21600000", "United States of America;Washington;North America;9363130;249200000", "Uruguay;Montevideo;South America;176140;3002000", "Venezuela;Caracas;South America;912047;19700000" }

			' Create a multidimensional array to store the data for the table
			Dim dataSource(data.Length - 1)() As String

			' Split each data string by semicolon (;) and store it in the dataSource array
			For i As Integer = 0 To data.Length - 1
				dataSource(i) = data(i).Split(";"c)
			Next i

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load an existing PDF document from a file
			doc.LoadFromFile("..\..\..\..\..\..\Data\TableBorder.pdf")

			' Get the first page of the loaded document
			Dim page As PdfPageBase = doc.Pages(0)

			' Create a new PdfTable object
			Dim table As New PdfTable()

			' Set the data source for the table using the dataSource array
			table.DataSource = dataSource

			' Create a new PdfTableStyle object
			Dim style As New PdfTableStyle()

			' Set the cell padding for the table
			style.CellPadding = 2

			' Set the border pen for the table to a gray pen with a thickness of 1
			style.BorderPen = New PdfPen(Color.Gray, 1.0F)

			' Set the style of the table to the created style
			table.Style = style

			' Attach a handler to the BeginRowLayout event of the table (optional step)
			AddHandler table.BeginRowLayout, AddressOf table_BeginRowLayout

			' Draw the table on the page at the specified location (60, 320)
			table.Draw(page, New PointF(60, 320))

			' Specify the output file name for the modified document
			Dim output As String = "TableBorder.pdf"

			' Save the modified document to a file
			doc.SaveToFile(output)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub table_BeginRowLayout(ByVal sender As Object, ByVal args As BeginRowLayoutEventArgs)
			'Set the color of table cell border
			Dim cellStyle As New PdfCellStyle()
			cellStyle.BorderPen = New PdfPen(Color.LightBlue, 0.9f)
			args.CellStyle = cellStyle
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
