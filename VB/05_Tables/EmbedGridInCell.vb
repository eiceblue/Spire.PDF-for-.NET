Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Grid
Imports System.ComponentModel
Imports System.Text

Namespace EmbedGridInCell
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document and load file from disk
			Dim doc As New PdfDocument()
		doc.LoadFromFile("..\..\..\..\..\..\Data\EmbedGridInCell.pdf")
			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Create a pdf grid
			Dim grid As New PdfGrid()

			'Add a row 
			Dim row As PdfGridRow = grid.Rows.Add()

			'Add two columns
			grid.Columns.Add(2)

			'Set the width of the first column
			grid.Columns(0).Width = 120
			grid.Columns(1).Width = 300

			Dim imageSize As New SizeF(70, 70)
			 Dim LR As Single = (grid.Columns(0).Width-imageSize.Width)/2
			'Set the cell padding
			 grid.Style.CellPadding = New PdfPaddings(LR, LR, 1, 1)
			'Add an image
			Dim list As New PdfGridCellContentList()
			Dim textAndStyle As New PdfGridCellContent()
			textAndStyle.Image = PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png")


			'Set the size of image
			textAndStyle.ImageSize = imageSize
			list.List.Add(textAndStyle)

			'Add an image into the first cell 
			row.Cells(0).Value = list

			'Create another grid
			Dim grid2 As New PdfGrid()
			grid2.Columns.Add(2)
			Dim newrow As PdfGridRow = grid2.Rows.Add()
			grid2.Columns(0).Width = 120
			grid2.Columns(1).Width = 120
			newrow.Cells(0).Value = "Embeded grid"
			newrow.Cells(0).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
			newrow.Cells(1).Value = "Embeded grid"
			newrow.Cells(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

			'Assign grid2 to the cell
			row.Cells(1).Value = grid2
			row.Cells(1).StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

			Dim data() As String = { "VendorName;Address1 & City & State & Country", "Cacor Corporation;161 Southfield Rd  & Southfield & OH & U.S.A.", "Underwater; 50 N 3rd Street & Indianapolis & IN & U.S.A.", "J.W.  Luscher;65 Addams Street & Berkely & MA & U.S.A.", "Scuba;3105 East Brace & Rancho Dominguez & CA & U.S.A.", "Divers Supply;5208 University Dr & Macon & GA & U.S.A.", "Techniques;52 Dolphin Drive & Redwood City & CA & U.S.A.", "Perry Scuba; 3443 James Ave & Hapeville & GA & U.S.A.", "Beauchat, Inc.;45900 SW 2nd Ave & Ft Lauderdale & FL & U.S.A.", "Amor Aqua;42 West 29th Street & New York & NY & U.S.A.", "Aqua Research;P.O. Box 998 & Cornish & NH & U.S.A.", "B&K Undersea;116 W 7th Street & New York & NY & U.S.A.", "Diving;1148 David Drive & San Diego & DA & U.S.A.", "Nautical;65 NW 167 Street & Miami & FL & U.S.A.", "Glen Specialties;17663 Campbell Lane & Huntington Beach & CA & U.S.A.", "Dive Time;20 Miramar Ave & Long Beach & CA & U.S.A.", "Undersea Systems;18112 Gotham Street & Huntington Beach & C & U.S.A." }

			'Insert data to grid
			For r As Integer = 0 To data.Length - 1
				Dim row1 As PdfGridRow = grid.Rows.Add()
				Dim rowData() As String = data(r).Split(";"c)
				For c As Integer = 0 To rowData.Length - 1
					row1.Cells(c).Value = rowData(c)
					row1.Cells(c).StringFormat = New PdfStringFormat(PdfTextAlignment.Center,PdfVerticalAlignment.Middle)
				Next c
			Next r


			'Draw pdf grid into page at a specific location
			grid.Draw(page, New PointF(50, 330))

			'Save the pdf document
			doc.SaveToFile("EmbedGridInCell.pdf")

			'Launch the document
			PDFDocumentViewer("EmbedGridInCell.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
