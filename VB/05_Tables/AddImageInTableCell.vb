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
			'Create a Pdf documemt
			Dim doc As New PdfDocument()
			Dim page As PdfPageBase = doc.Pages.Add()

			'Create a table
			Dim table As New PdfTable()
			Dim brush As New PdfSolidBrush(Color.Black)
			table.Style.BorderPen = New PdfPen(brush, 0.5f)
			table.Style.HeaderStyle.StringFormat = New PdfStringFormat(PdfTextAlignment.Center)
			table.Style.HeaderSource = PdfHeaderSource.Rows
			table.Style.HeaderRowCount = 1
			table.Style.ShowHeader = True

			Dim fontHeader As New PdfTrueTypeFont(New Font("Arial", 14f))
			table.Style.HeaderStyle.Font = fontHeader
			table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.CadetBlue

			Dim fontBody As New PdfTrueTypeFont(New Font("Arial", 12f))
			table.Style.AlternateStyle.Font = fontBody
			table.Style.AlternateStyle.Font = fontBody
			table.DataSource = GetData()

			For Each column As PdfColumn In table.Columns
				column.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			Next column

			'Set the row height
			AddHandler table.BeginRowLayout, AddressOf table_BeginRowLayout

			'Draw an image in a cell
			AddHandler table.EndCellLayout, AddressOf table_EndCellLayout

			'Draw the table in the page
			table.Draw(page, New PointF(0, 100))

			'Save the Pdf document
			doc.SaveToFile("AddImageinATableCell_out.pdf", FileFormat.PDF)

			'Launch the Pdf file
			PDFDocumentViewer("AddImageinATableCell_out.pdf")
		End Sub

		Private Function GetData() As DataTable
			Dim dt As New DataTable()
			dt.Columns.Add("column1", GetType(String))
			dt.Columns.Add("column2", GetType(String))
			Dim row1 As DataRow = dt.NewRow()
			Dim row2 As DataRow = dt.NewRow()
			row1(0) = "Column1"
			row1(1) = "Column2"
			row2(0) = "Insert an image in table cell"
			row2(1) = ""
			dt.Rows.Add(row1)
			dt.Rows.Add(row2)
			Return dt
		End Function

		Private Sub table_EndCellLayout(ByVal sender As Object, ByVal args As EndCellLayoutEventArgs)
			If args.RowIndex=1 AndAlso args.CellIndex = 1 Then
				Dim image As PdfImage = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png")
				Dim x As Single = (args.Bounds.Width - image.PhysicalDimension.Width) / 2 + args.Bounds.X
				Dim y As Single = (args.Bounds.Height - image.PhysicalDimension.Height) / 2 + args.Bounds.Y
				args.Graphics.DrawImage(image, x, y)
			End If
		End Sub
		Private Sub table_BeginRowLayout(ByVal sender As Object, ByVal args As BeginRowLayoutEventArgs)
			If args.RowIndex=1 Then
				Dim image As PdfImage = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png")
				args.MinimalHeight = image.PhysicalDimension.Height+4
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
