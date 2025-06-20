Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace AddImageInTableCell
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Add a new page to the document
			Dim page As PdfPageBase = doc.Pages.Add()

			' Create a new PdfTable object
			Dim table As New PdfTable()

			' Create a new PdfSolidBrush object with black color
			Dim brush As New PdfSolidBrush(Color.Black)

			' Set the border pen of the table style to a pen with the specified brush and thickness
			table.Style.BorderPen = New PdfPen(brush, 0.5F)

			' Set the string format of the header style to a new PdfStringFormat object with center alignment
			table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)

			' Set the header source of the table style to use row-based headers
			table.Style.HeaderSource = PdfHeaderSource.Rows

			' Set the number of header rows to 1
			table.Style.HeaderRowCount = 1

			' Enable the display of the table header
			table.Style.ShowHeader = True

			' Create a new PdfTrueTypeFont object for the header font using Arial with size 14
			Dim fontHeader As New PdfTrueTypeFont(New Font("Arial", 14.0F))

			' Set the font of the header style to the created header font
			table.Style.HeaderStyle.Font = fontHeader

			' Set the background brush of the header style to cadet blue
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue

			' Create a new PdfTrueTypeFont object for the body font using Arial with size 12
			Dim fontBody As New PdfTrueTypeFont(New Font("Arial", 12.0F))

			' Set the font of the alternate style (body) to the created body font
			table.Style.AlternateStyle.Font = fontBody

			' Set the font of the alternate style (body) to the created body font
			table.Style.AlternateStyle.Font = fontBody

			' Set the data source of the table using the 'GetData' function without any specified parameter
			table.DataSource = GetData()

			' Iterate through each column in the table and set its string format to center alignment and middle vertical alignment
			For Each column As PdfColumn In table.Columns
				column.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			Next column

			' Add event handlers for the BeginRowLayout and EndCellLayout events of the table
			AddHandler table.BeginRowLayout, AddressOf table_BeginRowLayout
			AddHandler table.EndCellLayout, AddressOf table_EndCellLayout

			' Draw the table on the page at the specified position (0, 100)
			table.Draw(page, New PointF(0, 100))

			' Save the PdfDocument to a file named "AddImageinATableCell_out.pdf" in PDF format
			doc.SaveToFile("AddImageinATableCell_out.pdf", FileFormat.PDF)

			' Close the PdfDocument
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer("AddImageinATableCell_out.pdf")
		End Sub

		Private Function GetData() As DataTable
			' Create a new DataTable object
			Dim dt As New DataTable()

			' Add two columns to the DataTable
			dt.Columns.Add("column1", GetType(String))
			dt.Columns.Add("column2", GetType(String))

			' Create two new rows
			Dim row1 As DataRow = dt.NewRow()
			Dim row2 As DataRow = dt.NewRow()

			' Set value
			row1(0) = "Column1"
			row1(1) = "Column2"
			row2(0) = "Insert an image in table cell"
			row2(1) = ""

			' Add the rows
			dt.Rows.Add(row1)
			dt.Rows.Add(row2)

			Return dt
		End Function

		Private Sub table_EndCellLayout(ByVal sender As Object, ByVal args As EndCellLayoutEventArgs)
			' Check if the row index is 1 and the cell index is 1
			If args.RowIndex = 1 AndAlso args.CellIndex = 1 Then
				' Load an image from file
				Dim image As PdfImage = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png")

				' Calculate the X and Y coordinates to center the image within the bounds of the cell
				Dim x As Single = (args.Bounds.Width - image.PhysicalDimension.Width) / 2 + args.Bounds.X
				Dim y As Single = (args.Bounds.Height - image.PhysicalDimension.Height) / 2 + args.Bounds.Y

				' Draw the image using the calculated coordinates
				args.Graphics.DrawImage(image, x, y)
			End If
		End Sub
		Private Sub table_BeginRowLayout(ByVal sender As Object, ByVal args As BeginRowLayoutEventArgs)
			' Check if the row index is 1
			If args.RowIndex = 1 Then
				' Load an image from file
				Dim image As PdfImage = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png")

				' Set the minimal height of the row to accommodate the image and add a margin of 4 units
				args.MinimalHeight = image.PhysicalDimension.Height + 4
			End If
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
